using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Utils.Hitbox
{
    class HitboxCircle : IHitbox
    {
        public bool Collides(IHitbox _other)
        {
            throw new NotImplementedException();
        }

        public Collision DetailedCollision(CollisionComponent otherCollisionComponent)
        {
            throw new NotImplementedException();
        }
    }
}
