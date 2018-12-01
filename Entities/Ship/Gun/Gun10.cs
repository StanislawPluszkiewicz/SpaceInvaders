using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun10 : Gun
    {
        public Gun10(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "10")
        {
        }
    }
}
