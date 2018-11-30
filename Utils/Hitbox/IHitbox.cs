using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    


    interface IHitbox
    {

        Vector2 Position { get; set; }
        bool Collides(IHitbox _other);
        Collision DetailedCollision(IHitbox other);
    }
}
