using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities.Missiles
{
    class PlayerMissile : Missile
    {
        public PlayerMissile(GameObject e, Image imageTrail = null, Vecteur2D trailOffset = null) : 
            base(e, Image.FromFile("../../Resources/anim/nyan_cat.gif"), CollisionSystem.Tag.PLAYER_MISSILE, Image.FromFile("../../Resources/anim/rainbow_trail.png"), new Vecteur2D(1, 1))
        {

        }
    }
}
