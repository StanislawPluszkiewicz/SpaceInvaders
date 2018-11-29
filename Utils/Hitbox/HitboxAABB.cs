using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    class HitboxAABB : IHitbox
    {
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

        public bool Collides(IHitbox _other)
        {
            if (_other is HitboxAABB)
            {
                HitboxAABB other = _other as HitboxAABB;
                return !(
                ((box.X > other.box.XPlusWidth) || (box.XPlusWidth<other.box.X)) ||
                ((box.Y > other.box.YPlusHeight) || (box.YPlusHeight<other.box.Y)));
            }
            throw new NotImplementedException();

        }

        public new Collision DetailedCollision(CollisionComponent otherCollisionComponent)
        {
            if (otherCollisionComponent.Hitbox is HitboxAABB)
            {
                double x = Math.Max(((HitboxAABB)this).box.X, ((HitboxAABB)otherCollisionComponent.Hitbox).box.X);
                double xw = Math.Min(((HitboxAABB)this).box.XPlusWidth, ((HitboxAABB)otherCollisionComponent.Hitbox).box.XPlusWidth);
                double y = Math.Max(((HitboxAABB)this).box.Y, ((HitboxAABB)otherCollisionComponent.Hitbox).box.Y);
                double yh = Math.Min(((HitboxAABB)this).box.YPlusHeight, ((HitboxAABB)otherCollisionComponent.Hitbox).box.YPlusHeight);

                return new Collision(otherCollisionComponent, new Vecteur4(y, yh, x, xw));
            }
            else
            {
                throw new NotImplementedException();
            }
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
