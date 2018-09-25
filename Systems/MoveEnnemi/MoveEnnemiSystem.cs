using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.MoveEnnemi
{
    class MoveEnnemiSystem : ISystem
    {
        private List<Node> moveNodes;

        public void Update(double time)
        {

            moveNodes = Engine.instance.nodesByType[typeof(MoveEnnemiNode)];


            foreach (MoveEnnemiNode node in moveNodes)
            {
                Vecteur2D velocity = new Vecteur2D();
                if (node.TransformComponent.Position.x < 20 || node.TransformComponent.Position.x > 300)
                {
                    node.VelocityComponent.Velocity.x = -node.VelocityComponent.Velocity.x;
                }

                node.TransformComponent.Position += time * node.VelocityComponent.Velocity;
            }
        }
    }
}
