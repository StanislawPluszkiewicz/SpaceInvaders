using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceInvaders.Entities.Ship.Cockpits
{
    public abstract class Cockpit : ShipPart
    {
        protected static readonly int SpriteVariants = 8;
        protected static readonly String imagePath = "../../Resources/PNG/Parts/cockpit";

        public Vector2 WingsPosition { get; set; }
        public List<Vector2> GunPositions { get; set; }
        public Vector2 EnginePosition { get; set; }

        public Cockpit(COLOR color, int variant) : base(GetImage(color, variant))
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

        public Cockpit Create(COLOR color, int cockpitVariant)
        {
            switch (cockpitVariant)
            {
                case 0:
                    return new CockpitTresLong(color);
                case 1:
                    return new CockpitPetit(color);
                case 2:
                    return new CockpitLong(color);
                case 3:
                    return new CockpitCarre(color);
                case 4:
                    return new CockpitPoire(color);
                case 5:
                    return new CockpitEnT(color);
                case 6:
                    return new CockpitNormal(color);
                case 7:
                    return new CockpitViolon(color);
                default:
                    throw new Exception("There are only " + Cockpit.SpriteVariants.ToString() + " cockpit variants ! (you asked for " + cockpitVariant.ToString() + ")");
            }
        }
    }
}
