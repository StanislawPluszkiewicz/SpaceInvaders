using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using SpaceInvaders.Entities;

namespace SpaceInvaders.Entities.Ship
{

    abstract class ShipPart : Collidable
    {

        public enum COLOR { BLUE = 0, GREEN, RED, YELLOW };
        protected static readonly String[] ColorNames = { "Blue", "Green", "Red", "Yellow" };

        public ShipPart(Image image, CollisionComponent.CollisionTag collisionTag) : base(image, collisionTag)
        {
        }

    }
}
