using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities.Ship
{
    public class Ship : Collidable
    {
        public Ship(Image image, CollisionTag collisionTag) : base(image, collisionTag)
        {

        }
    }
}
