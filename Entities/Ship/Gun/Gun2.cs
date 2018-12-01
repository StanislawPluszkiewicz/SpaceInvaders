using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun2 : Gun
    {
        public Gun2(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "02")
        {
        }
    }
}
