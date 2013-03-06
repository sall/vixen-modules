using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VixenModules.Preview.VixenPreview.Shapes;
using Vixen.Sys;
using System.Runtime.Serialization;
using Common.Controls.ColorManagement.ColorModels;
using Vixen.Module;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VixenModules.Preview.VixenPreview
{
    public partial class VixenPreviewControl : UserControl
    {
        private BufferedGraphicsContext context;
        private BufferedGraphics bufferedGraphics;
        public static double averageUpdateTime = 0;
        public static double updateCount = 0;
        public static double totalUpdateTime = 0;
        public static double lastUpdateTime = 0;

        //public static HashSet<PreviewPixel> changedPixels = new HashSet<PreviewPixel>();

        private Tools _currentTool = Tools.Select;
        public enum Tools
        {
            Select,
            String,
            Arch
        }

        //private List<PreviewBaseShape> _displayItems = new List<PreviewBaseShape>();
        private Random random = new Random();
        //private DateTime startTime = new DateTime();

        //private List<PreviewBaseShape> selectedDisplayItems = new List<PreviewBaseShape>();
        private List<DisplayItem> selectedDisplayItems = new List<DisplayItem>();
        private Point dragStart;
        private Point dragCurrent;
        private int changeX;
        private int changeY;
        //private PreviewBaseShape selectedDisplayItem = null;
        private DisplayItem selectedDisplayItem = null;
        private bool _editMode = false;

        private Image _background;

        private VixenPreviewData _data;

        public bool EditMode
        {
            set { _editMode = value; }
            get { return _editMode; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VixenPreviewData Data
        {
            get
            {
                if (DesignMode)
                    _data = new VixenPreviewData();
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        private List<DisplayItem> DisplayItems
        {
            get {
                if (Data != null)
                {
                    return Data.DisplayItems;
                }
                else
                {
                    return null;
                }
            }
        }

        public int PixelCount
        {
            get
            {
                int count = 0;
                foreach (DisplayItem displayItem in DisplayItems)
                {
                    count += displayItem.Shape.Pixels.Count;
                }
                return count;
            }
        }

        public VixenPreviewControl() : base()
        {
            InitializeComponent();

            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            context = BufferedGraphicsManager.Current;
            AllocateGraphicsBuffer();
            //context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            //bufferedGraphics = context.Allocate(this.CreateGraphics(),
            //        new Rectangle(0, 0, this.Width, this.Height));
        }

        private void VixenPreviewControl_Load(object sender, EventArgs e)
        {
            InitializeGraphics();
            //StartRefresh();
        }

        public void LoadBackground(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                try
                {
                    _background = Image.FromFile(fileName);
                }
                catch (Exception ex)
                {
                    _background = new Bitmap(640, 480);
                    MessageBox.Show("There was an error loading the background image: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                _background = new Bitmap(640, 480);
            }
        }

        private void InitializeGraphics()
        {
            context = BufferedGraphicsManager.Current;
            AllocateGraphicsBuffer();
        }

        private void AllocateGraphicsBuffer()
        {
            if (context != null)
            {
                context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

                if (bufferedGraphics != null)
                {
                    lock (bufferedGraphics)
                    {
                        bufferedGraphics.Dispose();
                        bufferedGraphics = null;
                        bufferedGraphics = context.Allocate(this.CreateGraphics(),
                            new Rectangle(0, 0, this.Width + 1, this.Height + 1));
                    }
                }
                else
                {
                    bufferedGraphics = context.Allocate(this.CreateGraphics(),
                    new Rectangle(0, 0, this.Width + 1, this.Height + 1));
                }
            }
        }

        public void AddDisplayItem(DisplayItem displayItem)
        {
            DisplayItems.Add(displayItem);
        }

        private bool _mouseCaptured = false;
        private void VixenPreviewControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PreviewPoint point = new PreviewPoint(e.X, e.Y);

                if (_currentTool == Tools.Select)
                {
                    if (selectedDisplayItem != null)
                    {
                        // Lets see if we've got a drag point.
                        PreviewPoint selectedPoint = selectedDisplayItem.Shape.PointInSelectPoint(point);
                        if (selectedPoint != null)
                        {
                            //selectedDisplayItem.SetSelectPoint(point);
                            dragStart.X = e.X;
                            dragStart.Y = e.Y;
                            selectedDisplayItem.Shape.SetSelectPoint(selectedPoint);
                            Capture = true;
                            _mouseCaptured = true;
                        }
                        // If we're not resizing, see if we're moving
                        else if (selectedDisplayItem.Shape.PointInShape(point))
                        {
                            dragStart.X = e.X;
                            dragStart.Y = e.Y;
                            selectedDisplayItem.Shape.SetSelectPoint(null);
                            Capture = true;
                            _mouseCaptured = true;
                        }
                        // If we get this far, we're off the shape, deselect it!
                        else
                        {
                            //Console.WriteLine("Deselect");
                            selectedDisplayItem.Shape.Deselect();
                            selectedDisplayItem = null;
                            //Invalidate();
                        }
                    }
                    
                    if (!_mouseCaptured)
                    {
                        selectedDisplayItem = DisplayItemAtPoint(point);
                        if (selectedDisplayItem != null)
                        {
                            selectedDisplayItem.Shape.Select();
                        }
                        //Invalidate();
                        //_mouseCaptured = true;
                    }

                    //foreach (PreviewBaseShape displayItem in displayItems)
                    //{
                    //    if (displayItem.PointInShape(point))
                    //    {
                    //        selectedDisplayItem = displayItem;
                    //        selectedDisplayItem.Select();
                    //        Invalidate();
                    //        break;
                    //    }
                    //}
                }
                else if (_currentTool == Tools.String)
                {

                    //if we get here and no displayItem, we need to see if a toolbar button is selected -- and add a shape
                    //if (selectedDisplayItem == null)
                    //{
                    DisplayItem newDisplayItem = new DisplayItem();
                    newDisplayItem.Shape = new PreviewLine(new PreviewPoint(e.X, e.Y), new PreviewPoint(e.X, e.Y), 50, 100);
                    AddDisplayItem(newDisplayItem);
                    selectedDisplayItem = newDisplayItem;
                    selectedDisplayItem.Shape.PixelSize = 3;
                    selectedDisplayItem.Shape.Select();
                    selectedDisplayItem.Shape.SelectDefaultSelectPoint();
                    dragStart.X = e.X;
                    dragStart.Y = e.Y;
                    Capture = true;
                    _mouseCaptured = true;
                    //}
                }
                else if (_currentTool == Tools.Arch)
                {
                    DisplayItem newDisplayItem = new DisplayItem();
                    newDisplayItem.Shape = new PreviewArch(new PreviewPoint(e.X, e.Y), new PreviewPoint(e.X, e.Y), 50, 100);
                    AddDisplayItem(newDisplayItem);
                    selectedDisplayItem = newDisplayItem;
                    selectedDisplayItem.Shape.PixelSize = 3;
                    selectedDisplayItem.Shape.Select();
                    selectedDisplayItem.Shape.SelectDefaultSelectPoint();
                    dragStart.X = e.X;
                    dragStart.Y = e.Y;
                    Capture = true;
                    _mouseCaptured = true;
                    //}
                }
            }
        }

        private void VixenPreviewControl_MouseMove(object sender, MouseEventArgs e)
        {
            PreviewPoint point = new PreviewPoint(e.X, e.Y);

            if (_mouseCaptured)
            {
                dragCurrent.X = e.X;
                dragCurrent.Y = e.Y;
                changeX = e.X - dragStart.X;
                changeY = e.Y - dragStart.Y;

                // if we've got a selected point, we're resizing
                //if (selectedDisplayItem.Shape._selectedPoint != null)
                //{
                    selectedDisplayItem.Shape.MouseMove(dragCurrent.X, dragCurrent.Y, changeX, changeY);
                //}
                // if we get here, we're moving
                //else
                //{
                //}

                //Invalidate();
            }
            else
            {
                if (selectedDisplayItem != null)
                {
                    PreviewPoint selectPoint = selectedDisplayItem.Shape.PointInSelectPoint(point);
                    if (selectPoint != null)
                    {
                        Cursor.Current = Cursors.Cross;
                    }
                    else if (selectedDisplayItem.Shape.PointInShape(point))
                    {
                        Cursor.Current = Cursors.SizeAll;
                    } 
                    else 
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void VixenPreviewControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mouseCaptured)
            {
                Capture = false;
                _mouseCaptured = false;
                if (_currentTool != Tools.Select)
                {
                    _currentTool = Tools.Select;
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                PreviewPoint point = new PreviewPoint(e.X, e.Y);

                DisplayItem displayItem = DisplayItemAtPoint(point);
                if (displayItem != null)
                {
                    displayItem.Shape.PropertyDialog();
                }
            }
        }

        public DisplayItem DisplayItemAtPoint(PreviewPoint point) 
        {
            foreach (DisplayItem displayItem in DisplayItems)
            {
                if (displayItem.Shape.PointInShape(point))
                {
                    return displayItem;
                }
            }
            return null;
        }

        public Tools CurrentTool
        {
            get { return _currentTool; }
            set
            {
                _currentTool = value;
                if (selectedDisplayItem != null)
                {
                    selectedDisplayItem.Shape.Deselect();
                    selectedDisplayItem = null;
                }
            }
        }

        private void VixenPreviewControl_Resize(object sender, EventArgs e)
        {
                //// Re-create the graphics buffer for a new window size.
                //context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
                //if (bufferedGraphics != null)
                //{
                //    bufferedGraphics.Dispose();
                //    bufferedGraphics = null;
                //}
                //bufferedGraphics = context.Allocate(this.CreateGraphics(),
                //    new Rectangle(0, 0, this.Width, this.Height));
            AllocateGraphicsBuffer();
        }

        private void VixenPreviewControl_SizeChanged(object sender, EventArgs e)
        {
        }

        private void VixenPreviewControl_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void VixenPreviewControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (selectedDisplayItem != null)
                {
                    DisplayItems.Remove(selectedDisplayItem);
                }
            }
        }

        public void DrawDisplayItemsInBackground()
        {
            //Thread drawThread = new Thread(() => DrawDisplayItems(bufferedGraphics.Graphics));
            //drawThread.Start();
        }

        private void RenderInBackground()
        {
            if (bufferedGraphics != null && !this.IsDisposed)
            {
                //lock (bufferedGraphics) 
                bufferedGraphics.Render(Graphics.FromHwnd(this.Handle));
            }
        }

        public void UpdateColors(ElementNode node, Color newColor)
        {
            List<PreviewPixel> pixels;
            if (PreviewBaseShape.NodeToPixel.TryGetValue(node, out pixels))
            {
                foreach (PreviewPixel pixel in pixels)
                {
                    pixel.PixelColor = newColor;
                }
            }
        }

        public void ResetColors()
        {
            foreach (List<PreviewPixel> pixels in PreviewBaseShape.NodeToPixel.Values)
            {
                foreach (PreviewPixel pixel in pixels)
                {
                    if (_editMode)
                    {
                        pixel.PixelColor = Color.White;
                    }
                    else
                    {
                        pixel.PixelColor = Color.Transparent;
                    }
                }
            }
        }

        public void Render()
        {
            FastPixel fp = new FastPixel(_background.Width, _background.Height);
            fp.Lock();
            foreach (DisplayItem displayItem in DisplayItems)
            {
                displayItem.Shape.Draw(fp);
            }
            fp.Unlock(true);

            // First, draw our background image opaque
            bufferedGraphics.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            bufferedGraphics.Graphics.DrawImage(_background, 0, 0, _background.Width, _background.Height);
            // Now, draw our "pixel" image using alpha blending
            bufferedGraphics.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            bufferedGraphics.Graphics.DrawImage(fp.Bitmap, 0, 0, fp.Width, fp.Height);

            bufferedGraphics.Render(Graphics.FromHwnd(this.Handle));
        }

        Action<object> action = (object obj) =>
        {
            //Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, obj.ToString(), Thread.CurrentThread.ManagedThreadId);
            //foreach (PreviewPixel pixel in changedPixels)
            //{
            //}
        };
    }
}
