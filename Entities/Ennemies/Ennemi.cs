using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Ennemi : Collidable, IDynamic
    {
        public Ennemi() : base(Image.FromFile("../../Resources/ship1.png"), CollisionSystem.Tag.ENNEMI)
        {
            VelocityComponent velocity = (VelocityComponent)this.GetComponent(typeof(VelocityComponent));

            velocity.Velocity.x = 50;
            velocity.Velocity.y = 0;

        }
    }
}
