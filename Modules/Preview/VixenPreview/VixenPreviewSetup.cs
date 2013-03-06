using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VixenModules.Preview.VixenPreview.Shapes;
using Vixen.Execution.Context;
using Vixen.Module.Preview;
using Vixen.Data.Value;
using Vixen.Sys;
using System.Diagnostics;

namespace VixenModules.Preview.VixenPreview
{
    public partial class VixenPreviewSetup : Form
    {
        private VixenPreviewData _data;

        public VixenPreviewData Data
        {
            set { 
                _data = value; 
                if (!DesignMode)
                    preview.Data = _data;
            }
            get
            {
                return _data;
            }
        }

        public VixenPreviewSetup()
        {
            InitializeComponent();
        }

        int currentNode = -1;
        private ElementNode GetNextNode()
        {
            currentNode++;
            if (currentNode >= VixenSystem.Nodes.Count())
            {
                currentNode = 0;
                Console.WriteLine(VixenSystem.Nodes.Count());
            }
            ElementNode node = VixenSystem.Nodes.GetAllNodes().ElementAt(currentNode);
            if (node.Children.Count() > 0) {
                node = VixenSystem.Nodes.GetAllNodes().ElementAt(2);
            }
            return node;
        }

        private void toolStripSelect_Click(object sender, EventArgs e)
        {
            toolStripLightString.Checked = false;
            preview.CurrentTool = VixenPreviewControl.Tools.Select;
        }

        private void toolStripLightString_Click(object sender, EventArgs e)
        {
            toolStripSelect.Checked = false;
            toolStripLightString.Checked = true;
            preview.CurrentTool = VixenPreviewControl.Tools.String;
        }

        public void UpdateColors(Vixen.Sys.ElementNode node, Color newColor)
        {
            preview.UpdateColors(node, newColor);
        }

        private void preview_Load(object sender, EventArgs e)
        {

        }

        public void RefreshPreview()
        {
            preview.Render();
            //preview.DrawDisplayItemsInBackground();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = preview.PixelCount.ToString();
            //toolStripAverageUpdate.Text = "Average: " + Math.Round(VixenPreviewControl.averageUpdateTime).ToString() + "ms";
            toolStripStatusCurrentUpdate.Text = "Last: " + Math.Round(VixenPreviewControl.lastUpdateTime).ToString() + "ms";
            toolStripStatusLastRenderTime.Text = "Render: " + Math.Round(lastRenderTime).ToString() + "ms";
        }

        public void ResetColors()
        {
            preview.ResetColors();
        }

        private void toolStripButtonArch_Click(object sender, EventArgs e)
        {
            toolStripSelect.Checked = false;
            toolStripLightString.Checked = false;
            toolStripButtonArch.Checked = true;
            preview.CurrentTool = VixenPreviewControl.Tools.Arch;
        }

        private void toolStripButtonEditMode_Click(object sender, EventArgs e)
        {
            bool EditMode = !toolStripButtonEditMode.Checked;
            if (EditMode)
            {
                Console.WriteLine("Edit Mode On");
                toolStripButtonEditMode.Checked = true;
            }
            else
            {
                Console.WriteLine("Edit Mode Off");
                toolStripButtonEditMode.Checked = false;
            }
            preview.EditMode = EditMode;
        }

        //double totalRenderTime = 0;
        //double totalRenderCount = 0;
        double lastRenderTime = 0;
        private void timerRenderPreview_Tick(object sender, EventArgs e)
        {
            //timerRenderPreview.Stop();
            
            Stopwatch timer = new Stopwatch();
            timer.Start();
            preview.Render();
            timer.Stop();
            lastRenderTime = timer.ElapsedMilliseconds;
            //totalRenderCount += 1;
            //totalRenderTime += timer.ElapsedMilliseconds;

            //timerRenderPreview.Start();
        }

        public void Setup()
        {
            preview.LoadBackground(Data.BackgroundFileName);
            Top = Data.Top;
            Left = Data.Left;
            Width = Data.Width;
            Height = Data.Height;
        }

        public void Save()
        {
            Data.Top = Top;
            Data.Left = Left;
            Data.Width = Width;
            Data.Height = Height;
        }

        int lightCount = 75;
        int treeStrings = 20;
        int pixelCount = 0;
        private void menuAddStuffToScreen_Click(object sender, EventArgs e)
        {
            int bottomOffset;
            int topOffset;
            int treeHeight;
            int currentBottomX;
            int currentTopX;
            System.Drawing.Point topPoint;
            int startX = 200;

            for (int treeNum = 0; treeNum < 1; treeNum += 2)
            {
                // Tree Set 1
                topPoint = new System.Drawing.Point(startX, 50);
                bottomOffset = 20;
                topOffset = 2;
                treeHeight = 400;
                currentBottomX = topPoint.X - (int)(((treeStrings / 2) - 1) * bottomOffset) - (int)(.5 * bottomOffset);
                currentTopX = topPoint.X - (int)(((treeStrings / 2) - 1) * topOffset) - (int)(.5 * topOffset);
                for (int i = 0; i < treeStrings; i++)
                {
                    DisplayItem displayItem = new DisplayItem();
                    displayItem.Shape = new PreviewLine(new PreviewPoint(currentTopX, topPoint.Y), new PreviewPoint(currentBottomX, topPoint.Y + treeHeight), lightCount, 100);
                    displayItem.Shape.PixelSize = 3;
                    preview.AddDisplayItem(displayItem);
                    pixelCount += displayItem.Shape.Pixels.Count();
                    foreach (PreviewPixel pixel in displayItem.Shape.Pixels)
                    {
                        pixel.Node = GetNextNode();
                    }
                    currentBottomX += bottomOffset;
                    currentTopX += topOffset;
                }
                // Tree Set 1 Upside Down
                topPoint = new System.Drawing.Point(startX + 300, 50);
                bottomOffset = 2;
                topOffset = 20;
                treeHeight = 400;
                currentBottomX = topPoint.X - (int)(((treeStrings / 2) - 1) * bottomOffset) - (int)(.5 * bottomOffset);
                currentTopX = topPoint.X - (int)(((treeStrings / 2) - 1) * topOffset) - (int)(.5 * topOffset);
                for (int i = 0; i < treeStrings; i++)
                {
                    DisplayItem displayItem = new DisplayItem();
                    displayItem.Shape = new PreviewLine(new PreviewPoint(currentTopX, topPoint.Y), new PreviewPoint(currentBottomX, topPoint.Y + treeHeight), lightCount, 100);
                    preview.AddDisplayItem(displayItem);
                    pixelCount += displayItem.Shape.Pixels.Count();
                    foreach (PreviewPixel pixel in displayItem.Shape.Pixels)
                    {
                        pixel.Node = GetNextNode();
                    }
                    currentBottomX += bottomOffset;
                    currentTopX += topOffset;
                }


                //// Tree Set 2
                topPoint = new System.Drawing.Point(startX + 600, 50);
                bottomOffset = 20;
                topOffset = 2;
                treeHeight = 400;
                currentBottomX = topPoint.X - (int)(((treeStrings / 2) - 1) * bottomOffset) - (int)(.5 * bottomOffset);
                currentTopX = topPoint.X - (int)(((treeStrings / 2) - 1) * topOffset) - (int)(.5 * topOffset);
                for (int i = 0; i < treeStrings; i++)
                {
                    DisplayItem displayItem = new DisplayItem();
                    displayItem.Shape = new PreviewLine(new PreviewPoint(currentTopX, topPoint.Y), new PreviewPoint(currentBottomX, topPoint.Y + treeHeight), lightCount, 100);
                    preview.AddDisplayItem(displayItem);
                    pixelCount += displayItem.Shape.Pixels.Count();
                    currentBottomX += bottomOffset;
                    foreach (PreviewPixel pixel in displayItem.Shape.Pixels)
                    {
                        pixel.Node = GetNextNode();
                    }
                    currentTopX += topOffset;
                }
                //// Tree Set 2 Upside Down
                topPoint = new System.Drawing.Point(startX + 900, 50);
                bottomOffset = 2;
                topOffset = 20;
                treeHeight = 400;
                currentBottomX = topPoint.X - (int)(((treeStrings / 2) - 1) * bottomOffset) - (int)(.5 * bottomOffset);
                currentTopX = topPoint.X - (int)(((treeStrings / 2) - 1) * topOffset) - (int)(.5 * topOffset);
                for (int i = 0; i < treeStrings; i++)
                {
                    DisplayItem displayItem = new DisplayItem();
                    displayItem.Shape = new PreviewLine(new PreviewPoint(currentTopX, topPoint.Y), new PreviewPoint(currentBottomX, topPoint.Y + treeHeight), lightCount, 100);
                    preview.AddDisplayItem(displayItem);
                    pixelCount += displayItem.Shape.Pixels.Count();
                    currentBottomX += bottomOffset;
                    foreach (PreviewPixel pixel in displayItem.Shape.Pixels)
                    {
                        pixel.Node = GetNextNode();
                    }
                    currentTopX += topOffset;
                }

                startX += 600;
            }
            Console.WriteLine("Total Pixels: " + pixelCount.ToString());
            toolStripStatusLabel1.Text = "Pixel Count: " + pixelCount.ToString();
        }

        private void toolStripButtonSetBackground_Click(object sender, EventArgs e)
        {
            if (dialogSelectBackground.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Data.BackgroundFileName = dialogSelectBackground.FileName;
                preview.LoadBackground(dialogSelectBackground.FileName);
            }
        }

    }
}
