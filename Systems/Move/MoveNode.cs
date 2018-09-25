using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;

namespace SpaceInvaders.Systems.Move
{
    class MoveNode : Node
    {
        public TransformComponent TransformComponent { get; set; }
        public VelocityComponent VelocityComponent { get; set; }

        public MoveNode(Entity entity)
        {
            this.TransformComponent = (TransformComponent) entity.GetComponent(typeof(TransformComponent));
            this.VelocityComponent  = (VelocityComponent)  entity.GetComponent(typeof(VelocityComponent));
        }

        public new static bool HasToBeCreated(Entity entity) => (entity.GetType() == typeof(Player));
    }
}
