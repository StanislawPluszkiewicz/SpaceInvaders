using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Ennemi : Kynematic
    {

        public Ennemi() : base(Image.FromFile("../../Resources/ship1.png"))
        {
            TransformComponent transform = (TransformComponent)this.GetComponent(typeof(TransformComponent));
            RenderForm instance = RenderForm.instance;
            transform.Position.x = RenderForm.instance.Size.Width * 1 / 3;
            transform.Position.y = RenderForm.instance.Size.Width * 2 / 5;


            VelocityComponent velocity = (VelocityComponent)this.GetComponent(typeof(VelocityComponent));

            velocity.Velocity.x = 0.75;
            velocity.Velocity.y = 0;

        }
    }
}
