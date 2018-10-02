using SpaceInvaders.Components;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class Missile : Moveable, IDynamic
    {
        public Missile(GameObject e) : base(Image.FromFile("../../Resources/shoot2.png"))
        {
            TransformComponent parentTransform = e.GetComponent(typeof(TransformComponent)) as TransformComponent;
            TransformComponent transform = GetComponent(typeof(TransformComponent)) as TransformComponent;
            transform.Position = parentTransform.Position;

            VelocityComponent velocity = GetComponent(typeof(VelocityComponent)) as VelocityComponent;
            velocity.Acceleration.x = 0;
            velocity.Acceleration.y = 1.2;

            velocity.Velocity.x = 0;
            velocity.Velocity.y = -75;

        }
    }
}
