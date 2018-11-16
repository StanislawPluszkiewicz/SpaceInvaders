using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class TransformComponent : Component
    {
        private Vecteur2D position;
        public Vecteur2D Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                try
                {
                    RenderComponent renderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
                    renderComponent.View = position;
                    try
                    {
                        CollisionComponent collisionComponent = entity.GetComponent(typeof(CollisionComponent)) as CollisionComponent;
                        collisionComponent.Hitbox.Update(renderComponent.View.y, renderComponent.View.y + renderComponent.Image.Height, renderComponent.View.x, renderComponent.View.x + renderComponent.Image.Width);
                    }
                    catch { }
                }
                catch{ }
            }
        }
        public Vecteur2D Rotation { get; set; }
        public Vecteur2D LocalScale { get; set; }

        public TransformComponent(Entity e) : base(e)
        {
            position = new Vecteur2D(0,0);
            Rotation = new Vecteur2D(0, 0);
            LocalScale = new Vecteur2D(1, 1);
        }
    }
}
