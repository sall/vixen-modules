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
            set { size = value; }
        }

        [DataMember]
        public Color PixelColor
        {
            get { return color; }
            set
            {
                color = value;
                //if (!PreviewPixel.brushes.TryGetValue(color.ToArgb(), out brush))
                //{
                //    brush = new SolidBrush(color);
                //    PreviewPixel.brushes.Add(color.ToArgb(), brush);
                //}
            }
        }

        public void Draw(Graphics graphics)
        {            
            //graphics.FillRectangle(brush, drawArea);
            if (color != Color.Transparent) 
                graphics.FillEllipse(brush, drawArea);
            //graphics.Fill
        }

        public void Draw(FastPixel fp)
        {
            //fp.SetPixel(drawArea.Left, drawArea.Top, color);

            if (IntentNodeToColor.TryGetValue(Node, out color))
                Draw(fp, color);

            //Object c = IntentNodeToColor[_node];
            //if (c != null)
            //{
            //    Draw(fp, (Color)c);
            //}
        }

        public void Draw(FastPixel fp, Color newColor)
        {
            fp.SetPixel(drawArea.Left, drawArea.Top, newColor);
            fp.SetPixel(drawArea.Left, drawArea.Top+1, newColor);
            fp.SetPixel(drawArea.Left, drawArea.Top, newColor);
            fp.SetPixel(drawArea.Left+1, drawArea.Top, newColor);
        }
    }
}
