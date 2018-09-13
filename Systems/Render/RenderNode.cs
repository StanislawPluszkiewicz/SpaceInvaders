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
        public TransformComponent Transform { get; set; }
        public RenderComponent Render { get; set; }

        public RenderNode(Entity entity)
        {
            Transform = (TransformComponent)entity.GetComponent(typeof(TransformComponent));
            Render = (RenderComponent)entity.GetComponent(typeof(RenderComponent));
        }

        public new static bool HasToBeCreated(Entity entity)
        {
            return (entity.GetComponent(typeof(TransformComponent)) != null && 
                entity.GetComponent(typeof(RenderComponent)) != null);
        }
    }
}
