using SpaceInvaders.Entities;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class CollisionComponent : Component
    {
        public CollisionComponent(GameObject e, CollisionSystem.Tag tag) : base(e)
        {
            Tag = tag;
        }

        public CollisionSystem.Tag Tag { get; set; } // Collision Tag
        public Vecteur2D TopLeft
        {
            get
            {
                RenderComponent renderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
                return renderComponent.View;
            }
        }

        public Vecteur2D BottomRight
        {
            get
            {
                RenderComponent renderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
                return new Vecteur2D(renderComponent.View.x + renderComponent.Image.Width, renderComponent.View.x + renderComponent.Image.Height);
            }
        }

    }
}
