using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.GeometricForms
{
    public class AxisAlignedBoundedBox : OrientedBoundedBox
    {
        public AxisAlignedBoundedBox(double x, double width, double y, double height) 
            : base(new Vector2(x, y), new Vector2(x + width, y), new Vector2(x, y + height), new Vector2(x + width, y + height))
        {
            this.y = y;
            Height = height;
            this.x = x;
            Width = width;
        }

        public double x { get; set; }
        public double Width { get; set; }
        public double y { get; set; }
        public double Height { get; set; }
    }
}
