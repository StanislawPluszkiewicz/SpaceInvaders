using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    class Bunker : Collidable, IStatic
    {
        public Bunker(Vecteur2D position) : base(Image.FromFile("../../Resources/bunker.png"), CollisionTag.BUNKER)
        {
            TransformComponent transform = (TransformComponent)GetComponent(typeof(TransformComponent));
            transform.Position = position;

            AddComponent(new ShootComponent(this, 1, 0.2));

            VelocityComponent velocity = (VelocityComponent)GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 0;
            velocity.Velocity.y = 0;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
            collisionComponent.onCollisionEnter = (Entity other) =>
            {
                
            };

        }
    }
}
