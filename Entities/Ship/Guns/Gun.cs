using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Entities.Ship.ShipPart;

namespace SpaceInvaders.Entities.Ship.Guns
{
    public class Gun : ShipPart
    {
        protected static readonly int SpriteVariants = 11;
        protected static readonly String imagePath = "../../Resources/PNG/Parts/gun";

        public Gun(string variant) : base(GetImage(variant))
        {
        }
        protected static Image GetImage(string variant)
        {
            if (Int32.Parse(variant) > SpriteVariants)
            {
                throw new Exception("There are only " + SpriteVariants.ToString() + " gun variants ! (you asked for " + variant.ToString() + ")");
            }
            string filename = imagePath + variant;
            return Image.FromFile(filename);
        }

        public static Gun Create(int gunVariant)
        {
            switch (gunVariant)
            {
                case 0:
                    return new Gun0();
                case 1:
                    return new Gun1();
                case 2:
                    return new Gun2();
                case 3:
                    return new Gun3();
                case 4:
                    return new Gun4();
                case 5:
                    return new Gun5();
                case 6:
                    return new Gun6();
                case 7:
                    return new Gun7();
                case 8:
                    return new Gun8();
                case 9:
                    return new Gun9();
                case 10:
                    return new Gun10();

                default:
                    throw new Exception("There are only " + SpriteVariants.ToString() + " gun variants ! (you asked for " + gunVariant.ToString() + ")");
            }
        }
    }
}

