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
        public MoveEnnemiLineNode(GameObject entity)
        {
            MoveEnnemiNodes = Engine.instance.nodesByType[typeof(MoveDynamicNode)];
        }

        public new static bool HasToBeCreated(GameObject entity) => entity.GetType() == typeof(EnnemiLine);
    }
}
