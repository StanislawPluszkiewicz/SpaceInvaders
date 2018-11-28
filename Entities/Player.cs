using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    class Player : Collidable, IKynematic
    {

        public int Lives { get; set; }
        public Player() : base(Image.FromFile("../../Resources/ship2.png"), CollisionTag.PLAYER)
        {
            Lives = 3;

            TransformComponent transform = (TransformComponent)GetComponent(typeof(TransformComponent));
            RenderComponent renderComponent = (RenderComponent)GetComponent(typeof(RenderComponent));
            transform.Position.x = RenderForm.instance.Size.Width / 2 - renderComponent.Image.Width / 2;
            transform.Position.y = RenderForm.instance.Size.Height * 4 / 5;

            AddComponent(new ShootComponent(this, 1, 0.2));

            VelocityComponent velocity = (VelocityComponent)GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 400;
            velocity.Velocity.y = 400;

            CollisionComponent collisionComponent = GetComponent(typeof(CollisionComponent)) as CollisionComponent;
            collisionComponent.onCollisionStay = (Collision collision) =>
            {
                OnCollisionWithMissile(collision);
            };
        }

        private void TakeDamage()
        {
            Lives--;
            if (Lives == 0)
            {
                RenderForm.instance.Text = "You lost!";
            }
        }
        private void OnCollisionWithMissile(Collision collision)
        {
            if (collision.Entity is Missile)
            {
                TakeDamage();
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
