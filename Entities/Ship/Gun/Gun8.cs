using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun8 : Gun
    {
        public Gun8(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "08")
        {
        }
    }
}
