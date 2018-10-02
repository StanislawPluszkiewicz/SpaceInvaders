using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Player : Moveable, IKynematic
    {
        public Player() : base(Image.FromFile("../../Resources/player.png"))
        {
            AddComponent(new MissileComponent(this, 1, 1));

            TransformComponent transform = (TransformComponent)GetComponent(typeof(TransformComponent));
            transform.Position.x = RenderForm.instance.Size.Width / 2;
            transform.Position.y = RenderForm.instance.Size.Height * 4 / 5;

            VelocityComponent velocity = (VelocityComponent)GetComponent(typeof(VelocityComponent));
            velocity.Velocity.x = 400;
            velocity.Velocity.y = 400;
        }
    }
}
