using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Engine
{
    class EnginePartSmall : EnginePart
    {
        public EnginePartSmall(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, 3)
        {
        }
    }
}
