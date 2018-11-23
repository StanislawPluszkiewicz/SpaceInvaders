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
                Console.WriteLine("Collision enter {0} - {1} ({2})", this.GetType().Name, other.GetType().Name, collisionComponent.State);
            };
            collisionComponent.onCollisionStay = (Entity other) =>
            {
                Console.WriteLine("Collision stay {0} - {1} ({2})", this.GetType().Name, other.GetType().Name, collisionComponent.State);
            };
            collisionComponent.onCollisionExit = (Entity other) =>
            {
                Console.WriteLine("Collision exit {0} - {1} ({2})", this.GetType().Name, other.GetType().Name, collisionComponent.State);
            };
        }
        
    }
}
