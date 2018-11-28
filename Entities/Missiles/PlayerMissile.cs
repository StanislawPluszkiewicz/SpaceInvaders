using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities.Missiles
{
    class PlayerMissile : Missile
    {
        public PlayerMissile(Entity e, Image imageTrail = null, Vecteur2D trailOffset = null) : 
            base(e, Image.FromFile("../../Resources/old/shoot1.png"), CollisionTag.PLAYER_MISSILE)
        {
            VelocityComponent velocity = GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            velocity.Velocity.x = 0;
            velocity.Velocity.y = -125;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
            collisionComponent.onCollisionEnter = (Collision collision) =>
            {
                if (collision.Entity is Ennemi)
                {
                    Engine.instance.RemoveEntity(collision.Entity);
                    Engine.instance.RemoveEntity(this);
                }
            };
        }
    }
}
