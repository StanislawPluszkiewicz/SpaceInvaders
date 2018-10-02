using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Renderable : GameObject
    {
        public Renderable(Image image) : base()
        {
            AddComponent(new RenderComponent(this, image));
        }

        public void Render(Graphics g)
        {
            RenderComponent renderComponent = ((RenderComponent)GetComponent(typeof(RenderComponent)));
            g.DrawImage(renderComponent.Image, (float)renderComponent.View.x, (float)renderComponent.View.y);
        }
    }
}
