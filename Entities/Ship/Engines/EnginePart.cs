using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Entities.Ship.ShipPart;


namespace SpaceInvaders.Entities.Ship.Engines
{
    public abstract class EnginePart : ShipPart
    {
        protected static readonly int SpriteVariants = 5;
        protected static readonly string imagePath = "../../Resources/PNG/Parts/engine";
        public EnginePart(int variant) : base(GetImage(variant))
        {
        }

        public EnginePart(Image image) : base(image)
        {
        }

        protected static Image GetImage(int variant)
        {
            if (variant > SpriteVariants)
            {
                throw new Exception("There are only " + SpriteVariants.ToString() + " engine variants ! (you asked for " + variant.ToString() + ")");
            }
            string filename = imagePath + variant.ToString();
            return Image.FromFile(filename);
        }

        public EnginePart Create(int engineVariant)
        {
            switch (engineVariant)
            {
                case 0:
                    return new EnginePartBasic();
                case 1:
                    return new EnginePartAdvanced();
                case 2:
                    return new EnginePartSmall();
                case 3:
                    return new EnginePartBig();
                case 4:
                    return new EnginePartSlow();
                    
                default:
                    throw new Exception("There are only " + SpriteVariants.ToString() + " engine variants ! (you asked for " + engineVariant.ToString() + ")");
            }
        }
    }
}

