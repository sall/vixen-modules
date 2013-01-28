namespace VixenModules.App.LightShowScheduler.Controls
{
    partial class Scheduler
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteEndDate = new System.Windows.Forms.DateTimePicker();
            this.dteStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtScheduleName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblLayoutPlayListSequences = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblLayoutLeftRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstPrograms = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstPlayList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tblLayoutUpDown = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.timeFrame1 = new VixenModules.App.LightShowScheduler.Controls.TimeFrame();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tblLayoutPlayListSequences.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblLayoutLeftRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tblLayoutUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.timeFrame1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.47619F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.52381F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 420);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.82849F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.17151F));
            this.tableLayoutPanel2.Controls.Add(this.btnSaveSchedule, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 235);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(723, 182);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSaveSchedule.Location = new System.Drawing.Point(637, 3);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(83, 176);
            this.btnSaveSchedule.TabIndex = 7;
            this.btnSaveSchedule.Text = "Save";
            this.btnSaveSchedule.UseVisualStyleBackColor = true;
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 176);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dteEndDate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dteStartDate, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtScheduleName, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(614, 144);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(309, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Schedule Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(156, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date";
            // 
            // dteEndDate
            // 
            this.dteEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dteEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dteEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEndDate.Location = new System.Drawing.Point(156, 35);
            this.dteEndDate.Name = "dteEndDate";
            this.dteEndDate.Size = new System.Drawing.Size(147, 26);
            this.dteEndDate.TabIndex = 3;
              // 
            // dteStartDate
            // 
            this.dteStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dteStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dteStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteStartDate.Location = new System.Drawing.Point(3, 35);
            this.dteStartDate.Name = "dteStartDate";
            this.dteStartDate.Size = new System.Drawing.Size(147, 26);
            this.dteStartDate.TabIndex = 4;
             // 
            // txtScheduleName
            // 
            this.txtScheduleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScheduleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtScheduleName.Location = new System.Drawing.Point(309, 35);
            this.txtScheduleName.Name = "txtScheduleName";
            this.txtScheduleName.Size = new System.Drawing.Size(302, 26);
            this.txtScheduleName.TabIndex = 5;
              // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tblLayoutPlayListSequences);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(620, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Programs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tblLayoutPlayListSequences
            // 
            this.tblLayoutPlayListSequences.ColumnCount = 4;
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPlayListSequences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tblLayoutPlayListSequences.Controls.Add(this.panel1, 1, 0);
            this.tblLayoutPlayListSequences.Controls.Add(this.panel2, 0, 0);
            this.tblLayoutPlayListSequences.Controls.Add(this.panel3, 2, 0);
            this.tblLayoutPlayListSequences.Controls.Add(this.panel5, 3, 0);
            this.tblLayoutPlayListSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPlayListSequences.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutPlayListSequences.Name = "tblLayoutPlayListSequences";
            this.tblLayoutPlayListSequences.RowCount = 1;
            this.tblLayoutPlayListSequences.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.97626F));
            this.tblLayoutPlayListSequences.Size = new System.Drawing.Size(620, 150);
            this.tblLayoutPlayListSequences.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblLayoutLeftRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(253, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 144);
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
            this.tblLayoutLeftRight.Size = new System.Drawing.Size(53, 144);
            this.tblLayoutLeftRight.TabIndex = 6;
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveRight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F);
            this.btnMoveRight.Location = new System.Drawing.Point(3, 3);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(47, 66);
            this.btnMoveRight.TabIndex = 6;
            this.btnMoveRight.Text = ">";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveLeft.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F);
            this.btnMoveLeft.Location = new System.Drawing.Point(3, 75);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(47, 66);
            this.btnMoveLeft.TabIndex = 5;
            this.btnMoveLeft.Text = "<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstPrograms);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 144);
            this.panel2.TabIndex = 4;
            // 
            // lstPrograms
            // 
            this.lstPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrograms.FormattingEnabled = true;
            this.lstPrograms.Location = new System.Drawing.Point(0, 22);
            this.lstPrograms.Name = "lstPrograms";
            this.lstPrograms.Size = new System.Drawing.Size(244, 122);
            this.lstPrograms.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Available Programs";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstPlayList);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(312, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 144);
            this.panel3.TabIndex = 5;
            // 
            // lstPlayList
            // 
            this.lstPlayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPlayList.FormattingEnabled = true;
            this.lstPlayList.Location = new System.Drawing.Point(0, 22);
            this.lstPlayList.Name = "lstPlayList";
            this.lstPlayList.Size = new System.Drawing.Size(244, 122);
            this.lstPlayList.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Assigned Programs";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tblLayoutUpDown);
            this.panel5.Location = new System.Drawing.Point(562, 3);
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
            // timeFrame1
            // 
            this.timeFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeFrame1.GridBack = System.Drawing.Color.White;
            this.timeFrame1.HotTrack = System.Drawing.Color.Red;
            this.timeFrame1.Location = new System.Drawing.Point(3, 3);
            this.timeFrame1.Name = "timeFrame1";
            this.timeFrame1.Selected = System.Drawing.SystemColors.Highlight;
            this.timeFrame1.Size = new System.Drawing.Size(723, 226);
            this.timeFrame1.TabIndex = 0;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Scheduler";
            this.Size = new System.Drawing.Size(729, 420);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tblLayoutPlayListSequences.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tblLayoutLeftRight.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tblLayoutUpDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TimeFrame timeFrame1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSaveSchedule;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteEndDate;
        private System.Windows.Forms.DateTimePicker dteStartDate;
        private System.Windows.Forms.TextBox txtScheduleName;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPlayListSequences;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutLeftRight;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstPrograms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstPlayList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tblLayoutUpDown;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
    }
}
