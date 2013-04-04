﻿using System;
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
        private PointTypes _pointType = PointTypes.None;
        public enum PointTypes
        {
            None,
            Size,
            SkewNS,
            SkewWE
        }

        public PointTypes PointType
        {
            get { return _pointType; }
            set { _pointType = value; }
        }

        public PreviewPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public PreviewPoint(PreviewPoint pointToClone)
        {
            _x = pointToClone.X;
            _y = pointToClone.Y;
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