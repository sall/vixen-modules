using System;
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
using System.Windows.Forms;
using VixenModules.App.LightShowScheduler.Data;
using System.IO;

namespace VixenModules.App.LightShowScheduler
{
    public class LightShowSchedulerModule : AppModuleInstanceBase
    {
        IApplication _application;
        SynchronizationContext _synchronizationContext;
        SchedulerData _data;
        private const string ID_ROOT = "SCHEDULER_ROOT";
        Timer scheduleTimer;
        public LightShowSchedulerModule()
        {
            scheduleTimer = new Timer(5000);
            scheduleTimer.Elapsed += scheduleTimer_Elapsed;
        }


        public override IApplication Application
        {
            set { _application = value; }
        }

        public override void Loading()
        {
            VixenSystem.Logs.AddLog(new LightShowSchedulerLog());
            _AddApplicationMenu();
            _SetEnableState(_data.IsEnabled);
            _synchronizationContext = SynchronizationContext.Current;

            VixenSystem.Logging.Schedule("Light Show Scheduler module loaded.");
        }

        public override IModuleDataModel StaticModuleData
        {
            get { return _data; }
            set { _data = (SchedulerData)value; }
        }

        private bool appSupportsCommands
        {
            get
            {
                return _application != null && _application.AppCommands != null;
            }
        }

        private void _AddApplicationMenu()
        {
            if (appSupportsCommands)
            {
                var cmdRoot = new AppCommand(ID_ROOT, "Light Show Scheduler");

                var cmdEnabled = new LatchedAppCommand("LightShowSchedulerEnabled", "Enabled");

                cmdEnabled.IsChecked = _data.IsEnabled;
                cmdEnabled.Checked += cmdEnabled_Checked;


                AppCommand separator1 = new AppCommand("s1", "-");

                var cmdShow = new AppCommand("LightShowSchedulerShow", "Schedule");
                cmdShow.Click += cmdShow_Click;


                cmdRoot.Add(cmdEnabled);
                cmdRoot.Add(separator1);
                cmdRoot.Add(cmdShow);

                _application.AppCommands.Add(cmdRoot);
            }
        }

        Forms.SchedulerForm form;
        void cmdShow_Click(object sender, EventArgs e)
        {

            form = new Forms.SchedulerForm(_data);
            form.SchedulerFormSaved += form_SchedulerFormSaved;
            form.Show();
        }

        void form_SchedulerFormSaved(object sender, EventArgs e)
        {
            StaticModuleData = (IModuleDataModel)((Data.SaveScheduleEventArgs)e).data;

        }

        void cmdEnabled_Checked(object sender, LatchedEventArgs e)
        {
            _data.IsEnabled = e.CheckedState;
            _SetEnableState(_data.IsEnabled);
        }

        private void _RemoveApplicationMenu()
        {
            if (appSupportsCommands)
            {
                _application.AppCommands.Remove(ID_ROOT);
            }
        }
        public override void Unloading()
        {
            _RemoveApplicationMenu();
            _SetEnableState(false);
            VixenSystem.Logging.Schedule("Light Show Scheduler module unloaded.");
            VixenSystem.Logs.RemoveLog("LightSHowSchedule");
        }

        private void _SetEnableState(bool value)
        {
            VixenSystem.Logging.Schedule(string.Format("Turning scheduler {0}", (value ? "ON" : "OFF")));
            scheduleTimer.Enabled = value;
        }

        private readonly Dictionary<string, IProgramContext> _cachedPrograms;
        private readonly Dictionary<IProgramContext, ScheduleItem> _currentContexts;
        void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _data.Schedules.ForEach(sched =>
            {
                if (sched.IsScheduled())
                {
                    Execute(sched);
                }
            });
        }
        private void Execute(ScheduleItem item)
        {

            _SetEnableState(false);
            foreach (var pro in item.Programs)
            {
                string filepath = Path.Combine(Program.ProgramDirectory, pro + ".pro");
                try
                {
                    if (!item.IsScheduled())
                        return;


                    VixenSystem.Logging.Schedule(string.Format("Executing scheduled item: {0}", filepath));
                    IProgramContext context;

                    if (_cachedPrograms.ContainsKey(filepath))
                    {
                        VixenSystem.Logging.Schedule("Item found in cached programs. Reusing.");
                        context = _cachedPrograms[filepath];
                    }
                    else
                    {
                        VixenSystem.Logging.Schedule("Item NOT found in cached programs. Generating...");
                        Program program = Vixen.Services.ApplicationServices.LoadProgram(filepath);
                        context = VixenSystem.Contexts.CreateProgramContext(new ContextFeatures(ContextCaching.ContextLevelCaching), program);

                        foreach (ISequence sequence in context.Program.Sequences)
                        {
                            VixenSystem.Logging.Schedule(string.Format("  - Prerendering effects for sequence: {0}", sequence.Name));
                            foreach (IEffectNode effectNode in sequence.SequenceData.EffectData.Cast<IEffectNode>())
                            {
                                effectNode.Effect.PreRender();
                            }
                        }

                        _cachedPrograms[filepath] = context;
                    }


                    _currentContexts[context] = item;
                    item.IsExecuting = true;
                    item.LastExecutedAt = DateTime.Now;

                    VixenSystem.Logging.Schedule("Starting execution.");

                    context.Start();
                }
                catch (Exception ex)
                {
                    VixenSystem.Logging.Schedule(string.Format("Could not execute sequence {0};{1}", filepath, ex.Message));
                }
            }
            _SetEnableState(true);


        }

    }
}
