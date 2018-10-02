using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Ennemi : Moveable, IDynamic
    {
        public Ennemi() : base(Image.FromFile("../../Resources/pacman.png"))
        {
            //TransformComponent transform = (TransformComponent)this.GetComponent(typeof(TransformComponent));
            //RenderForm instance = RenderForm.instance;
            //transform.Position.x = RenderForm.instance.Size.Width * 1 / 3;
            //transform.Position.y = RenderForm.instance.Size.Width * 2 / 5;

            VelocityComponent velocity = (VelocityComponent)this.GetComponent(typeof(VelocityComponent));

            velocity.Velocity.x = 50;
            velocity.Velocity.y = 0;

        }
    }
}
