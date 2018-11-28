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
        public static Collision DetailedCollision(CollisionComponent thatCollisionComponent, HitboxAABB thatHitbox, CollisionComponent otherCollisionComponent, HitboxAABB otherHitbox)
        {
            return new Collision(otherCollisionComponent, new Vecteur4(Math.Max(thatHitbox.box.X, otherHitbox.box.X),
                Math.Max(thatHitbox.box.Y, thatHitbox.box.Y),
                Math.Max(thatHitbox.box.XPlusWidth, otherHitbox.box.XPlusWidth),
                Math.Max(thatHitbox.box.YPlusHeight, thatHitbox.box.YPlusHeight)));
        }

    }
}
