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
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 AngularVelocity { get; set; }

        public VelocityComponent(Entity e) : base(e)
        {
            Velocity = new Vector2(0, 0);
            Acceleration = new Vector2(1,1);
            AngularVelocity = new Vector2(0, 0);
        }
    }
}
