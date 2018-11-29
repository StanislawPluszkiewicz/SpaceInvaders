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

            Vector2D movement = new Vector2D();
            
            if (Engine.instance.keyPressed.Contains(Keys.Left))
            {
                movement += new Vector2D(-time, 0);
            }
            if (Engine.instance.keyPressed.Contains(Keys.Right))
            {
                movement += new Vector2D(time, 0);
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
                Vector2D newPosition = node.TransformComponent.Position + (movement * node.VelocityComponent.Velocity);
                newPosition.x = Maths.Clamp(newPosition.x, 0, RenderForm.instance.Width - node.RenderComponent.Image.Width);
                newPosition.y = Maths.Clamp(newPosition.y, 0, RenderForm.instance.Height - node.RenderComponent.Image.Height);
                node.TransformComponent.Position = newPosition;
            }
        }
    }
}
