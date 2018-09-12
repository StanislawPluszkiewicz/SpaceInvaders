using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Render
{
    class RenderNode: Node
    {
        TransformComponent transform;
        RenderComponent render;

        public RenderNode(Entity entity)
        {
            this.transform = (TransformComponent)entity.GetComponent(typeof(TransformComponent));
        }

        public new static bool HasToBeCreated(Entity entity)
        {
            return (entity.GetComponent(typeof(TransformComponent)) != null && 
                entity.GetComponent(typeof(RenderComponent)) != null);
        }
    }
}
