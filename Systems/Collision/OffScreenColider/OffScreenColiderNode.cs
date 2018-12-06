﻿using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Entities.Missiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.OffScreenColider
{
    class OffScreenColiderNode:Node
    {
        public RenderComponent RenderComponent { get; set; }

        public OffScreenColiderNode(Entity entity)
        {
            RenderComponent = entity.Components[typeof(RenderComponent)] as RenderComponent;
        }

        public static new bool HasToBeCreated(Entity e) => e is Missile;
    }
}
