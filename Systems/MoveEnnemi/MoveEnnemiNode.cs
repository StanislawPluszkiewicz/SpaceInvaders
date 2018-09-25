using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.MoveEnnemi
{
    class MoveEnnemiNode : Node
    {
        public TransformComponent TransformComponent { get; set; }
        public VelocityComponent VelocityComponent { get; set; }

        public MoveEnnemiNode(Entity entity)
        {
            TransformComponent = (TransformComponent)entity.GetComponent(typeof(TransformComponent));
            VelocityComponent = (VelocityComponent)entity.GetComponent(typeof(VelocityComponent));
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType() == typeof(Ennemi);
    }
}
