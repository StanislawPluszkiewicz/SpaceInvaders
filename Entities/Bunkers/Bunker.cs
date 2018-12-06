using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.GeometricForms;
using SpaceInvaders.Utils.Hitbox;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    class Bunker : Collidable, IStatic
    {
        public Bunker(Vector2 position) : base(CollisionTag.BUNKER, Image.FromFile("../../Resources/old/bunker.png"))
        {
            TransformComponent transform = this.Components[typeof(TransformComponent)] as TransformComponent;
            transform.Position = position;

            AddComponent(new ShootComponent(this, 1, 0.2));

            VelocityComponent velocity = this.Components[typeof(VelocityComponent)] as VelocityComponent;
            velocity.Velocity.x = 0;
            velocity.Velocity.y = 0;

            CollisionComponent collisionComponent = this.Components[typeof(CollisionComponent)] as CollisionComponent;
            collisionComponent.onCollisionStay = (Collision collision) =>
            {
                OnCollisionWithMissile(collision);
            };

        }

        private void OnCollisionWithMissile(Collision collision)
        {
            if (collision.Entity is Missile)
            {
                TransformComponent transform = this.Components[typeof(TransformComponent)] as TransformComponent;
                double x = collision.Contacts.x - transform.Position.x;
                double w = collision.Contacts.Width - transform.Position.x;
                double y = collision.Contacts.y - transform.Position.y;
                double h = collision.Contacts.Height - transform.Position.y;
                RenderComponent renderComponent = this.Components[typeof(RenderComponent)] as RenderComponent;
                if (Tools.ChangeAABBColorToTransparent(renderComponent, new AxisAlignedBoundedBox(x, w, y, h)))
                {
                    Engine.instance.RemoveEntity(collision.Entity);
                }
            }
        }
    }
}
