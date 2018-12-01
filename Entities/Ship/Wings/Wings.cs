using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Entities.Ship.ShipPart;

namespace SpaceInvaders.Entities.Ship.Wings
{
    class Wings : ShipPart
    {
        protected static readonly int SpriteVariants = 8;
        protected static readonly String imagePath = "../../Resources/PNG/Parts/wing";

        public Wings(CollisionComponent.CollisionTag collisionTag, COLOR color, int variant) : base(GetImage(color, variant), collisionTag)
        {
        }

        public static Image GetImage(COLOR color, int variant)
        {
            if (variant > SpriteVariants)
            {
                throw new Exception("There are only "+ Wings.SpriteVariants.ToString() +" wings variants ! (you asked for " + variant.ToString() + ")");
            }
            string filename = Wings.imagePath + ShipPart.ColorNames[(int)color] + "_" + variant;
            return Image.FromFile(filename);
        }
    }
}
