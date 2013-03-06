using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Controls.ColorManagement.ColorModels;
using Vixen.Data.Value;
using System.Runtime.Serialization;


namespace VixenModules.Preview.VixenPreview.Shapes
{
    [DataContract]
    [KnownType(typeof(PreviewLine))]
    public class DisplayItem
    {
        private PreviewBaseShape _shape;

        public DisplayItem()
        {
            _shape = new PreviewLine(new PreviewPoint(1, 1), new PreviewPoint(100, 100), 25, 100);
        }

        [DataMember]
        public PreviewBaseShape Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        public void ResetColors(bool isRunning)
        {
            Shape.ResetNodeToPixelDictionary();
        }
    }
}
