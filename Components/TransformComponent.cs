using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;

namespace SpaceInvaders.Components
{
    class TransformComponent : Component
    {
        private Vector2D position;
        public Vector2D Position
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
                    RenderComponent renderComponent = Entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
                    renderComponent.View = position;
                    try
                    {
                        CollisionComponent collisionComponent = Entity.GetComponent(typeof(CollisionComponent)) as CollisionComponent;
                        HitboxAABB hitboxAABB = collisionComponent.Hitbox as HitboxAABB;
                        hitboxAABB.Update(renderComponent.View.y, renderComponent.View.y + renderComponent.Image.Height, renderComponent.View.x, renderComponent.View.x + renderComponent.Image.Width);
                    }
                    catch { }
                }
                catch { }
            }
        }
        public Vector2D Rotation { get; set; }
        public Vector2D LocalScale { get; set; }

        public TransformComponent(Entity e) : base(e)
        {
            position = new Vector2D(0,0);
            Rotation = new Vector2D(0, 0);
            LocalScale = new Vector2D(1, 1);
        }
    }
}
