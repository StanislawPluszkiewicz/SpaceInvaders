using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun1 : Gun
    {
        public Gun1(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "01")
        {
        }
    }
}
