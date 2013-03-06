namespace VixenModules.Preview.VixenPreview
{
    partial class VixenPreviewSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VixenPreviewSetup));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddStuffToScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripLightString = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSetBackground = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCurrentUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLastRenderTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerRenderPreview = new System.Windows.Forms.Timer(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.preview = new VixenModules.Preview.VixenPreview.VixenPreviewControl();
            this.dialogSelectBackground = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.stuffToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // stuffToolStripMenuItem
            // 
            this.stuffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddStuffToScreen});
            this.stuffToolStripMenuItem.Name = "stuffToolStripMenuItem";
            this.stuffToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.stuffToolStripMenuItem.Text = "&Stuff";
            // 
            // menuAddStuffToScreen
            // 
            this.menuAddStuffToScreen.Name = "menuAddStuffToScreen";
            this.menuAddStuffToScreen.Size = new System.Drawing.Size(210, 22);
            this.menuAddStuffToScreen.Text = "Add 6,000 Pixels to Screen";
            this.menuAddStuffToScreen.Click += new System.EventHandler(this.menuAddStuffToScreen_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSelect,
            this.toolStripLightString,
            this.toolStripButtonArch,
            this.toolStripButtonEditMode,
            this.toolStripButtonSetBackground});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSelect
            // 
            this.toolStripSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSelect.Name = "toolStripSelect";
            this.toolStripSelect.Size = new System.Drawing.Size(42, 22);
            this.toolStripSelect.Text = "Select";
            this.toolStripSelect.Click += new System.EventHandler(this.toolStripSelect_Click);
            // 
            // toolStripLightString
            // 
            this.toolStripLightString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLightString.Name = "toolStripLightString";
            this.toolStripLightString.Size = new System.Drawing.Size(72, 22);
            this.toolStripLightString.Text = "Light String";
            this.toolStripLightString.Click += new System.EventHandler(this.toolStripLightString_Click);
            // 
            // toolStripButtonArch
            // 
            this.toolStripButtonArch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonArch.Image")));
            this.toolStripButtonArch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArch.Name = "toolStripButtonArch";
            this.toolStripButtonArch.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonArch.Text = "Arch";
            this.toolStripButtonArch.Click += new System.EventHandler(this.toolStripButtonArch_Click);
            // 
            // toolStripButtonEditMode
            // 
            this.toolStripButtonEditMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonEditMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditMode.Image")));
            this.toolStripButtonEditMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditMode.Name = "toolStripButtonEditMode";
            this.toolStripButtonEditMode.Size = new System.Drawing.Size(81, 22);
            this.toolStripButtonEditMode.Text = "Edit Mode";
            this.toolStripButtonEditMode.Click += new System.EventHandler(this.toolStripButtonEditMode_Click);
            // 
            // toolStripButtonSetBackground
            // 
            this.toolStripButtonSetBackground.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSetBackground.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSetBackground.Image")));
            this.toolStripButtonSetBackground.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetBackground.Name = "toolStripButtonSetBackground";
            this.toolStripButtonSetBackground.Size = new System.Drawing.Size(110, 22);
            this.toolStripButtonSetBackground.Text = "Set Background";
            this.toolStripButtonSetBackground.Click += new System.EventHandler(this.toolStripButtonSetBackground_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusCurrentUpdate,
            this.toolStripStatusLastRenderTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatus1";
            // 
            // toolStripStatusCurrentUpdate
            // 
            this.toolStripStatusCurrentUpdate.Name = "toolStripStatusCurrentUpdate";
            this.toolStripStatusCurrentUpdate.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusCurrentUpdate.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLastRenderTime
            // 
            this.toolStripStatusLastRenderTime.Name = "toolStripStatusLastRenderTime";
            this.toolStripStatusLastRenderTime.Size = new System.Drawing.Size(169, 17);
            this.toolStripStatusLastRenderTime.Text = "toolStripStatusLastRenderTime";
            // 
            // timerRenderPreview
            // 
            this.timerRenderPreview.Enabled = true;
            this.timerRenderPreview.Interval = 25;
            this.timerRenderPreview.Tick += new System.EventHandler(this.timerRenderPreview_Tick);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // preview
            // 
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preview.CurrentTool = VixenModules.Preview.VixenPreview.VixenPreviewControl.Tools.Select;
            this.preview.EditMode = false;
            this.preview.Location = new System.Drawing.Point(0, 52);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(624, 364);
            this.preview.TabIndex = 0;
            this.preview.Load += new System.EventHandler(this.preview_Load);
            // 
            // dialogSelectBackground
            // 
            this.dialogSelectBackground.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif|BMP Files|*.bmp|All Files|*.*";
            this.dialogSelectBackground.SupportMultiDottedExtensions = true;
            // 
            // VixenPreviewSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "VixenPreviewSetup";
            this.Text = "Vixen Preview Designer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VixenPreviewControl preview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timerRenderPreview;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton toolStripSelect;
        private System.Windows.Forms.ToolStripButton toolStripLightString;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCurrentUpdate;
        private System.Windows.Forms.ToolStripButton toolStripButtonArch;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditMode;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stuffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddStuffToScreen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLastRenderTime;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetBackground;
        private System.Windows.Forms.OpenFileDialog dialogSelectBackground;
    }
}