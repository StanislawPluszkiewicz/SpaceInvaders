using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    class HitboxAABB : Hitbox
    {
        public Vecteur4 box;

        public HitboxAABB(double top, double bottom, double left, double right)
        {
            box = new Vecteur4(top, bottom, left, right);
        }

        
        public override Collision DetailedCollision(CollisionComponent otherCollisionComponent)
        { // TODO wrong cause both hitbox sizes might vary therefore we can't be sure of the width/height
            Hitbox other = otherCollisionComponent.Hitbox;
            int x, y, width, height;

            if (box.X > other.box.X)
            // Collision from right (relative to this.box)
            {
                x = (int)other.box.X;
                width = (int)box.XPlusWidth;
            }
            else
            // Collision from left
            {
                x = (int)box.X;
                width = (int)other.box.XPlusWidth;
            }

            if (box.Y < other.box.Y)
            // Collision from top
            {
                y = (int)box.Y;
                height = (int)other.box.YPlusHeight;
            }
            else
            // Collision from bottom
            {
                y = (int)other.box.Y;
                height = (int)box.YPlusHeight;
            }

            return new Collision(otherCollisionComponent, new Vecteur4(x, width, y, height));
        }

        public void Update(double top, double bottom, double left, double right)
        {
            this.box.Y = top;
            this.box.YPlusHeight = bottom;
            this.box.X = left;
            this.box.XPlusWidth = right;
        }
    }

    internal class Vecteur4
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
