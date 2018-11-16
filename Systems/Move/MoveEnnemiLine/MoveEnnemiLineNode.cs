using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Systems.Move.MoveKynematicObject;

namespace SpaceInvaders.Systems.Move.MoveEnnemiLine
{
    class MoveEnnemiLineNode : Node
    {
        public List<Node> MoveEnnemiNodes { get; set; }
        public MoveEnnemiLineNode(Entity entity)
        {
            MoveEnnemiNodes = Engine.instance.nodesByType[typeof(MoveDynamicNode)];
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType() == typeof(EnnemiLine);
    }
}
