namespace VixenModules.App.LightShowScheduler.Controls
{
    partial class Programs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblLayoutPlayListSequences = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblLayoutLeftRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstSequences = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstPlayList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tblLayoutUpDown = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblLayoutProgramName = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.tblLayoutPlayListSequences.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblLayoutLeftRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tblLayoutUpDown.SuspendLayout();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutProgramName.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutPlayListSequences
            // 
            this.tblLayoutPlayListSequences.ColumnCount = 4;
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayoutPlayListSequences.Controls.Add(this.panel1, 1, 0);
            this.tblLayoutPlayListSequences.Controls.Add(this.panel2, 0, 0);
            this.tblLayoutPlayListSequences.Controls.Add(this.panel3, 2, 0);
            this.tblLayoutPlayListSequences.Controls.Add(this.panel5, 3, 0);
            this.tblLayoutPlayListSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPlayListSequences.Location = new System.Drawing.Point(3, 3);
            this.tblLayoutPlayListSequences.Name = "tblLayoutPlayListSequences";
            this.tblLayoutPlayListSequences.RowCount = 1;
            this.tblLayoutPlayListSequences.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.97626F));
            this.tblLayoutPlayListSequences.Size = new System.Drawing.Size(911, 339);
            this.tblLayoutPlayListSequences.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblLayoutLeftRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(399, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 333);
            this.panel1.TabIndex = 3;
            // 
            // tblLayoutLeftRight
            // 
            this.tblLayoutLeftRight.ColumnCount = 1;
            this.tblLayoutLeftRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutLeftRight.Controls.Add(this.btnMoveRight, 0, 0);
            this.tblLayoutLeftRight.Controls.Add(this.btnMoveLeft, 0, 1);
            this.tblLayoutLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutLeftRight.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutLeftRight.Name = "tblLayoutLeftRight";
            this.tblLayoutLeftRight.RowCount = 2;
            this.tblLayoutLeftRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutLeftRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutLeftRight.Size = new System.Drawing.Size(53, 333);
            this.tblLayoutLeftRight.TabIndex = 6;
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveRight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F);
            this.btnMoveRight.Location = new System.Drawing.Point(3, 3);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(47, 160);
            this.btnMoveRight.TabIndex = 6;
            this.btnMoveRight.Text = ">";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveLeft.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F);
            this.btnMoveLeft.Location = new System.Drawing.Point(3, 169);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(47, 161);
            this.btnMoveLeft.TabIndex = 5;
            this.btnMoveLeft.Text = "<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstSequences);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 333);
            this.panel2.TabIndex = 4;
            // 
            // lstSequences
            // 
            this.lstSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSequences.FormattingEnabled = true;
            this.lstSequences.Location = new System.Drawing.Point(0, 22);
            this.lstSequences.Name = "lstSequences";
            this.lstSequences.Size = new System.Drawing.Size(390, 311);
            this.lstSequences.TabIndex = 2;
            this.lstSequences.DoubleClick += new System.EventHandler(this.lstSequences_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sequences";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstPlayList);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(458, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 333);
            this.panel3.TabIndex = 5;
            // 
            // lstPlayList
            // 
            this.lstPlayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPlayList.FormattingEnabled = true;
            this.lstPlayList.Location = new System.Drawing.Point(0, 22);
            this.lstPlayList.Name = "lstPlayList";
            this.lstPlayList.Size = new System.Drawing.Size(390, 311);
            this.lstPlayList.TabIndex = 3;
            this.lstPlayList.DoubleClick += new System.EventHandler(this.lstPlayList_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Playlist";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tblLayoutUpDown);
            this.panel5.Location = new System.Drawing.Point(854, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(54, 127);
            this.panel5.TabIndex = 6;
            // 
            // tblLayoutUpDown
            // 
            this.tblLayoutUpDown.ColumnCount = 1;
            this.tblLayoutUpDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutUpDown.Controls.Add(this.btnMoveDown, 0, 1);
            this.tblLayoutUpDown.Controls.Add(this.btnMoveUp, 0, 0);
            this.tblLayoutUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutUpDown.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutUpDown.Name = "tblLayoutUpDown";
            this.tblLayoutUpDown.RowCount = 2;
            this.tblLayoutUpDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutUpDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutUpDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutUpDown.Size = new System.Drawing.Size(54, 127);
            this.tblLayoutUpDown.TabIndex = 0;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveDown.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(3, 66);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(48, 58);
            this.btnMoveDown.TabIndex = 8;
            this.btnMoveDown.Text = "v";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveUp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(3, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(48, 57);
            this.btnMoveUp.TabIndex = 5;
            this.btnMoveUp.Text = "^";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.ColumnCount = 1;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutMain.Controls.Add(this.tblLayoutPlayListSequences, 0, 0);
            this.tblLayoutMain.Controls.Add(this.tblLayoutProgramName, 0, 1);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 2;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.43716F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tblLayoutMain.Size = new System.Drawing.Size(917, 406);
            this.tblLayoutMain.TabIndex = 12;
            // 
            // tblLayoutProgramName
            // 
            this.tblLayoutProgramName.ColumnCount = 3;
            this.tblLayoutProgramName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.1426F));
            this.tblLayoutProgramName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.85741F));
            this.tblLayoutProgramName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tblLayoutProgramName.Controls.Add(this.label3, 0, 0);
            this.tblLayoutProgramName.Controls.Add(this.btnSave, 2, 0);
            this.tblLayoutProgramName.Controls.Add(this.txtProgramName, 1, 0);
            this.tblLayoutProgramName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutProgramName.Location = new System.Drawing.Point(3, 348);
            this.tblLayoutProgramName.Name = "tblLayoutProgramName";
            this.tblLayoutProgramName.RowCount = 1;
            this.tblLayoutProgramName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutProgramName.Size = new System.Drawing.Size(911, 55);
            this.tblLayoutProgramName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Program Name";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnSave.Location = new System.Drawing.Point(766, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 49);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProgramName
            // 
            this.txtProgramName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtProgramName.Location = new System.Drawing.Point(202, 3);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(558, 27);
            this.txtProgramName.TabIndex = 1;
            this.txtProgramName.TextChanged += new System.EventHandler(this.txtProgramName_TextChanged);
            // 
            // Programs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutMain);
            this.Name = "Programs";
            this.Size = new System.Drawing.Size(917, 406);
            this.tblLayoutPlayListSequences.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tblLayoutLeftRight.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tblLayoutUpDown.ResumeLayout(false);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutProgramName.ResumeLayout(false);
            this.tblLayoutProgramName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayoutPlayListSequences;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutLeftRight;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstSequences;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstPlayList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tblLayoutUpDown;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tblLayoutProgramName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProgramName;


    }
}
