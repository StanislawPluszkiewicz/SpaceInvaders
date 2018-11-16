using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities.Missiles
{
    class PlayerMissile : Missile
    {
        public PlayerMissile(Entity e, Image imageTrail = null, Vecteur2D trailOffset = null) : 
            base(e, Image.FromFile("../../Resources/anim/nyan_cat.gif"), CollisionSystem.Tag.PLAYER_MISSILE, Image.FromFile("../../Resources/anim/rainbow_trail.png"), new Vecteur2D(1, 1))
        {
            VelocityComponent velocity = GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            velocity.Velocity.x = 0;
            velocity.Velocity.y = -75;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
            collisionComponent.onCollisionEnter = (Entity other) =>
            {
                Engine.instance.RemoveEntity(this);
                Engine.instance.RemoveEntity(other);
            };
        }
    }
}
