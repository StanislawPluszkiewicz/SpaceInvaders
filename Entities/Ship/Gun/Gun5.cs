using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun5 : Gun
    {
        public Gun5(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "05")
        {
        }
    }
}
