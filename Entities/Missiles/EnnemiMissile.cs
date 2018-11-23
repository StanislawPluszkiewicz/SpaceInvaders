using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities.Missiles
{
    class EnnemiMissile : Missile
    {
        public EnnemiMissile(Entity e) : base(e, Image.FromFile("../../Resources/shoot1.png"), CollisionTag.ENNEMI_MISSILE)
        {
            VelocityComponent velocity = GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            velocity.Velocity.x = 0;
            velocity.Velocity.y = 75;
        }
    }
}
