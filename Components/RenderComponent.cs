using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class RenderComponent : Component
    // Entities that have this component will be rendered
    {
        public Image Image { get; set; }
        public Vecteur2D View { get; set; }

        public RenderComponent(GameObject e, Image image) : base(e)
        {
            Image = image;
            View = new Vecteur2D(0, 0);
        }
    }
}
