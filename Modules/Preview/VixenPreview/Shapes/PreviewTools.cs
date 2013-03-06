using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VixenModules.Preview.VixenPreview.Shapes
{
    class PreviewTools
    {

        static double Perimeter(PreviewPoint p1, PreviewPoint p2) 
        {
            double p;
            double a;
            double b;
            a = Math.Abs(p2.Y - p1.Y);
            b = Math.Abs(p2.X - p1.X);
            p = Math.PI * ((3 * (a + b)) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
            return p;
        }
    }
}
