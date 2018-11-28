using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    


    abstract class Hitbox
    {

        public List<Vecteur2D> shape;
        public Hitbox()
        {
            shape = new List<Vecteur2D>();
        }
        public static bool Collides(HitboxAABB that, HitboxAABB other)
        {
            return !(
            ((that.box.X > other.box.XPlusWidth) || (that.box.XPlusWidth < other.box.X)) ||
            ((that.box.Y > other.box.YPlusHeight) || (that.box.YPlusHeight < other.box.Y)));

        }
        public Collision DetailedCollision(CollisionComponent otherCollisionComponent)
        {
            if (this is HitboxAABB && otherCollisionComponent.Hitbox is HitboxAABB)
            {
                double x = Math.Max(((HitboxAABB)this).box.X, ((HitboxAABB)otherCollisionComponent.Hitbox).box.X);
                double xw = Math.Min(((HitboxAABB)this).box.XPlusWidth, ((HitboxAABB)otherCollisionComponent.Hitbox).box.XPlusWidth);
                double y = Math.Max(((HitboxAABB)this).box.Y, ((HitboxAABB)otherCollisionComponent.Hitbox).box.Y);
                double yh = Math.Min(((HitboxAABB)this).box.YPlusHeight, ((HitboxAABB)otherCollisionComponent.Hitbox).box.YPlusHeight);

                return new Collision(otherCollisionComponent, new Vecteur4(y, yh, x, xw));
            }else
            {
                throw new NotImplementedException();
            }
        }

    }
}
