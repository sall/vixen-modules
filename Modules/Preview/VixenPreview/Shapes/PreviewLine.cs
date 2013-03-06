using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace VixenModules.Preview.VixenPreview.Shapes
{
    [DataContract]
    public class PreviewLine: PreviewBaseShape
    {
        [DataMember]
        private PreviewPoint p1;
        [DataMember]
        private PreviewPoint p2;
        //private int pixelCount;

        private PreviewPoint p1Start, p2Start;

        public PreviewLine(PreviewPoint point1, PreviewPoint point2, int lightCount, double shapeAspect)
        {
            p1 = point1;
            p2 = point2;
            //pixelCount = lightCount;

            //double xSpacing = (double)(p1.X - p2.X) / (double)lightCount;
            //double ySpacing = (double)(p1.Y - p2.Y) / (double)lightCount;
            //double x = p1.X;
            //double y = p1.Y;
            //for (int lightNum = 0; lightNum < lightCount; lightNum++)
            //{
            //    AddPixel((int)Math.Round(x), (int)Math.Round(y), PixelSize);
            //    x -= xSpacing;
            //    y -= ySpacing;
            //}

            // Just add the pixels, they will get layed out next
            for (int lightNum = 0; lightNum < lightCount; lightNum++)
            {
                //Console.WriteLine("Added: " + lightNum.ToString());
                PreviewPixel pixel = AddPixel(10, 10);
                pixel.PixelColor = Color.White;
            }
            // Lay out the pixels
            LayoutLine();

            DoResize += new ResizeEvent(OnResize);
        }

        public int PixelCount
        {
            get { return Pixels.Count; }
            //set { pixelCount = value; }
        }

        public void LayoutLine()
        {
            double xSpacing = (double)(p1.X - p2.X) / (double)(PixelCount-1);
            double ySpacing = (double)(p1.Y - p2.Y) / (double)(PixelCount-1);
            double x = p1.X;
            double y = p1.Y;
            foreach (PreviewPixel pixel in Pixels)
            {
                pixel.X = (int)Math.Round(x);
                pixel.Y = (int)Math.Round(y);
                x -= xSpacing;
                y -= ySpacing;
                //Console.WriteLine(pixel.X.ToString());
            }
        }

        public override void MouseMove(int x, int y, int changeX, int changeY) 
        {
            //Console.WriteLine("MouseMove");
            //p2.X = x;
            //p2.Y = y;
            // See if we're resizing
            if (_selectedPoint != null)
            {
                _selectedPoint.X = x;
                _selectedPoint.Y = y;
                LayoutLine();
                SelectDragPoints();
            }
            // If we get here, we're moving
            else
            {
                p1.X = p1Start.X + changeX;
                p1.Y = p1Start.Y + changeY;
                p2.X = p2Start.X + changeX;
                p2.Y = p2Start.Y + changeY;
                LayoutLine();
            }
        }

        private void OnResize(EventArgs e)
        {
            LayoutLine();
        }

        public override void Select() 
        {
            base.Select();
            SelectDragPoints();
        }

        private void SelectDragPoints()
        {
            List<PreviewPoint> points = new List<PreviewPoint>();
            points.Add(p1);
            points.Add(p2);
            SelectPoints(points);
        }

        public override bool PointInShape(PreviewPoint point)
        {
            foreach (PreviewPixel pixel in Pixels) 
            {
                Rectangle r = new Rectangle(pixel.X - (SelectPointSize / 2), pixel.Y - (SelectPointSize / 2), SelectPointSize, SelectPointSize);
                if (point.X >= r.X && point.X <= r.X + r.Width && point.Y >= r.Y && point.Y <= r.Y + r.Height)
                {
                    return true;
                }
            }
            return false;
        }

        public override void SetSelectPoint(PreviewPoint point)
        {
            if (point == null)
            {
                p1Start = new PreviewPoint(p1.X, p1.Y);
                p2Start = new PreviewPoint(p2.X, p2.Y) ;
            }
            _selectedPoint = point;
        }

        public override void SelectDefaultSelectPoint()
        {
            _selectedPoint = p2;
        }

        public override void PropertyDialog()
        {
            PreviewLineProperties f = new PreviewLineProperties(this);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }


    }
}
