using SpaceInvaders.Components;
using SpaceInvaders.Systems.Move.MoveKynematicObject;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Move.MoveEnnemiLine
{
    class MoveEnnemiBlocSystem : ISystem
    {
        private List<Node> moveEnnemiBloc;

        public void Update(double time)
        {
            moveEnnemiBloc = Engine.instance.nodesByType[typeof(MoveEnnemiBlocNode)];
            foreach (MoveEnnemiBlocNode node in moveEnnemiBloc)
            {
                node.Update();
                if (!node.Empty)
                {
                    foreach(MoveDynamicNode ennemi in node.Nodes)
                    {
                        if (node.MostLeftNode.TransformComponent.Position.x < 0 || node.MostRightNode.TransformComponent.Position.x > RenderForm.instance.Width - ennemi.RenderComponent.Image.Width)
                        {
                            ennemi.VelocityComponent.Velocity.x = -ennemi.VelocityComponent.Velocity.x;
                            ennemi.TransformComponent.Position.y += 10;
                        }
                    }
                }
                
            }
        }
    }
}
