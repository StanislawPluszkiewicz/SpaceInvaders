using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    class HitboxAABB : Hitbox
    {
        internal enum Direction { TOP=0, RIGHT, LEFT, BOTTOM}
        public Vecteur4 box;

        public HitboxAABB(double top, double bottom, double left, double right)
        {
            box = new Vecteur4(top, bottom, left, right);
        }

        public void Update(double top, double bottom, double left, double right)
        {
            this.box.Y = top;
            this.box.YPlusHeight = bottom;
            this.box.X = left;
            this.box.XPlusWidth = right;
        }
    }

    public class Vecteur4
    {
        public Vecteur4(double y, double yPlusHeight, double x, double xPlusWidth)
        {
            Y = y;
            YPlusHeight = yPlusHeight;
            X = x;
            XPlusWidth = xPlusWidth;
        }

        public double Y { get; set; }
        public double YPlusHeight { get; set; }
        public double X { get; set; }
        public double XPlusWidth { get; set; }
        // not storing height/width for performances (so we don't have to the addition multiple (squared Collidable count) times per frame) 
        // -> instead this is calculated with the hitbox update once per each Collidable per frame
    }
}
