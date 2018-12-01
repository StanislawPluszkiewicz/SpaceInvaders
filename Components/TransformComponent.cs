using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;

namespace SpaceInvaders.Components
{
    public class TransformComponent : Component
    {
        private Vector2 position;
        public Vector2 Position
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
                        collisionComponent.Hitbox.Update(renderComponent.View);
                    }
                    catch { }
                }
                catch { }
            }
        }
        public Vector2 Rotation { get; set; }
        public Vector2 LocalScale { get; set; }

        public TransformComponent(Entity e) : base(e)
        {
            position = new Vector2(0,0);
            Rotation = new Vector2(0, 0);
            LocalScale = new Vector2(1, 1);
        }
    }
}
