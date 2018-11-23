using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Systems.Move.MoveKynematicObject;

namespace SpaceInvaders.Systems.Move.MoveEnnemiLine
{
    class MoveEnnemiBlocNode : Node
    {
        public List<Node> Nodes { get; set; }
        public MoveDynamicNode MostLeftNode { get; set; }
        public MoveDynamicNode MostRightNode { get; set; }
        public bool Empty = false;


        public MoveEnnemiBlocNode(Entity entity)
        {
        }

        public void Update()
        {
            Nodes = new List<Node>();
            foreach (MoveDynamicNode node in Engine.instance.nodesByType[typeof(MoveDynamicNode)])
            {
                if (node.TransformComponent.entity.GetType() == typeof(Ennemi))
                {
                    Nodes.Add(node);
                }
            }
            if (Nodes.Count == 0) {
                Empty = true;
            }
            else
            {
                MostRightNode = Nodes.First() as MoveDynamicNode;
                MostLeftNode = Nodes.First() as MoveDynamicNode;
                foreach (MoveDynamicNode node in Nodes)
                {
                    if (MostRightNode.TransformComponent.Position.x < node.TransformComponent.Position.x)
                    {
                        MostRightNode = node;
                    }
                    if (MostLeftNode.TransformComponent.Position.x > node.TransformComponent.Position.x)
                    {
                        MostLeftNode = node;
                    }
                }
            }
            
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType() == typeof(EnnemiBloc);
    }
}
