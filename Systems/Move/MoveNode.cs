using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;

namespace SpaceInvaders.Systems.Move
{
    class MoveNode : Node
    {
        TransformComponent transform;

        public MoveNode(Entity entity)
        {
            this.transform = (TransformComponent) entity.GetComponent(typeof(TransformComponent));
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetComponent(typeof(TransformComponent)) != null;
    }
}
