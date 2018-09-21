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

        public RenderNode(Entity entity)
        {
            AddComponent((TransformComponent)entity.GetComponent(typeof(TransformComponent)));
            AddComponent((RenderComponent)entity.GetComponent(typeof(RenderComponent)));
        }

        public new static bool HasToBeCreated(Entity entity)
        {
            return (entity.GetComponent(typeof(TransformComponent)) != null && 
                entity.GetComponent(typeof(RenderComponent)) != null);
        }
    }
}
