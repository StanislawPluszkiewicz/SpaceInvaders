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

        public MoveDynamicNode(GameObject entity)
        {
            TransformComponent = entity.GetComponent(typeof(TransformComponent)) as TransformComponent;
            VelocityComponent = entity.GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            RenderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
        }

        public new static bool HasToBeCreated(GameObject entity) => entity.GetType().GetInterfaces().Contains(typeof(IDynamic));
    }
}
