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
        public Vector2D Velocity { get; set; }
        public Vector2D Acceleration { get; set; }
        public Vector2D AngularVelocity { get; set; }

        public VelocityComponent(Entity e) : base(e)
        {
            Velocity = new Vector2D(0, 0);
            Acceleration = new Vector2D(1,1);
            AngularVelocity = new Vector2D(0, 0);
        }
    }
}
