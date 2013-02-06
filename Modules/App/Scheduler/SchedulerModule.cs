﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using Vixen.Execution;
using Vixen.Execution.Context;
using Vixen.Sys;
using Vixen.Module;
using Vixen.Module.App;
using Timer = System.Timers.Timer;

namespace VixenModules.App.Scheduler {
	public class SchedulerModule : AppModuleInstanceBase {
		private IApplication _application;
		private SchedulerData _data;
		private Timer _scheduleCheckTimer;
		private readonly ScheduleService _scheduleService;
		private readonly Dictionary<IProgramContext, ScheduleItem> _currentContexts;
		private readonly Dictionary<string, IProgramContext> _cachedPrograms;
		private SynchronizationContext _synchronizationContext;

		private const string ID_ROOT = "SchedulerRoot";

		public SchedulerModule() {
			_scheduleService = new ScheduleService();
			_currentContexts = new Dictionary<IProgramContext, ScheduleItem>();
			_cachedPrograms = new Dictionary<string, IProgramContext>();
		}

		public override void Loading() {
			VixenSystem.Logs.AddLog(new SchedulerLog());
			_AddApplicationMenu();
			_SetEnableState(_data.IsEnabled);
			_synchronizationContext = SynchronizationContext.Current;
			VixenSystem.Logging.Schedule("Scheduler module loaded.");
		}

		public override void Unloading() {
			_RemoveApplicationMenu();
			_SetEnableState(false);
			VixenSystem.Logging.Schedule("Scheduler module unloaded.");
			VixenSystem.Logs.RemoveLog("Schedule");
		}

		public override IApplication Application {
			set { _application = value; }
		}

		public override IModuleDataModel StaticModuleData {
			get { return _data; }
			set { _data = (SchedulerData)value; }
		}

		private Timer Timer {
			get {
				if(_scheduleCheckTimer == null) {
					_scheduleCheckTimer = new Timer(_data.CheckIntervalInSeconds * 1000);
					_scheduleCheckTimer.Elapsed += _scheduleCheckTimer_Elapsed;
				}
				return _scheduleCheckTimer;
			}
		}

		void _scheduleCheckTimer_Elapsed(object sender, ElapsedEventArgs e) {
			IEnumerable<ScheduleItem> validItems = _scheduleService.GetQualifiedItems(_data.Items).Cast<ScheduleItem>();

			foreach(ScheduleItem item in validItems) {
				if(_CanExecute(item)) {
					_synchronizationContext.Post((o) => _Execute(o as ScheduleItem), item);
				}
			}
		}

		private bool _CanExecute(ScheduleItem item) {
			return !item.IsExecuting;
		}

		private void _Execute(ScheduleItem item) {
			try {
				_SetEnableState(false);

				string filepath = item.FilePath;
				VixenSystem.Logging.Schedule("Executing scheduled item: " + filepath);
				IProgramContext context;

				if (_cachedPrograms.ContainsKey(filepath)) {
					VixenSystem.Logging.Schedule("Item found in cached programs. Reusing.");
					context = _cachedPrograms[filepath];
				} else {
					VixenSystem.Logging.Schedule("Item NOT found in cached programs. Generating...");
					Program program = Vixen.Services.ApplicationServices.LoadProgram(filepath);
					context = VixenSystem.Contexts.CreateProgramContext(new ContextFeatures(ContextCaching.ContextLevelCaching), program);

					foreach (ISequence sequence in context.Program.Sequences) {
						VixenSystem.Logging.Schedule("  - Prerendering effects for sequence: " + sequence.Name);
						foreach (IEffectNode effectNode in sequence.SequenceData.EffectData.Cast<IEffectNode>()) {
							effectNode.Effect.PreRender();
						}
					}

					_cachedPrograms[filepath] = context;
				}

				context.ProgramEnded += context_ProgramEnded;

				_currentContexts[context] = item;
				item.IsExecuting = true;
				item.LastExecutedAt = DateTime.Now;

				VixenSystem.Logging.Schedule("Starting execution.");
				context.Start();

				_SetEnableState(true);
			} catch(Exception ex) {
				VixenSystem.Logging.Schedule("Could not execute sequence " + item.FilePath + "; " + ex.Message);
			}
		}

		void context_ProgramEnded(object sender, ProgramEventArgs e) {
			ProgramContext context = sender as ProgramContext;
			context.ProgramEnded -= context_ProgramEnded;
			if (!_cachedPrograms.ContainsValue(context)) {
				VixenSystem.Logging.Schedule("Context wasn't cached, so releasing and cleaning up context.");
				VixenSystem.Contexts.ReleaseContext(context);
			} else {
				VixenSystem.Logging.Schedule("Context is cached, so not cleaning up; will potentially reuse.");
			}
			ScheduleItem item;
			if (_currentContexts.TryGetValue(context, out item)) {
				item.IsExecuting = false;
				_currentContexts.Remove(context);
			}
		}

		private void _SetEnableState(bool value) {
			VixenSystem.Logging.Schedule("Turning scheduler " + (value ? "ON" : "OFF"));
			Timer.Enabled = value;
		}

		private void _AddApplicationMenu() {
			if(_AppSupportsCommands()) {
				AppCommand rootCommand = new AppCommand(ID_ROOT, "Scheduler");

				LatchedAppCommand enabledCommand = new LatchedAppCommand("SchedulerEnabled", "Enabled");
				enabledCommand.IsChecked = _data.IsEnabled;
				enabledCommand.Checked += (sender, e) => {
					// Not setting the data member in _SetEnableState because we want to be
					// able to call _SetEnableState without affecting the data (to stop
					// the scheduler upon shutdown).
					_data.IsEnabled = e.CheckedState;
					_SetEnableState(_data.IsEnabled);
				};

				AppCommand separator1 = new AppCommand("s1", "-");

				AppCommand showCommand = new AppCommand("SchedulerShow", "Show");
				showCommand.Click += (sender, e) => {
					using(SchedulerForm schedulerForm = new SchedulerForm(_data)) {
						if(schedulerForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
							enabledCommand.IsChecked = _data.IsEnabled;
						}
					}
				};

				rootCommand.Add(enabledCommand);
				rootCommand.Add(separator1);
				rootCommand.Add(showCommand);

				_application.AppCommands.Add(rootCommand);
			}
		}

		private void _RemoveApplicationMenu() {
			if(_AppSupportsCommands()) {
				_application.AppCommands.Remove(ID_ROOT);
			}
		}

		private bool _AppSupportsCommands() {
			return _application != null && _application.AppCommands != null;
		}

	}
}
