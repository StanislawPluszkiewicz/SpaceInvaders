using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class VelocityComponent : Component
    {
        public Vecteur2D Velocity { get; set; }
        public Vecteur2D Acceleration { get; set; }
        public Vecteur2D AngularVelocity { get; set; }

        public VelocityComponent(Entity e) : base(e)
        {
            Velocity = new Vecteur2D(1.5,1.5);
            Acceleration = new Vecteur2D(1, 1);
            AngularVelocity = new Vecteur2D(1, 1);
        }
    }
}
