using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Wings
{
    class Wings5 : Wings
    {
        public Wings5(CollisionComponent.CollisionTag collisionTag, COLOR color) : base(collisionTag, color, 5)
        {
        }
    }
}
