using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.GeometricForms;
using System.Drawing;
using static SpaceInvaders.Components.CollisionComponent;
using SpaceInvaders;

namespace SpaceInvaders.Entities
{
    public class Player : Collidable, IKynematic
    {

        public int Lifes { get; private set; }
        public Ship.Ship Ship { get; set; }
        public Player(Ship.Ship ship) : base(CollisionTag.PLAYER)
        {
            Ship = ship;
            TransformComponent shipTransform = ship.Components[typeof(TransformComponent)] as TransformComponent;
            TransformComponent transform = this.Components[typeof(TransformComponent)] as TransformComponent;
            shipTransform.Parent = transform;

            

            SetStartingPosition();
            SetVelocity();

            AddComponent(new ShootComponent(this, 1, 0.2));
            Lifes = 3;

            CollisionComponent collisionComponent = this.Components[typeof(CollisionComponent)] as CollisionComponent;
            collisionComponent.onCollisionStay = (Collision collision) =>
            {
                OnCollisionWithMissile(collision);
            };
        }

        private void SetVelocity()
        {
            VelocityComponent velocity = this.Components[typeof(VelocityComponent)] as VelocityComponent;
            velocity.Velocity.x = 400;
            velocity.Velocity.y = 400;
        }
        private void SetStartingPosition()
        {
            TransformComponent transform = this.Components[typeof(TransformComponent)] as TransformComponent;
            RenderComponent renderComponent = this.Components[typeof(RenderComponent)] as RenderComponent;
            transform.Position.x = RenderForm.instance.Size.Width / 2 - renderComponent.Images.Width / 2;
            transform.Position.y = RenderForm.instance.Size.Height * 4 / 5;
        }

        private void TakeDamage()
        {
            Lifes--;

            RenderForm.instance.Text = "You have " + Lifes + " lifes left!";
            if (Lifes == 0)
            {
                RenderForm.instance.Text = "You lost!";
            }
        }
        private void OnCollisionWithMissile(Collision collision)
        {
            if (collision.Entity is Missile)
            {
                TakeDamage();
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
