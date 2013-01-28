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

namespace VixenModules.App.LightShowScheduler
{
    public class LightShowSchedulerModule : AppModuleInstanceBase
    {
        IApplication _application;
        SynchronizationContext _synchronizationContext;
        SchedulerData _data;
        private const string ID_ROOT = "SCHEDULER_ROOT";

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
        private void _SetEnableState(bool value)
        {
            VixenSystem.Logging.Schedule("Turning scheduler " + (value ? "ON" : "OFF"));
            //    Timer.Enabled = value;
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
    }
}
