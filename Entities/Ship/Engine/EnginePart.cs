using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Entities.Ship.ShipPart;


namespace SpaceInvaders.Entities.Ship.Engine
{
    class EnginePart : ShipPart
    {
        protected static readonly int SpriteVariants = 8;
        protected static readonly string imagePath = "../../Resources/PNG/Parts/engine";
        public EnginePart(CollisionComponent.CollisionTag collisionTag, int variant) : base(GetImage(variant), collisionTag)
        {
        }
        public static Image GetImage(int variant)
        {
            if (variant > SpriteVariants)
            {
                throw new Exception("There are only " + SpriteVariants.ToString() + " engine variants ! (you asked for " + variant.ToString() + ")");
            }
            string filename = imagePath + variant;
            return Image.FromFile(filename);
        }
    }
}

