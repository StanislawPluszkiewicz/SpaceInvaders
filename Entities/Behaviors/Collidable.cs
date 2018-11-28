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
    abstract class Collidable : Moveable
    {
        public Collidable(Image image, CollisionTag collisionTag) : base(image)
        {
            CollisionComponent collisionComponent = new CollisionComponent(this, collisionTag);
            AddComponent(collisionComponent);
            collisionComponent.onCollisionEnter = (Collision other) =>
            {
                if (CollisionSystem.DEBUG)
                    Console.WriteLine("{0} onCollisionEnter {1}", this.GetType().Name, other.Entity.GetType().Name);
            };
            collisionComponent.onCollisionStay = (Collision other) =>
            {
                if (CollisionSystem.DEBUG)
                    Console.WriteLine("{0} onCollisionStay {1}", this.GetType().Name, other.Entity.GetType().Name);
            };
            collisionComponent.onCollisionExit = (Collision other) =>
            {
                if (CollisionSystem.DEBUG)
                    Console.WriteLine("{0} onCollisionExit {1}", this.GetType().Name, other.Entity.GetType().Name);
            };
        }
        
    }
}
