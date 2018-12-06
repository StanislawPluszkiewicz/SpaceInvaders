using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    public abstract class Renderable : Entity
    {
        public Renderable(Image image=null) : base()
        {
            AddComponent(new RenderComponent(this, image));
        }

        public void Render(Graphics g)
        {
            RenderComponent renderComponent = this.Components[typeof(RenderComponent)] as RenderComponent;
            if (renderComponent.HasTrail)
            {
                foreach (Vector2 position in renderComponent.TrailPositions)
                {
                    g.DrawImage(renderComponent.TrailImage, (float)position.x, (float)position.y);
                }
            }
            foreach (Image image in renderComponent.Images)
            {
                g.DrawImage(renderComponent.Images, (float)renderComponent.View.x, (float)renderComponent.View.y, (float)renderComponent.Images.Width, (float)renderComponent.Images.Height);
            }
        }
    }
}
