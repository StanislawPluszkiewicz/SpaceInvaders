using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Wings
{
    class Wings7 : Wings
    {
        public Wings7(CollisionComponent.CollisionTag collisionTag, COLOR color) : base(collisionTag, color, 7)
        {
        }
    }
}
