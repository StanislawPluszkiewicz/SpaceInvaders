using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Cockpit
{
    class CockpitCarre : Cockpit
    {
        public CockpitCarre(CollisionComponent.CollisionTag collisionTag, COLOR color) : base(collisionTag, color, 4)
        {
        }
    }
}
