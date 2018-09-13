using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Joueur : Entity
    {
        TransformComponent Transform { get; set; }
        VelocityComponent Velocity { get; set; }
        RenderComponent Render { get; set; }

        public Joueur(Image image) : base()
        {
            Transform = new TransformComponent();
            Velocity = new VelocityComponent();
            Render = new RenderComponent(image);
        }

    }
}
