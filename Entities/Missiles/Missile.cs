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
    abstract class Missile : Collidable, IDynamic
    {
        public Missile(Entity e, Image image, CollisionSystem.Tag collisionTag, Image imageTrail = null, Vecteur2D trailOffset = null) : base(image, collisionTag)
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
            velocity.Acceleration.y = 1.2;
        }
    }
}
