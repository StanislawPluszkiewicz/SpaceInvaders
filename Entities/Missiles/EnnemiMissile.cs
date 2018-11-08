using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Systems.Collision;

namespace SpaceInvaders.Entities.Missiles
{
    class EnnemiMissile : Missile
    {
        public EnnemiMissile(GameObject e) : base(e, Image.FromFile("../../Resources/shoot2.png"), CollisionSystem.Tag.ENNEMI_MISSILE)
        {
        }
    }
}
