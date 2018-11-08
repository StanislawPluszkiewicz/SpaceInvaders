using SpaceInvaders.Components;
using SpaceInvaders.Systems.Collision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    abstract class Collidable : Moveable
    {
        public Collidable(Image image, CollisionSystem.Tag tag) : base(image)
        {
            AddComponent(new CollisionComponent(this, tag));
        }
        
    }
}
