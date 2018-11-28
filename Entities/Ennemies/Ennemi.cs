using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    class Ennemi : Collidable, IDynamic
    {
        public Ennemi() : base(Image.FromFile("../../Resources/PNG/Enemies/enemyBlack1.png"), CollisionTag.ENNEMI)
        {
            AddComponent(new ShootComponent(this, 1, 1));

            VelocityComponent velocity = (VelocityComponent)this.GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 50;
            velocity.Velocity.y = 0;
        }
    }
}
