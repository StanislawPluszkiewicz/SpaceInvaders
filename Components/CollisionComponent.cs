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
        public enum CollisionTag { PLAYER = 0, ENNEMI, PLAYER_MISSILE, ENNEMI_MISSILE, BUNKER };
        public enum CollisionState { NotColliding, Colliding }
        public CollisionTag Tag { get; set; }
        public CollisionState State { get; set; }
        public Hitbox Hitbox { get; set; }

        public delegate void OnCollisionEnter(Entity other);
        public delegate void OnCollisionStay(Entity other);
        public delegate void OnCollisionExit(Entity other);
        public OnCollisionEnter onCollisionEnter;
        public OnCollisionEnter onCollisionStay;
        public OnCollisionEnter onCollisionExit;
        public CollisionComponent(Entity e, CollisionTag tag) : base(e)
        {
            Tag = tag;
            RenderComponent renderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
            Hitbox = new Hitbox(-1, -1, -1, -1);
            State = CollisionState.NotColliding;
        }

    }
}
