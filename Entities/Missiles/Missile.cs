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
    abstract class Missile : Collidable, IDynamic
    {
        public Missile(Entity e, Image image, CollisionTag collisionTag, Image imageTrail = null, Vector2D trailOffset = null) : base(image, collisionTag)
        {
            RenderComponent renderComponent = GetComponent(typeof(RenderComponent)) as RenderComponent;
            if (imageTrail != null && trailOffset != null)
            {
                renderComponent.SetTrail(imageTrail, trailOffset);
            }

            TransformComponent parentTransform = e.GetComponent(typeof(TransformComponent)) as TransformComponent;
            TransformComponent transform = GetComponent(typeof(TransformComponent)) as TransformComponent;
            transform.Position = parentTransform.Position;

            VelocityComponent velocity = GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            velocity.Acceleration.x = 0;
            velocity.Acceleration.y = 2.5;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
        }
    }
}
