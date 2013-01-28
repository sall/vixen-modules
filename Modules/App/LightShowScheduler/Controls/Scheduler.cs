using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Vixen.Sys;
using VixenModules.App.LightShowScheduler.Data;

namespace VixenModules.App.LightShowScheduler.Controls
{
    public partial class Scheduler : UserControl
    {
        public event EventHandler SchedulerSaved;
        private ScheduleItem _scheduledItem;

        public ScheduleItem ScheduledItem
        {
            get
            {

                return _scheduledItem;
            }
            set { _scheduledItem = value; }
        }
        void LoadData()
        {

        }

        private void UpdateCurrentObject()
        {
            var tmp = new ScheduleItem(timeFrame1.TimeFrames);
            _scheduledItem.Monday = tmp.Monday;
            _scheduledItem.Tuesday = tmp.Tuesday;
            _scheduledItem.Wednesday = tmp.Wednesday;
            _scheduledItem.Thursday = tmp.Thursday;
            _scheduledItem.Friday = tmp.Friday;
            _scheduledItem.Saturday = tmp.Saturday;
            _scheduledItem.Sunday = tmp.Sunday;
            _scheduledItem.Name = this.txtScheduleName.Text;
            _scheduledItem.StartDate = this.dteStartDate.Value;
            _scheduledItem.EndDate = this.dteEndDate.Value;
            _scheduledItem.Programs = new List<string>();
            foreach (var item in this.lstPlayList.Items)
            {
                _scheduledItem.Programs.Add(item.DynamicCast<string>());

            }
        }

        public Scheduler(ScheduleItem show)
        {
            InitializeComponent();
            new DirectoryInfo(Program.ProgramDirectory).GetFiles("*.pro").ToList().ForEach(a =>
            {
                this.lstPrograms.Items.Add(a.Name.Replace(a.Extension, ""));
            });
            ScheduledItem = show;
            this.txtScheduleName.Text = ScheduledItem.Name;
            this.dteEndDate.Value = ScheduledItem.EndDate;
            this.dteStartDate.Value = ScheduledItem.StartDate;
            this.timeFrame1.TimeFrames = ScheduledItem.ToTimeSpanArray();
            ScheduledItem.Programs.ForEach(p => this.lstPlayList.Items.Add(p));
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            this.lstPrograms.CopySelectedItemToListBox(lstPlayList);
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            this.lstPlayList.RemoveSelectedItem();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            this.lstPlayList.MoveSelectedItemUp();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            this.lstPlayList.MoveSelectedItemDown();
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            UpdateCurrentObject();
            if (SchedulerSaved != null)
                SchedulerSaved(this, new SaveScheduleEventArgs() { data = _scheduledItem });

        }




    }
}
