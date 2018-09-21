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

        public Joueur(Image image) : base()
        {
            AddComponent(new TransformComponent());
            AddComponent(new VelocityComponent());
            AddComponent(new RenderComponent(image));

        }

    }
}
