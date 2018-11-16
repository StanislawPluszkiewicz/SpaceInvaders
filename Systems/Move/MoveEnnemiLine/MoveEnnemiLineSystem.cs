using SpaceInvaders.Components;
using SpaceInvaders.Systems.Move.MoveKynematicObject;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Move.MoveEnnemiLine
{
    class MoveEnnemiLineSystem : ISystem
    {
        private List<Node> MoveKynematicObjectNodes;


        public void Update(double time)
        {
            Engine engine = Engine.instance;
            MoveKynematicObjectNodes = Engine.instance.nodesByType[typeof(MoveEnnemiLineNode)];

            foreach (MoveEnnemiLineNode lineNode in MoveKynematicObjectNodes)
            {
                if (lineNode.MoveEnnemiNodes.Count == 0) { break; }
                MoveDynamicNode mostLeftNode = (MoveDynamicNode)lineNode.MoveEnnemiNodes.First();
                MoveDynamicNode mostRightNode = (MoveDynamicNode)lineNode.MoveEnnemiNodes.First();
                foreach(MoveDynamicNode node in lineNode.MoveEnnemiNodes)
                {
                    if (mostRightNode.TransformComponent.Position.x < node.TransformComponent.Position.x)
                    {
                        mostRightNode = node;
                    }
                    if (mostLeftNode.TransformComponent.Position.x > node.TransformComponent.Position.x)
                    {
                        mostLeftNode = node;
                    }
                }

                foreach (MoveDynamicNode node in lineNode.MoveEnnemiNodes)
                {
                    Vecteur2D velocity = new Vecteur2D();
                    if (mostLeftNode.TransformComponent.Position.x < 0 || mostRightNode.TransformComponent.Position.x > RenderForm.instance.Width - node.RenderComponent.Image.Width)
                    {
                        node.VelocityComponent.Velocity.x = -node.VelocityComponent.Velocity.x;
                        node.TransformComponent.Position.y += 1;
                    }
                }
            }
        }
    }
}
