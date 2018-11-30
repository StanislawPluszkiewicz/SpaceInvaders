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
    public class CollisionComponent : Component
    {
        public enum CollisionTag { PLAYER = 0, ENNEMI, PLAYER_MISSILE, ENNEMI_MISSILE, BUNKER }; // used as a index
        public CollisionTag Tag { get; set; }

        public Hitbox Hitbox { get; set; }
        

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
            HitboxAABB body = new HitboxAABB(renderComponent.View.x, renderComponent.Image.Width, renderComponent.View.y, renderComponent.Image.Height);
            Hitbox = new Hitbox(body, body, null, null);
        }

    }
}
