﻿namespace VixenModules.Output.GenericSerial
{
    partial class SetupDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOkay = new System.Windows.Forms.Button();
			this.gbPacketData = new System.Windows.Forms.GroupBox();
			this.tbFooter = new System.Windows.Forms.TextBox();
			this.cbFooter = new System.Windows.Forms.CheckBox();
			this.tbHeader = new System.Windows.Forms.TextBox();
			this.cbHeader = new System.Windows.Forms.CheckBox();
			this.btnPortSetup = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblSettings = new System.Windows.Forms.Label();
			this.lblSettingsLbl = new System.Windows.Forms.Label();
			this.gbPacketData.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(293, 286);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 28);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOkay
			// 
			this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOkay.Location = new System.Drawing.Point(185, 287);
			this.btnOkay.Margin = new System.Windows.Forms.Padding(4);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size(100, 28);
			this.btnOkay.TabIndex = 1;
			this.btnOkay.Text = "OK";
			this.btnOkay.UseVisualStyleBackColor = true;
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// gbPacketData
			// 
			this.gbPacketData.Controls.Add(this.tbFooter);
			this.gbPacketData.Controls.Add(this.cbFooter);
			this.gbPacketData.Controls.Add(this.tbHeader);
			this.gbPacketData.Controls.Add(this.cbHeader);
			this.gbPacketData.Location = new System.Drawing.Point(19, 108);
			this.gbPacketData.Margin = new System.Windows.Forms.Padding(4);
			this.gbPacketData.Name = "gbPacketData";
			this.gbPacketData.Padding = new System.Windows.Forms.Padding(4);
			this.gbPacketData.Size = new System.Drawing.Size(375, 171);
			this.gbPacketData.TabIndex = 2;
			this.gbPacketData.TabStop = false;
			this.gbPacketData.Text = "Packet Data";
			// 
			// tbFooter
			// 
			this.tbFooter.Location = new System.Drawing.Point(33, 130);
			this.tbFooter.Margin = new System.Windows.Forms.Padding(4);
			this.tbFooter.Name = "tbFooter";
			this.tbFooter.Size = new System.Drawing.Size(332, 20);
			this.tbFooter.TabIndex = 3;
			// 
			// cbFooter
			// 
			this.cbFooter.AutoSize = true;
			this.cbFooter.Location = new System.Drawing.Point(9, 101);
			this.cbFooter.Margin = new System.Windows.Forms.Padding(4);
			this.cbFooter.Name = "cbFooter";
			this.cbFooter.Size = new System.Drawing.Size(110, 17);
			this.cbFooter.TabIndex = 2;
			this.cbFooter.Text = "Send a text footer";
			this.cbFooter.UseVisualStyleBackColor = true;
			this.cbFooter.CheckedChanged += new System.EventHandler(this.cbFooter_CheckedChanged);
			// 
			// tbHeader
			// 
			this.tbHeader.Location = new System.Drawing.Point(33, 54);
			this.tbHeader.Margin = new System.Windows.Forms.Padding(4);
			this.tbHeader.Name = "tbHeader";
			this.tbHeader.Size = new System.Drawing.Size(332, 20);
			this.tbHeader.TabIndex = 1;
			// 
			// cbHeader
			// 
			this.cbHeader.AutoSize = true;
			this.cbHeader.Location = new System.Drawing.Point(9, 25);
			this.cbHeader.Margin = new System.Windows.Forms.Padding(4);
			this.cbHeader.Name = "cbHeader";
			this.cbHeader.Size = new System.Drawing.Size(116, 17);
			this.cbHeader.TabIndex = 0;
			this.cbHeader.Text = "Send a text header";
			this.cbHeader.UseVisualStyleBackColor = true;
			this.cbHeader.CheckedChanged += new System.EventHandler(this.cbHeader_CheckedChanged);
			// 
			// btnPortSetup
			// 
			this.btnPortSetup.Location = new System.Drawing.Point(159, 44);
			this.btnPortSetup.Margin = new System.Windows.Forms.Padding(4);
			this.btnPortSetup.Name = "btnPortSetup";
			this.btnPortSetup.Size = new System.Drawing.Size(208, 28);
			this.btnPortSetup.TabIndex = 3;
			this.btnPortSetup.Text = "Setup/Change Serial Port";
			this.btnPortSetup.UseVisualStyleBackColor = true;
			this.btnPortSetup.Click += new System.EventHandler(this.btnPortSetup_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblSettings);
			this.groupBox1.Controls.Add(this.lblSettingsLbl);
			this.groupBox1.Controls.Add(this.btnPortSetup);
			this.groupBox1.Location = new System.Drawing.Point(19, 15);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(375, 86);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Serial Port Settings";
			// 
			// lblSettings
			// 
			this.lblSettings.AutoSize = true;
			this.lblSettings.Location = new System.Drawing.Point(85, 25);
			this.lblSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSettings.Name = "lblSettings";
			this.lblSettings.Size = new System.Drawing.Size(198, 13);
			this.lblSettings.TabIndex = 5;
			this.lblSettings.Text = "COM1: 115200, Space, 8, OnePointFive";
			// 
			// lblSettingsLbl
			// 
			this.lblSettingsLbl.AutoSize = true;
			this.lblSettingsLbl.Location = new System.Drawing.Point(9, 25);
			this.lblSettingsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSettingsLbl.Name = "lblSettingsLbl";
			this.lblSettingsLbl.Size = new System.Drawing.Size(51, 13);
			this.lblSettingsLbl.TabIndex = 4;
			this.lblSettingsLbl.Text = "Currently:";
			// 
			// SetupDialog
			// 
			this.AcceptButton = this.btnOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(409, 324);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gbPacketData);
			this.Controls.Add(this.btnOkay);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetupDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Generic Serial Setup";
			this.gbPacketData.ResumeLayout(false);
			this.gbPacketData.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.GroupBox gbPacketData;
        private System.Windows.Forms.TextBox tbFooter;
        private System.Windows.Forms.CheckBox cbFooter;
        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.CheckBox cbHeader;
        private System.Windows.Forms.Button btnPortSetup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblSettingsLbl;
    }
}