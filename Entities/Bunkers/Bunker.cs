using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    class Bunker : Collidable, IStatic
    {
        public Bunker(Vecteur2D position) : base(Image.FromFile("../../Resources/bunker.png"), CollisionTag.BUNKER)
        {
            TransformComponent transform = (TransformComponent)GetComponent(typeof(TransformComponent));
            transform.Position = position;

            AddComponent(new ShootComponent(this, 1, 0.2));

            VelocityComponent velocity = (VelocityComponent)GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 0;
            velocity.Velocity.y = 0;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
            collisionComponent.onCollisionStay = (Collision collision) =>
            {
                OnCollisionWithMissile(collision);
            };

        }

        private void OnCollisionWithMissile(Collision collision)
        {
            if (collision.Entity is Missile)
            {
                TransformComponent transform = (TransformComponent)GetComponent(typeof(TransformComponent));
                double x = collision.Contacts.X - transform.Position.x;
                double xw = collision.Contacts.XPlusWidth - transform.Position.x;
                double y = collision.Contacts.Y - transform.Position.y;
                double yh = collision.Contacts.YPlusHeight - transform.Position.y;
                RenderComponent renderComponent = GetComponent(typeof(RenderComponent)) as RenderComponent;
                if (Tools.ChangeAABBColor(renderComponent, new Vecteur4(y, yh, x, xw)))
                {
                    Engine.instance.RemoveEntity(collision.Entity);
                }
            }
        }
    }
}
