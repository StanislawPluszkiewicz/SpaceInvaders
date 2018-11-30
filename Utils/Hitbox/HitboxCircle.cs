using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Utils.Hitbox
{
    class HitboxCircle : IHitbox
    {
        public Vector2 center;

        public Vector2 Position
        {
            get
            {
                return new Vector2(center.x, center.y);
            }
            set
            {
                center.x = value.x;
                center.y = value.y;
            }
        }
        public bool Collides(IHitbox _other)
        {
            throw new NotImplementedException();
        }

        public Collision DetailedCollision(IHitbox other)
        {
            throw new NotImplementedException();
        }
    }
}
