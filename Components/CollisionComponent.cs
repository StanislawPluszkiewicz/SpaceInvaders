using SpaceInvaders.Entities;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class CollisionComponent : Component
    {
        public enum CollisionTag { PLAYER = 0, ENNEMI, PLAYER_MISSILE, ENNEMI_MISSILE, BUNKER };
        public enum CollisionState { NOT_COLLIDING, COLLIDING }
        public CollisionTag Tag { get; set; }
        public CollisionState State { get; set; }
        public List<CollisionComponent> CollidingWith { get; set; }
        public IHitbox Hitbox { get; set; }

        public delegate void OnCollisionEnter(Collision other);
        public delegate void OnCollisionStay(Collision other);
        public delegate void OnCollisionExit(Collision other);
        public OnCollisionEnter onCollisionEnter;
        public OnCollisionEnter onCollisionStay;
        public OnCollisionEnter onCollisionExit;

        public CollisionComponent(Entity e, CollisionTag tag) : base(e)
        {
            Tag = tag;
            RenderComponent renderComponent = Entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
            Hitbox = new HitboxAABB(-1, -1, -1, -1);
            State = CollisionState.NOT_COLLIDING;
            CollidingWith = new List<CollisionComponent>();
        }

    }
}
