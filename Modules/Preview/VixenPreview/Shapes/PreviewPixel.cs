using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using Vixen.Execution.Context;
using Vixen.Module.Preview;
using Vixen.Data.Value;
using Vixen.Sys;
using VixenModules.Preview.VixenPreview.Shapes;


namespace VixenModules.Preview.VixenPreview.Shapes
{
    [DataContract]
    public class PreviewPixel
    {
        private Color color = Color.White;
        private Brush brush;
        private int x = 0;
        private int y = 0;
        private int size = 3;
        private Rectangle drawArea;
        private ElementNode _node = null;
        private Guid _nodeId;
        private int _maxAlpha = 255;

        //static Hashtable brushes = new Hashtable();
        //static Dictionary<Int32, Brush> brushes = new Dictionary<Int32, Brush>();

        //public static Hashtable IntentNodeToColor = new Hashtable();
        public static Dictionary<ElementNode, Color> IntentNodeToColor = new Dictionary<ElementNode, Color>();

        public PreviewPixel(int xPosition, int yPositoin, int pixelSize)
        {
            x = xPosition;
            y = yPositoin;
            size = pixelSize;
            brush = new SolidBrush(Color.White);
            Resize();
        }

        [DataMember]
        public int MaxAlpha
        {
            get 
            {
                if (_maxAlpha == 0)
                    _maxAlpha = 255;
                return _maxAlpha; 
            }
            set { _maxAlpha = value; }
        }

        [DataMember]
        public Guid NodeId
        {
            get {
                return _nodeId; 
            }
            set {
                _nodeId = value;
            }
        }

        public ElementNode Node
        {
            get 
            {
                if (_node == null)
                {
                    _node = VixenSystem.Nodes.GetElementNode(NodeId);
                }
                return _node; 
            }
            set
            {
                if (value == null)
                    NodeId = Guid.Empty;
                else
                    NodeId = value.Id;
                _node = value;
            }
        }

        //public void SetGraphics(Graphics Graphics)
        //{
        //    g = Graphics;
        //}

        public void Resize()
        {
            drawArea = new Rectangle(x, y, size, size);
        }

        [DataMember]
        public int X
        {
            get { return x; }
            set { 
                x = value;
                Resize();
            }
        }

        [DataMember]
        public int Y
        {
            get { return y; }
            set { 
                y = value;
                Resize();
            }
        }

        [DataMember]
        public int PixelSize
        {
            get { return size; }
            set { 
                size = value;
                Resize();

            }
        }

        [DataMember]
        public Color PixelColor
        {
            get { return color; }
            set
            {
                color = value;
            }
        }

        public void Draw(Graphics graphics)
        {            
            if (color != Color.Transparent) 
                graphics.FillEllipse(brush, drawArea);
        }

        public void Draw(FastPixel fp)
        {
            if (Node != null)
            {
                if (IntentNodeToColor.TryGetValue(Node, out color))
                {
                    Draw(fp, color);
                }
            }
        }

        public void Draw(FastPixel fp, Color newColor)
        {
            if (newColor.A > 0)
            {
                if (PixelSize <= 3)
                {
                    fp.SetPixel(drawArea.Left, drawArea.Top, newColor);
                    fp.SetPixel(drawArea.Left, drawArea.Top + 1, newColor);
                    fp.SetPixel(drawArea.Left, drawArea.Top, newColor);
                    fp.SetPixel(drawArea.Left + 1, drawArea.Top, newColor);
                }
                else
                {
                    if (MaxAlpha != 255)
                    {
                        double newAlpha = ((double)newColor.A / 255) * (double)MaxAlpha;
                        Color outColor = Color.FromArgb((int)newAlpha, newColor.R, newColor.G, newColor.B);
                        fp.DrawCircle(drawArea, outColor);
                    }
                    else
                    {
                        fp.DrawCircle(drawArea, newColor);
                    }
                }
            }
        }
    }
}
