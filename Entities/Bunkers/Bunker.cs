using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Systems.Collision;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Entities
{
    class Bunker : Collidable, IStatic
    {
        public Bunker(Image image) : base(image, CollisionTag.BUNKER)
        {

        }
    }
}
