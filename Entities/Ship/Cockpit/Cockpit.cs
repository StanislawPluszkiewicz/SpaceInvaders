using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Cockpit
{
    abstract class Cockpit : ShipPart
    {
        protected static readonly int SpriteVariants = 8;
        protected static readonly String imagePath = "../../Resources/PNG/Parts/cockpit";

        public Cockpit(CollisionComponent.CollisionTag collisionTag, COLOR color, int variant) : base(GetImage(color, variant), collisionTag)
        {
        }

        public static Image GetImage(COLOR color, int variant)
        {
            if (variant > SpriteVariants)
            {
                throw new Exception("There are only " + Cockpit.SpriteVariants.ToString() + " cockpit variants ! (you asked for " + variant.ToString() + ")");
            }
            return Image.FromFile(Cockpit.imagePath + ShipPart.ColorNames[(int)color] + "_" + variant);
        }
    }
}
