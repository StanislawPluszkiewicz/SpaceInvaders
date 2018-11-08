using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Moveable : Renderable
    {
        public Moveable(Image image) : base(image)
        {
            AddComponent(new VelocityComponent(this));
        }

    }
}
