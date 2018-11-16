using SpaceInvaders.Entities;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class CollisionComponent : Component
    {
        public CollisionSystem.Tag Tag { get; set; }
        public Hitbox Hitbox { get; set; }
        public delegate void OnCollisionEnter(Entity other);
        public OnCollisionEnter onCollisionEnter;
        public CollisionComponent(Entity e, CollisionSystem.Tag tag) : base(e)
        {
            Tag = tag;
            RenderComponent renderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
            Hitbox = new Hitbox(-1, -1, -1, -1);
        }

    }
}
