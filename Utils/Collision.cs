using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils.Hitbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Collision
    {
        public CollisionComponent CollisionComponent { get; private set; }
        public Entity Entity { get; private set; }
        public TransformComponent Transform { get; private set; }
        public Vecteur4 Contacts { get; private set; }

        public Collision(CollisionComponent collisionComponent, Vecteur4 contacts)
        {
            CollisionComponent = collisionComponent;
            Entity = collisionComponent.entity;
            Transform = Entity.GetComponent(typeof(TransformComponent)) as TransformComponent;
            this.Contacts = contacts;
        }
    }
}
