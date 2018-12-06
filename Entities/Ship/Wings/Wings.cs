using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Entities.Ship.ShipPart;

namespace SpaceInvaders.Entities.Ship.Wings
{
    public class WingsPart : ShipPart
    {
        protected static readonly int SpriteVariants = 8;
        protected static readonly String imagePath = "../../Resources/PNG/Parts/wing";

        public WingsPart(COLOR color, int variant) : base(GetImage(color, variant))
        {
        }

        protected static Image GetImage(COLOR color, int variant)
        {
            if (variant > SpriteVariants)
            {
                throw new Exception("There are only "+ WingsPart.SpriteVariants.ToString() +" wings variants ! (you asked for " + variant.ToString() + ")");
            }
            string filename = WingsPart.imagePath + ShipPart.ColorNames[(int)color] + "_" + variant;
            return Image.FromFile(filename);
        }

        internal WingsPart Create(COLOR color, int wingsVariant)
        {
            switch (wingsVariant)
            {
                case 0:
                    return new Wings0(color);
                case 1:
                    return new Wings1(color);
                case 2:
                    return new Wings2(color);
                case 3:
                    return new Wings3(color);
                case 4:
                    return new Wings4(color);
                case 5:
                    return new Wings5(color);
                case 6:
                    return new Wings6(color);
                case 7:
                    return new Wings7(color);

                default:
                    throw new Exception("There are only " + WingsPart.SpriteVariants.ToString() + " wings variants ! (you asked for " + wingsVariant.ToString() + ")");
            }
        }
    }
}
