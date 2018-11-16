using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Renderable : Entity
    {
        public Renderable(Image image) : base()
        {
            AddComponent(new RenderComponent(this, image));
        }

        public void Render(Graphics g)
        {
            RenderComponent renderComponent = ((RenderComponent)GetComponent(typeof(RenderComponent)));
            if (renderComponent.HasTrail)
            {
                foreach (Vecteur2D position in renderComponent.TrailPositions)
                {
                    g.DrawImage(renderComponent.TrailImage, (float)position.x, (float)position.y);
                }
            }

            g.DrawImage(renderComponent.Image, (float)renderComponent.View.x, (float)renderComponent.View.y);
        }
    }
}
