﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities.Ship.Engine
{
    class EnginePartBig : EnginePart
    {
        public EnginePartBig(CollisionComponent.CollisionTag collisionTag) : base(collisionTag, 4)
        {
        }
    }
}
