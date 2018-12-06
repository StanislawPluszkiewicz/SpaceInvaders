using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Move.MoveKynematicObject
{
    class MoveDynamicNode : Node
    {
        public TransformComponent TransformComponent { get; set; }
        public VelocityComponent VelocityComponent { get; set; }
        public RenderComponent RenderComponent { get; set; }

        public MoveDynamicNode(Entity entity)
        {
            TransformComponent = entity.Components[typeof(TransformComponent)] as TransformComponent;
            VelocityComponent = entity.Components[typeof(VelocityComponent)] as VelocityComponent;
            RenderComponent = entity.Components[typeof(RenderComponent)] as RenderComponent;
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType().GetInterfaces().Contains(typeof(IDynamic));
    }
}
