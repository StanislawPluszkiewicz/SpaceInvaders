using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun4 : Gun
    {
        public Gun4(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "04")
        {
        }
    }
}
