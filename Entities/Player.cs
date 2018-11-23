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
    class Player : Collidable, IKynematic
    {
        public Player() : base(Image.FromFile("../../Resources/ship2.png"), CollisionTag.PLAYER)
        {
            TransformComponent transform = (TransformComponent)GetComponent(typeof(TransformComponent));
            transform.Position.x = RenderForm.instance.Size.Width / 2;
            transform.Position.y = RenderForm.instance.Size.Height * 4 / 5;

            AddComponent(new ShootComponent(this, 1, 0.2));

            VelocityComponent velocity = (VelocityComponent)GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 400;
            velocity.Velocity.y = 400;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
        }
    }
}
