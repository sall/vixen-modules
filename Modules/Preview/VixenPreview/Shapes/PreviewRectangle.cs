//
// ToDo: Property Dialog
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace VixenModules.Preview.VixenPreview.Shapes
{
    [DataContract]
    public class PreviewRectangle: PreviewBaseShape
    {
        [DataMember]
        private PreviewPoint p1;
        [DataMember]
        private PreviewPoint p2;
        [DataMember]
        private PreviewPoint p3;
        [DataMember]
        private PreviewPoint p4;

        private bool lockXY = false;

        [DataMember]
        private int lightCountX1;
        [DataMember]
        private int lightCountX2;
        [DataMember]
        private int lightCountY1;
        [DataMember]
        private int lightCountY2;


        private PreviewPoint p1Start, p2Start, p3Start, p4Start;

        public PreviewRectangle(PreviewPoint point1)
        {
            p1 = point1;
            p2 = new PreviewPoint(p1.X, p1.Y);
            p3 = new PreviewPoint(p1.X, p1.Y);
            p4 = new PreviewPoint(p1.X, p1.Y);

            lightCountX1 = 10;
            lightCountX2 = 10;
            lightCountY1 = 10;
            lightCountY2 = 10;

            int totalLights = lightCountX1 + lightCountX2 + lightCountY1 + lightCountY2;

            // Just add the pixels, they will get layed out next
            for (int lightNum = 0; lightNum < totalLights; lightNum++)
            {
                PreviewPixel pixel = AddPixel(20, 20);
                pixel.PixelColor = Color.White;
            }
            // Lay out the pixels
            Layout();

            DoResize += new ResizeEvent(OnResize);
        }

        public int PixelCount
        {
            get { return Pixels.Count; }
        }

        public void Layout()
        {
            double x, y = 0;
            //Top
            double X1XSpacing = (double)(p1.X - p2.X) / (double)(lightCountX1 + 1);
            double X1YSpacing = (double)(p1.Y - p2.Y) / (double)(lightCountX1 + 1);
            //Bottom
            double X2XSpacing = (double)(p3.X - p4.X) / (double)(lightCountX2 + 1);
            double X2YSpacing = (double)(p3.Y - p4.Y) / (double)(lightCountX1 + 1);
            //Left
            double Y1XSpacing = (double)(p4.X - p1.X) / (double)(lightCountY1 + 1);
            double Y1YSpacing = (double)(p4.Y - p1.Y) / (double)(lightCountY1 + 1);
            //Right
            double Y2XSpacing = (double)(p2.X - p3.X) / (double)(lightCountY2 + 1);
            double Y2YSpacing = (double)(p2.Y - p3.Y) / (double)(lightCountY2 + 1);

            int currentPixel = 0;

            //Top
            x = p1.X - X1XSpacing;
            y = p1.Y - X1YSpacing;
            for (int i = 0; i < lightCountX1; i++)
            {
                Pixels[currentPixel].X = (int)Math.Round(x);
                Pixels[currentPixel].Y = (int)Math.Round(y);
                x -= X1XSpacing;
                y -= X1YSpacing;
                currentPixel++;
            }

            //Right
            x = p2.X - Y2XSpacing;
            y = p2.Y - Y2YSpacing;
            for (int i = 0; i < lightCountY1; i++)
            {
                Pixels[currentPixel].X = (int)Math.Round(x);
                Pixels[currentPixel].Y = (int)Math.Round(y);
                x -= Y2XSpacing;
                y -= Y2YSpacing;
                currentPixel++;
            }

            //Bottom
            x = p3.X - X2XSpacing;
            y = p3.Y - X2YSpacing;
            for (int i = 0; i < lightCountX2; i++)
            {
                Pixels[currentPixel].X = (int)Math.Round(x);
                Pixels[currentPixel].Y = (int)Math.Round(y);
                x -= X2XSpacing;
                y -= X2YSpacing;
                currentPixel++;
            }

            // Left
            x = p4.X - Y1XSpacing;
            y = p4.Y - Y1YSpacing;
            for (int i = 0; i < lightCountY1; i++)
            {
                Pixels[currentPixel].X = (int)Math.Round(x);
                Pixels[currentPixel].Y = (int)Math.Round(y);
                x -= Y1XSpacing;
                y -= Y1YSpacing;
                currentPixel++;
            }
        }

        public override void MouseMove(int x, int y, int changeX, int changeY) 
        {
            if (_selectedPoint != null)
            {
                _selectedPoint.X = x;
                _selectedPoint.Y = y;

                if (lockXY)
                {
                    p2.X = x;
                    p4.Y = y;
                }

                Layout();
                SelectDragPoints();
            }
            // If we get here, we're moving
            else
            {
                p1.X = p1Start.X + changeX;
                p1.Y = p1Start.Y + changeY;
                p2.X = p2Start.X + changeX;
                p2.Y = p2Start.Y + changeY;
                p3.X = p3Start.X + changeX;
                p3.Y = p3Start.Y + changeY;
                p4.X = p4Start.X + changeX;
                p4.Y = p4Start.Y + changeY;
                Layout();
            }
        }

        private void OnResize(EventArgs e)
        {
            Layout();
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
            points.Add(p3);
            points.Add(p4);
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
            lockXY = false;

            if (point == null)
            {
                p1Start = new PreviewPoint(p1.X, p1.Y);
                p2Start = new PreviewPoint(p2.X, p2.Y) ;
                p3Start = new PreviewPoint(p3.X, p3.Y);
                p4Start = new PreviewPoint(p4.X, p4.Y);
            }
            _selectedPoint = point;
        }

        public override void SelectDefaultSelectPoint()
        {
            _selectedPoint = p3;
            lockXY = true;
        }

        public override void PropertyDialog()
        {
            //PreviewLineProperties f = new PreviewLineProperties(this);
            //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{

            //}
        }


    }
}
