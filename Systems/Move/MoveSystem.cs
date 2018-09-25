using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders.Systems.Move
{
    class MoveSystem : ISystem
    {

        private List<Node> moveNodes;

        public MoveSystem()
        {
        }

        public void Update(double time)
        {
            moveNodes = Engine.instance.nodesByType[typeof(MoveNode)];

            Vecteur2D movement = new Vecteur2D();
            
            if (Engine.instance.keyPressed.Contains(Keys.Left))
            {
                movement += new Vecteur2D(-time, 0);
            }
            if (Engine.instance.keyPressed.Contains(Keys.Right))
            {
                movement += new Vecteur2D(time, 0);
            }

            foreach (MoveNode node in moveNodes)
            {
                node.TransformComponent.Position += movement * node.VelocityComponent.Velocity;
            }
        }



    }
}
