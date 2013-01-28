using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vixen.Services;
using Vixen.Sys;
using System.IO;

namespace VixenModules.App.LightShowScheduler.Controls
{
    public partial class Programs : UserControl
    {
        private Program originalProgram;
        private Program editingProgram;
        public event EventHandler ProgramSaved;
        public string OldProgramName { get; set; }
        public bool NewSequence { get; set; }
        public Programs(Program program)
        {
            if (program == null) throw new ArgumentNullException("program");

            InitializeComponent();
            _Program = program;
            OldProgramName = ProgramName = program.Name;

            Sequences = SequenceService.Instance.GetAllSequenceFileNames().Select(x => new ItemData(x));


            validate();
        }

        private Program _Program
        {
            get { return editingProgram; }
            set
            {
                originalProgram = value;
                editingProgram = new Program(originalProgram);
                ProgramName = editingProgram.Name;
                PlayListItems = editingProgram.Select(x => new ItemData(x.FilePath));
            }
        }

        public string ProgramName
        {
            get { return this.txtProgramName.Text; }
            set { txtProgramName.Text = value; }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            this.lstPlayList.MoveSelectedItemUp();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            this.lstPlayList.MoveSelectedItemDown();
        }
        
        List<string> validationMessages = new List<string>();

        private void validate()
        {
            this.btnSave.Enabled = !string.IsNullOrWhiteSpace(ProgramName) && this.PlayListItems.Count() > 0;
        }

        internal struct ItemData
        {
            private readonly string Name;
            public string Path;

            public ItemData(string path)
            {
                Name = System.IO.Path.GetFileName(path);
                Path = path;

            }

            public override string ToString()
            {
                return Name;
            }
        }
        internal IEnumerable<ItemData> Sequences
        {
            get { return lstSequences.Items.Cast<ItemData>(); }
            set
            {
                lstSequences.Items.Clear();
                lstSequences.Items.AddRange(value.Cast<Object>().ToArray());
            }
        }

        internal IEnumerable<ItemData> PlayListItems
        {
            get { return lstPlayList.Items.Cast<ItemData>(); }
            set
            {
                lstPlayList.Items.Clear();
                lstPlayList.Items.AddRange(value.Cast<Object>().ToArray());
            }
        }
        private void _Move(ListBox from, ListBox to)
        {
            if (from.SelectedItem != null)
            {
                if (to.Name.Equals("lstPlaylist", StringComparison.InvariantCultureIgnoreCase))
                    to.Items.Add(from.SelectedItem);

                if (from.Name.Equals("lstPlaylist", StringComparison.InvariantCultureIgnoreCase))
                    from.Items.Remove(from.SelectedItem);
            }
           
        }


        private void lstSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveRight.Enabled = canMoveRight;
        }

        private void lstPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveLeft.Enabled = canMoveLeft;
            btnMoveUp.Enabled = canMoveUp;
            btnMoveDown.Enabled = canMoveDown;
        }

        private bool canMoveLeft
        {
            get { return lstPlayList.SelectedItem != null; }
        }

        private bool canMoveRight
        {
            get { return lstSequences.SelectedItem != null; }
        }

        private bool canMoveUp
        {
            get
            {
                return
                    lstPlayList.SelectedItems.Count == 1 &&
                    lstPlayList.SelectedIndex > 0;
            }
        }

        private bool canMoveDown
        {
            get
            {
                return
                    lstPlayList.SelectedItems.Count == 1 &&
                    lstPlayList.SelectedIndex < lstPlayList.Items.Count - 1;
            }
        }

        private bool canDelete
        {
            get { return lstPlayList.SelectedItem != null; }
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
           
            lstSequences.CopySelectedItemToListBox(lstPlayList);
            validate();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            lstPlayList.RemoveSelectedItem();
            validate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (originalProgram.FilePath != null && !originalProgram.FilePath.Equals(ProgramName))
                    if (File.Exists(originalProgram.FilePath))
                        File.Delete(originalProgram.FilePath);

                originalProgram.Clear();
                originalProgram.Sequences.AddRange(this.PlayListItems.Select(x => SequenceService.Instance.Load(x.Path)));
                if (File.Exists(Path.Combine(Program.ProgramDirectory, ProgramName.EndsWith("pro") ? ProgramName : ProgramName + ".pro")))
                {
                    var msgBox = MessageBox.Show("This Program Name Already Exists!  Overwrite?", "Program Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (msgBox == DialogResult.Yes)
                        originalProgram.Save(ProgramName);
                }
                else
                    originalProgram.Save(ProgramName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vixen Program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            if (ProgramSaved != null)
                ProgramSaved(this, EventArgs.Empty);
        }

        private void txtProgramName_TextChanged(object sender, EventArgs e)
        {
            validate();

        }

        private void lstPlayList_DoubleClick(object sender, EventArgs e)
        { 
            lstPlayList.RemoveSelectedItem();
            validate();
        }

        private void lstSequences_DoubleClick(object sender, EventArgs e)
        {
            lstSequences.CopySelectedItemToListBox(lstPlayList);
            validate();
        }

    }
}
