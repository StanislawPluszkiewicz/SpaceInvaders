using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class VelocityComponent : Component
    {
        public Vecteur2D Velocity { get; set; }
        public Vecteur2D AngularVelocity { get; set; }

        public VelocityComponent()
        {
            Velocity = new Vecteur2D(0,0);
            AngularVelocity = new Vecteur2D(0, 0);
        }
    }
}
