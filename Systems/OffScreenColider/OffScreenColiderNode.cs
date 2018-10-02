using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.OffScreenColider
{
    class OffScreenColiderNode:Node
    {
        public RenderComponent RenderComponent { get; set; }

        public OffScreenColiderNode(GameObject entity)
        {
            RenderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
        }

        public static new bool HasToBeCreated(GameObject e) => e.GetType() == typeof(Missile);
    }
}
