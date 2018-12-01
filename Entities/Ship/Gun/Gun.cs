using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Entities.Ship.ShipPart;

namespace SpaceInvaders.Entities.Ship.Gun
{
    class Gun : ShipPart
    {
        protected static readonly int SpriteVariants = 11;
        protected static readonly String imagePath = "../../Resources/PNG/Parts/gun";

        public Gun(CollisionComponent.CollisionTag collisionTag, string variant) : base(GetImage(variant), collisionTag)
        {
        }
        public static Image GetImage(string variant)
        {
            if (Int32.Parse(variant) > SpriteVariants)
            {
                throw new Exception("There are only " + SpriteVariants.ToString() + " gun variants ! (you asked for " + variant.ToString() + ")");
            }
            string filename = imagePath + variant;
            return Image.FromFile(filename);
        }
    }
}

