using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders.Systems.Move
{
    class MoveKynematicSystem : ISystem
    {

        private List<Node> moveNodes;

        public void Update(double time)
        {
            moveNodes = Engine.instance.nodesByType[typeof(MoveKynematicNode)];

            Vector2 movement = new Vector2();
            
            if (Engine.instance.keyPressed.Contains(Keys.Left))
            {
                movement += new Vector2(-time, 0);
            }
            if (Engine.instance.keyPressed.Contains(Keys.Right))
            {
                movement += new Vector2(time, 0);
            }
            //if (Engine.instance.keyPressed.Contains(Keys.Up))
            //{
            //    movement += new Vecteur2D(0, -time);
            //}
            //if (Engine.instance.keyPressed.Contains(Keys.Down))
            //{
            //    movement += new Vecteur2D(0, time);
            //}

            foreach (MoveKynematicNode node in moveNodes)
            {
                // Clip movement to the screen without blocking one axis when the other tries to get out of bounds
                Vector2 newPosition = node.TransformComponent.Position + (movement * node.VelocityComponent.Velocity);
                newPosition.x = Maths.Clamp(newPosition.x, 0, RenderForm.instance.Width - node.RenderComponent.Images.Width);
                newPosition.y = Maths.Clamp(newPosition.y, 0, RenderForm.instance.Height - node.RenderComponent.Images.Height);
                node.TransformComponent.Position = newPosition;
            }
        }
    }
}
