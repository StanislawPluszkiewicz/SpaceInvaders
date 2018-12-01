using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun3 : Gun
    {
        public Gun3(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, "03")
        {
        }
    }
}
