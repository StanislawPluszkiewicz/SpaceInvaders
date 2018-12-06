using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using static SpaceInvaders.Components.CollisionComponent;
using SpaceInvaders.Entities.Ship.Cockpits;
using SpaceInvaders.Entities.Ship.Engines;
using SpaceInvaders.Entities.Ship.Wings;
using SpaceInvaders.Entities.Ship.Guns;

namespace SpaceInvaders.Entities.Ship
{
    public class Ship : Entity, IDynamic
    {
        public Cockpit Cockpit { get; set; }
        public EnginePart EnginePart { get; set; }
        public WingsPart Wings { get; set; }
        public List<Gun> Guns { get; set; }

        public Ship(int seed = 0) : base()
        {
            Random random = new Random(seed);
            Guns = new List<Gun>();
            // TODO
        }

        public Ship(Cockpit cockpit, EnginePart engine, WingsPart wings, params Gun[] guns) : base()
        {
            Cockpit = cockpit;
            EnginePart = engine;
            Wings = wings;
            Guns = new List<Gun>();
            foreach(Gun gun in guns)
            {
                Guns.Add(gun);
            }
        }

        public Ship(ShipPart.COLOR color, int cockpitVariant, int engineVariant, int wingsVariant, params int[] gunsVariant) : base()
        {
            Cockpit = Cockpit.Create(color, cockpitVariant);
            EnginePart = EnginePart.Create(engineVariant);
            Wings = Wings.Create(color, cockpitVariant);
            Guns = new List<Gun>();
            foreach (int gunVariant in gunsVariant)
            {
                Guns.Add(Gun.Create(gunVariant));
            }
        }
    }
}
