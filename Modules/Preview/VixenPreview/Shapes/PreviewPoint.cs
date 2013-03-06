using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace VixenModules.Preview.VixenPreview.Shapes
{
    [DataContract]
    public class PreviewPoint
    {
        int _x = 0;
        int _y = 0;

        public PreviewPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

        [DataMember]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        [DataMember]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
