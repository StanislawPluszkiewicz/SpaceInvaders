using SpaceInvaders.Components;
using SpaceInvaders.Entities.Collision;
using SpaceInvaders.Systems.Collision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    abstract class Collidable : Moveable, ICollidable
    {
        public Collidable(Image image, CollisionSystem.Tag tag) : base(image)
        {
            AddComponent(new CollisionComponent(this, tag));
        }
        
    }
}
