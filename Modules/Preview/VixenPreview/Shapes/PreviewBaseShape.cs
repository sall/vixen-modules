using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Vixen.Sys;
using System.Runtime.Serialization;

namespace VixenModules.Preview.VixenPreview.Shapes
{
    [DataContract]
    public abstract class PreviewBaseShape
    {
        //private int top = 0;
        //private int left = 0;
        //private int width = 50;
        //private int height = 50;
        //private double aspect = 1;

        public static Dictionary<ElementNode, List<PreviewPixel>> NodeToPixel = new Dictionary<ElementNode, List<PreviewPixel>>();
        //Hashtable NodeToPixel = new Hashtable();
        //KeyValuePair<ChannelNode, PreviewPixel> NodeToPixel;

        //public Graphics g;

        private bool _selected = false;
        private List<PreviewPoint> _selectPoints = null;
        public const int SelectPointSize = 6;

        private Color _pixelColor = Color.White;
        private int _pixelSize = 2;

        public List<PreviewPixel> _pixels = new List<PreviewPixel>();

        public PreviewPoint _selectedPoint;

        public event ResizeEvent DoResize;
        public delegate void ResizeEvent(EventArgs e);

        //[OnDeserialized]
        //public void OnDeserialized(StreamingContext context)
        //{
        //    ResizePixel();
        //}

        [DataMember]
        public List<PreviewPixel> Pixels
        {
            get { return _pixels; }
            set
            {
                _pixels = value;
                ResetNodeToPixelDictionary();
            }
        }

        public void ResetNodeToPixelDictionary()
        {
            if (PreviewBaseShape.NodeToPixel == null)
            {
                PreviewBaseShape.NodeToPixel = new Dictionary<ElementNode, List<PreviewPixel>>();
                //NodeToPixel = new Hashtable();
            }
            else
            {
                //PreviewBaseShape.NodeToPixel.Clear();
            }
            foreach (PreviewPixel pixel in _pixels)
            {
                if (pixel.Node != null)
                {
                    List<PreviewPixel> pixels;
                    if (PreviewBaseShape.NodeToPixel.TryGetValue(pixel.Node, out pixels)) 
                    {
                        if (!pixels.Contains(pixel))
                        {
                            pixels.Add(pixel);
                            //PreviewBaseShape.NodeToPixel.Add(pixel.Node, pixels);
                        }
                    }
                    else
                    {
                        pixels = new List<PreviewPixel>();
                        pixels.Add(pixel);
                        PreviewBaseShape.NodeToPixel.Add(pixel.Node, pixels);
                    }
                }
            }
        }

        public Color PixelColor
        {
            get { return _pixelColor; }
            set { _pixelColor = value; }
        }

        //public void SetGraphics(Graphics graphics) {
        //    g = graphics;
        //    foreach (PreviewPixel pixel in Pixels) 
        //        pixel.SetGraphics(g);
        //}

        [DataMember]
        public int PixelSize
        {
            get { return _pixelSize; }
            set { 
                _pixelSize = value;
                ResizePixel();
            }
        }

        public void SetPixelNode(int pixelNum, ElementNode node) 
        {
            Pixels[pixelNum].Node = node;
            ResetNodeToPixelDictionary();
        }

        public void SetPixelColor(int pixelNum, Color color) 
        {
            Pixels[pixelNum].PixelColor = color;
        }

        public void SetColor(Color pixelColor)
        {
            foreach (PreviewPixel pixel in Pixels)
                pixel.PixelColor = pixelColor;
        }

        public bool Selected 
        {
            get {return _selected;}
        }

        public virtual void Select()
        {
            _selected = true;
        }

        public virtual void Deselect()
        {
            _selected = false;
            _selectPoints.Clear();
        }

        public void SelectPoints(List<PreviewPoint> selectPoints)
        {
            _selectPoints = selectPoints;
        }

        //public int Top
        //{
        //    get { return top; }
        //    set { 
        //        top = value;
        //        if (DoResize != null) DoResize(new EventArgs());
        //    }
        //}

        //public int Left
        //{
        //    get { return left; }
        //    set { 
        //        left = value;
        //        if (DoResize != null) DoResize(new EventArgs());
        //    }
        //}

        //public int Width
        //{
        //    get { return width; }
        //    set {
        //        width = value;
        //        if (DoResize != null) DoResize(new EventArgs());
        //    }
        //}

        //public int Height
        //{
        //    get { return height; }
        //    set { 
        //        height = value;
        //        if (DoResize != null) DoResize(new EventArgs());
        //    }
        //}

        // Add a pxiel at a specific location
        public PreviewPixel AddPixel(int x, int y)
        {
            PreviewPixel pixel = new PreviewPixel(x, y, PixelSize);
            //pixel.On(pixelColor, 255);
            //pixel.PixelColor = pixelColor;
            pixel.PixelColor = PixelColor;
            Pixels.Add(pixel);
            ResetNodeToPixelDictionary();
            return pixel;
        }

        public void ResizePixel()
        {
            if (Pixels != null)
            {
                foreach (PreviewPixel pixel in Pixels)
                {
                    pixel.PixelSize = PixelSize;
                    pixel.Resize();
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (PreviewPixel pixel in Pixels)
            {
                pixel.Draw(graphics);
            }

            if (_selectPoints != null)
            {
                foreach (PreviewPoint point in _selectPoints)
                {
                    Pen pen = new Pen(Color.White, 1);
                    graphics.DrawRectangle(pen, new Rectangle(point.X - (SelectPointSize / 2), point.Y - (SelectPointSize / 2), SelectPointSize, SelectPointSize));
                }
            }
        }

        public void Draw(FastPixel fp, Color color)
        {
            foreach (PreviewPixel pixel in Pixels)
            {
                pixel.Draw(fp, color);
            }

            if (_selectPoints != null)
            {
                foreach (PreviewPoint point in _selectPoints)
                {
                    fp.DrawRectangle(new Rectangle(point.X - (SelectPointSize / 2), point.Y - (SelectPointSize / 2), SelectPointSize, SelectPointSize), Color.White);
                }
            }
        }
        
        public void Draw(FastPixel fp)
        {
            foreach (PreviewPixel pixel in Pixels)
            {
                pixel.Draw(fp);
            }

            if (_selectPoints != null)
            {
                foreach (PreviewPoint point in _selectPoints)
                {
                    fp.DrawRectangle(new Rectangle(point.X - (SelectPointSize / 2), point.Y - (SelectPointSize / 2), SelectPointSize, SelectPointSize), Color.White);
                }
            }
        }

        public abstract void MouseMove(int x, int y, int changeX, int changeY);

        public abstract bool PointInShape(PreviewPoint point);

        public PreviewPoint PointInSelectPoint(PreviewPoint point)
        {
            foreach (PreviewPoint selectPoint in _selectPoints)
            {
                if (point.X >= selectPoint.X - (SelectPointSize / 2) &&
                    point.Y >= selectPoint.Y - (SelectPointSize / 2) &&
                    point.X <= selectPoint.X + (SelectPointSize / 2) &&
                    point.Y <= selectPoint.Y + (SelectPointSize / 2))
                {
                    return selectPoint;
                }
            }
            return null;
        }

        public abstract void SetSelectPoint(PreviewPoint point = null);

        public abstract void SelectDefaultSelectPoint();

        public abstract void PropertyDialog();

        public void UpdateColors(ElementNode node, Color newColor)
        {
            //if (NodeToPixel.ContainsKey(node))
            //{
            //    PreviewPixel pixel = NodeToPixel[node];
            //    if (pixel != null)
            //        pixel.PixelColor = newColor;
            //}

            PreviewPixel pixel;
            //if (PreviewBaseShape.NodeToPixel.TryGetValue(node, out pixel))
            //    pixel.PixelColor = newColor;

            //PreviewPixel pixel = NodeToPixel[node] as PreviewPixel;
            //if (pixel != null)
            //    pixel.PixelColor = newColor;
            //_pixels[0].PixelColor = newColor;
        }

    }
}
