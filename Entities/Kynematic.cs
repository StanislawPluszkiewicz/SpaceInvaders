using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Kynematic : Renderable
    {

        public Kynematic(Image image) : base(image)
        {
            AddComponent(new VelocityComponent(this));
        }

    }
}
