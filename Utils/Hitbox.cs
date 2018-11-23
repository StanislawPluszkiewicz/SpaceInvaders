using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    public struct Vecteur4
    {
        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
    }


    class Hitbox
    {
        public Vecteur4 box;

        public Hitbox(double top, double bottom, double left, double right)
        {
            this.box = new Vecteur4();
            Update(top, bottom, left, right);
        }

        public bool Collides(Hitbox other)
        {

            return !(
                ((box.Left > other.box.Right) || (box.Right <  other.box.Left)) || 
                ((box.Top > other.box.Bottom) || (box.Bottom < other.box.Top)));
        }

        public void Update(double top, double bottom, double left, double right)
        {
            this.box.Top = top;
            this.box.Bottom = bottom;
            this.box.Left = left;
            this.box.Right = right;
        }
    }
}
