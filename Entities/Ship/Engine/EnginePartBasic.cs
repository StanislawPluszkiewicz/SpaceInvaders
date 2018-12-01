using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities.Ship.Engine
{
    class EnginePartBasic : EnginePart
    {
        public EnginePartBasic(CollisionTag collisionTag) : base(collisionTag, 1)
        {
        }
    }
}
