﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Engine
{
    class EnginePartSlow : EnginePart
    {
        public EnginePartSlow(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, 5)
        {
        }
    }
}
