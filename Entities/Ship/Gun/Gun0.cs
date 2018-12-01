using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun0 : Gun
    {
        public Gun0(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "00")
        {
        }
    }
}
