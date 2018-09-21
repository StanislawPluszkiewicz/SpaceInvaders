using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;

namespace SpaceInvaders.Systems.Move
{
    class MoveNode : Node
    {
        public TransformComponent transform;
        public VelocityComponent velocity;

        public MoveNode(Entity entity)
        {
            this.transform = (TransformComponent) entity.GetComponent(typeof(TransformComponent));
            this.velocity  = (VelocityComponent)  entity.GetComponent(typeof(VelocityComponent));
        }

        public new static bool HasToBeCreated(Entity entity) => (entity.GetComponent(typeof(TransformComponent)) != null && entity.GetComponent(typeof(VelocityComponent)) != null);
    }
}
