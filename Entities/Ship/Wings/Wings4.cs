using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Wings
{
    class Wings4 : Wings
    {
        public Wings4(CollisionComponent.CollisionTag collisionTag, COLOR color) : base(collisionTag, color, 4)
        {
        }
    }
}
