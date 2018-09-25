using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Player : Kynematic
    {
        public Player() : base(Image.FromFile("../../Resources/ship1.png"))
        {
            TransformComponent transform = (TransformComponent)this.GetComponent(typeof(TransformComponent));
            transform.Position.x = RenderForm.instance.Size.Width / 2;
            transform.Position.y = RenderForm.instance.Size.Width * 4 / 5;


            VelocityComponent velocity = (VelocityComponent)this.GetComponent(typeof(VelocityComponent));

            velocity.Velocity.x = 1;
            velocity.Velocity.y = 0;
        }
    }
}
