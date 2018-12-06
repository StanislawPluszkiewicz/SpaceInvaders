using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    public abstract class Moveable : Renderable
    {
        public Moveable(Image image=null) : base(image)
        {
            AddComponent(new VelocityComponent(this));
        }

    }
}
