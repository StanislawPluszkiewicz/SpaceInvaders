using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Linq;

namespace SpaceInvaders.Systems.Move
{
    class MoveKynematicNode : Node
    {
        public TransformComponent TransformComponent { get; set; }
        public VelocityComponent VelocityComponent { get; set; }
        public RenderComponent RenderComponent { get; set; }

        public MoveKynematicNode(Entity entity)
        {
            TransformComponent = entity.GetComponent(typeof(TransformComponent)) as TransformComponent;
            VelocityComponent  = entity.GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            RenderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
        }

        public new static bool HasToBeCreated(Entity entity) => (entity.GetType().GetInterfaces().Contains(typeof(IKynematic)));
    }
}
