using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    public struct Vecteur4
    {
        public double top;
        public double bottom;
        public double left;
        public double right;
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
                ((box.left > other.box.right) || (box.right <  other.box.left)) || 
                ((box.top > other.box.bottom) || (box.bottom < other.box.top)));
        }

        public void Update(double top, double bottom, double left, double right)
        {
            this.box.top = top;
            this.box.bottom = bottom;
            this.box.left = left;
            this.box.right = right;
        }
    }
}
