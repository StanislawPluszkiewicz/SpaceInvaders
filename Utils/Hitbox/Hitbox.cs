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
        public static Collision DetailedCollision(CollisionComponent thatCollisionComponent, CollisionComponent otherCollisionComponent)
        {

        }

        public static bool Collides(Hitbox that, Hitbox other)
        {
            if (that is HitboxAABB && other is HitboxAABB)
            {
                Vecteur4 otherBox = ((HitboxAABB)other).box;
                Vecteur4 thatBox = ((HitboxAABB)that).box;
                return !(
                ((thatBox.X > otherBox.XPlusWidth) || (thatBox.XPlusWidth < otherBox.X)) ||
                ((thatBox.Y > otherBox.YPlusHeight) || (thatBox.YPlusHeight < otherBox.Y)));
            }
            else
            {
                throw new NotImplementedException();
            }


        }

    }
}
