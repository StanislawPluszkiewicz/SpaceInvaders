using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Entities.Ship.Cockpits;

namespace SpaceInvaders.Entities.Ship
{

    public abstract class ShipPart : Renderable
    {

        public enum COLOR { BLUE = 0, GREEN, RED, YELLOW };
        protected static readonly String[] ColorNames = { "Blue", "Green", "Red", "Yellow" };

        public ShipPart(Image image) : base(image)
        {
        }

    }
}
