using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class TransformComponent : Component
    {
        public Vecteur2D position;
        public Vecteur2D rotation;
        public Vecteur2D localScale;
    }
}
