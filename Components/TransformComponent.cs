using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class TransformComponent : Component
    {
        public Vecteur2D Position { get; set; }
        public Vecteur2D Rotation { get; set; }
        public Vecteur2D LocalScale { get; set; }

        public TransformComponent()
        {
            Position = new Vecteur2D(0,0);
            Rotation = new Vecteur2D(0, 0);
            LocalScale = new Vecteur2D(0, 0);
        }
    }
}
