using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    abstract class Collidable : Moveable
    {
        public Collidable(Image image, CollisionTag collisionTag) : base(image)
        {
            CollisionComponent collisionComponent = new CollisionComponent(this, collisionTag);
            AddComponent(collisionComponent);
            collisionComponent.onCollisionEnter = (Entity other) =>
            {
                Console.WriteLine("{0} entered collision with {1}", this.GetType().Name, other.GetType().Name);
            };
            collisionComponent.onCollisionStay = (Entity other) =>
            {
                Console.WriteLine("{0} is colliding with {1}", this.GetType().Name, other.GetType().Name);
            };
            collisionComponent.onCollisionExit = (Entity other) =>
            {
                Console.WriteLine("{0} no longer collides with {1}", this.GetType().Name, other.GetType().Name);
            };
        }
        
    }
}
