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

        private List<MoveNode> moveNodes;

        public MoveSystem()
        {
            moveNodes = new List<MoveNode>();
        }

        public void Update(double time)
        {
            Vecteur2D movement = new Vecteur2D();

            // if space is pressed
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
                node.transform.Position += movement * node.velocity.Velocity;
            }
        }



    }
}
