using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vixen.Services;
using Vixen.Sys;
using VixenModules.App.VixenScheduler.Controls;
using VixenModules.App.VixenScheduler.Data;

namespace VixenModules.App.VixenScheduler.Forms
{
    public partial class SchedulerForm : Form
    {

        const string CAPTION = "Vixen Scheduler";

        public SchedulerData SchedulerData { get; set; }
        public event EventHandler SchedulerFormSaved;
        public SchedulerForm()
        {

            InitializeComponent();
        }

        public SchedulerForm(SchedulerData _data)
        {
            InitializeComponent();

            SchedulerData = _data;
        }
        protected override void OnLoad(EventArgs e)
        {
            FillProgramsToolMenu();
            FillSchedulesToolMenu();
            base.OnLoad(e);
        }

        #region Private Routines

        #region Program Routines

        /// <summary>
        /// Load a New Program to a tab
        /// </summary>
        void LoadProgramToTab()
        {

            string playlistName = string.Empty;
            var input = InputBox("New Playlist Name", "Please Enter a Name for this Playlist", ref playlistName);

            if (input == DialogResult.OK)
            {
                var program = new Program(playlistName);
                LoadProgramToTab(program, true);

            }

        }


        /// <summary>
        /// Load an Existing Program to a tab
        /// </summary>
        /// <param name="file"></param>
        void LoadProgramToTab(FileInfo file)
        {
            Program program = _LoadProgram(file.FullName);
            LoadProgramToTab(program);

            DisableProgramItem(file.Name.Replace(file.Extension, ""));
        }

        /// <summary>
        /// Load an Existing Program to a tab
        /// </summary>
        /// <param name="fileName"></param>
        void LoadProgramToTab(string fileName)
        {
            if (!fileName.EndsWith(".pro", StringComparison.InvariantCultureIgnoreCase))
                fileName += ".pro";

            if (File.Exists(fileName))
            {
                LoadProgramToTab(new FileInfo(fileName));
            }
            else
            {
                var _fileName = Path.Combine(Program.ProgramDirectory, fileName);
                if (File.Exists(_fileName))
                    LoadProgramToTab(new FileInfo(_fileName));

            }

        }

        /// <summary>
        /// Base routine that does the grunt work to loading a program to a tab
        /// </summary>
        /// <param name="program"></param>
        /// <param name="newSequence"></param>
        void LoadProgramToTab(Program program, bool newSequence = false)
        {

            var tab = new TabPage(program.Name);
            var playList = new Controls.Programs(program);
            playList.NewSequence = newSequence;
            tab.Tag = "ProgramTab";
            tab.ContextMenu = new System.Windows.Forms.ContextMenu();
            var closeMnu = new MenuItem("Close");
            tab.ContextMenu.MenuItems.Add(closeMnu);
            closeMnu.Click += closeMnu_Click;
            //tab.MouseUp += tab_MouseUp;
            playList.ProgramSaved += playList_ProgramSaved;
            playList.Dock = DockStyle.Fill;
            tab.Controls.Add(playList);
            playList.Parent = tab;

            this.tabControl1.TabPages.Add(tab);
            this.tabControl1.SelectedTab = tab;
        }

        void playList_ProgramSaved(object sender, EventArgs e)
        {
            var programs = sender.DynamicCast<Controls.Programs>();

            foreach (TabPage item in tabControl1.TabPages)
            {
                if (item.Text.Equals(programs.OldProgramName))
                {
                    item.Text = programs.ProgramName;
                    programs.OldProgramName = item.Text;
                }
            }

            FillProgramsToolMenu();
            DisableProgramItem(programs.ProgramName);
        }

        Program _LoadProgram(string filePath)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                return ApplicationServices.LoadProgram(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        void EnableProgramItem(string Name)
        {
            foreach (ToolStripItem item in programsToolStripMenuItem.DropDownItems)
            {
                if (item.Text.Equals(Name))
                    item.Enabled = true;
            }
        }

        void DisableProgramItem(string Name)
        {
            foreach (ToolStripItem item in programsToolStripMenuItem.DropDownItems)
            {
                if (item.Text.Equals(Name))
                    item.Enabled = false;
            }
        }

        void DeleteProgram()
        {
            if (tabControl1.SelectedTab.Tag == (object)"ProgramTab")
            {
                var msg = MessageBox.Show("Are you sure you want to delete this program? This action is irreversable!", "Delete Program", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    var file = Path.Combine(Program.ProgramDirectory, tabControl1.SelectedTab.Text + ".pro");
                    if (File.Exists(file))
                        File.Delete(file);
                    else
                        MessageBox.Show("Program does Not Exist!", "Delete Program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    FillProgramsToolMenu();

                }
            }
        }



        #endregion



        void closeMnu_Click(object sender, EventArgs e)
        {
            CloseCurrentTab();
        }

        /// <summary>
        /// Closes current tab that is being worked
        /// </summary>
        void CloseCurrentTab()
        {
            currentTab = tabControl1.SelectedTab;
            if (currentTab.Tag == (object)"ProgramTab" || currentTab.Tag == (object)"ScheduleTab")
            {
                switch (currentTab.Tag.DynamicCast<string>())
                {
                    case "ProgramTab":
                        EnableProgramItem(currentTab.Text);
                        break;
                    case "ScheduleTab":
                        EnableScheduleItem(currentTab.Text);
                        break;
                    default:
                        break;
                }

                tabControl1.TabPages.Remove(currentTab);
                currentTab.Dispose();
                currentTab = null;
            }
        }

        TabPage currentTab;

        #region Menu Items
        void programItem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;

            LoadProgramToTab(item.Text);
        }
        void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentTab();
        }
        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Program.ProgramDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadProgramToTab(openFileDialog.FileName);
            }
        }
        void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteProgram();
        }

        void newScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string scheduleName = string.Empty;
            var input = InputBox("New Schedule Name", "Please Enter a Name for this Schedule", ref scheduleName);
            var tab = new TabPage(scheduleName);
            var playList = new Controls.Scheduler(new Data.ScheduleItem(scheduleName));
            playList.SchedulerSaved += playList_SchedulerSaved;
            tab.Controls.Add(playList);
            playList.Parent = tab;
            playList.Dock = DockStyle.Fill;
            tab.Tag = "ScheduleTab";
            this.tabControl1.TabPages.Add(tab);
            this.tabControl1.SelectedTab = tab;

        }

        #region Context Menu




        #endregion
        #endregion
        #endregion


        #region InputBox

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        #endregion




        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var b = sender.DynamicCast<TabControl>();
            deleteToolStripMenuItem.Enabled = closeProgramToolStripMenuItem.Enabled = (b.SelectedTab.Tag == (object)"ProgramTab");
        }



        void playList_SchedulerSaved(object sender, EventArgs e)
        {
            var data = (ScheduleItem)((SaveScheduleEventArgs)e).data;

            SchedulerData.Schedules.Where(A => A.ID == data.ID).ToList().ForEach(b => SchedulerData.Schedules.Remove(b));

            SchedulerData.Schedules.Add(data);

            if (SchedulerFormSaved != null)
                SchedulerFormSaved(this, new SaveScheduleEventArgs() { data = SchedulerData });

            FillSchedulesToolMenu();
        }

        void EnableScheduleItem(string Name)
        {
            foreach (ToolStripItem item in schedulesToolStripMenuItem.DropDownItems)
            {
                if (item.Text.Equals(Name))
                    item.Enabled = true;
            }
        }

        void DisableScheduleItem(string Name)
        {
            foreach (ToolStripItem item in schedulesToolStripMenuItem.DropDownItems)
            {
                if (item.Text.Equals(Name))
                    item.Enabled = false;
            }
        }


        void FillSchedulesToolMenu()
        {
            List<ToolStripItem> itemsToRemove = new List<ToolStripItem>();
            if (schedulesToolStripMenuItem.DropDownItems != null)
            {
                foreach (ToolStripItem item in schedulesToolStripMenuItem.DropDownItems)
                {
                    if (item.Tag != null)
                    {
                        item.Click -= programItem_Click;
                        itemsToRemove.Add(item);
                    }
                }

            }

            itemsToRemove.ForEach(t => schedulesToolStripMenuItem.DropDownItems.Remove(t));


            SchedulerData.Schedules.ForEach(s =>
            {

                ToolStripMenuItem item = new ToolStripMenuItem(s.Name);
                item.Tag = s.ID;
                item.Click += scheduleItem_Click;
                schedulesToolStripMenuItem.DropDownItems.Add(item);

                if (this.tabControl1.TabPages.ContainsKey(s.Name))
                    item.Enabled = false;
            });



        }
        void FillProgramsToolMenu()
        {
            List<ToolStripItem> itemsToRemove = new List<ToolStripItem>();
            foreach (ToolStripItem item in programsToolStripMenuItem.DropDownItems)
            {
                if (item.Tag != null)
                {
                    itemsToRemove.Add(item);
                    item.Click -= programItem_Click;
                }
            }
            itemsToRemove.ForEach(t => programsToolStripMenuItem.DropDownItems.Remove(t));


            new DirectoryInfo(Program.ProgramDirectory).GetFiles("*.pro").ToList().ForEach(a =>
            {
                ToolStripMenuItem item = new ToolStripMenuItem(a.Name.Replace(a.Extension, ""));

                item.Tag = a.FullName;

                programsToolStripMenuItem.DropDownItems.Add(item);
                item.Click += programItem_Click;
                if (this.tabControl1.TabPages.ContainsKey(item.Text))
                    item.Enabled = false;
            });


        }
        void scheduleItem_Click(object sender, EventArgs e)
        {
            var obj = (ToolStripDropDownItem)sender;

            LoadScheduleToTab((Guid)obj.Tag);
        }

        void LoadScheduleToTab(Guid scheduleID)
        {
            var schedule = SchedulerData.Schedules.Where(w => w.ID == scheduleID).FirstOrDefault();
            if (schedule != null)
            {
                var tab = new TabPage(schedule.Name);

                tab.Tag = "ScheduleTab";
                tab.ContextMenu = new System.Windows.Forms.ContextMenu();
                var closeMnu = new MenuItem("Close");
                tab.ContextMenu.MenuItems.Add(closeMnu);
                closeMnu.Click += closeMnu_Click;
                Scheduler sched = new Scheduler(schedule);
                tab.Controls.Add(sched);
                sched.Parent = tab;
                sched.Dock = DockStyle.Fill;
                this.tabControl1.TabPages.Add(tab);
                this.tabControl1.SelectedTab = tab;
                DisableScheduleItem(schedule.Name);
            }
        }

        private void newProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProgramToTab();
        }


    }
}
