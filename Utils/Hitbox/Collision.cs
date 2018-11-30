using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils.GeometricForms;
using SpaceInvaders.Utils.Hitbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SpaceInvaders.Utils.Hitbox.Hitbox;

namespace SpaceInvaders.Utils
{
    class Collision
    {
        public Entity Entity { get; private set; }
        public TransformComponent Transform { get; private set; }
        public CollisionComponent CollisionComponent { get; private set; }
        public AxisAlignedBoundedBox Contacts { get; private set; }
        public HitSource OriginHitSource { get; private set; }
        public HitSource OtherHitSource { get; private set; }


        public Collision(AxisAlignedBoundedBox contacts)
        {
            Contacts = contacts;
        }

        public void UpdateHitSources(HitSource origin, HitSource other, CollisionComponent collisionComponent)
        {
            CollisionComponent = collisionComponent;
            Entity = collisionComponent.Entity;
            Transform = Entity.GetComponent(typeof(TransformComponent)) as TransformComponent;
        }
    }
}
