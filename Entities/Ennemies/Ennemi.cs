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
            AddComponent(new MissileComponent(this, 1, 0.2));

            VelocityComponent velocity = (VelocityComponent)this.GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 50;
            velocity.Velocity.y = 0;


            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
            collisionComponent.onCollisionEnter = (Entity other) =>
            {
                Engine.instance.RemoveEntity(this);
                Engine.instance.RemoveEntity(other);
            };

        }
    }
}
