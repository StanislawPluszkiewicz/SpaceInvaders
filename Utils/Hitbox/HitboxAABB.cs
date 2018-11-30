using SpaceInvaders.Components;
using SpaceInvaders.Utils.GeometricForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    class HitboxAABB : IHitbox
    {
        public AxisAlignedBoundedBox box;

        public Vector2 Position { 
            get
            {
                return new Vector2(this.box.x, this.box.y);
            }
            set
            {
                box.x = value.x;
                box.y = value.y;
            }
        }

        public HitboxAABB(double x, double width, double y, double height)
        {
            box = new AxisAlignedBoundedBox(x, width, y, height);
        }

        public bool Collides(IHitbox _other)
        {
            if (_other is HitboxAABB)
            {
                HitboxAABB other = _other as HitboxAABB;
                bool test = !(
                ((box.x > other.box.x + other.box.Width) || (box.x + box.Width < other.box.x)) ||
                ((box.y > other.box.y + other.box.Height) || (box.y + box.Height < other.box.y)));
                if (test)
                {
                    Console.WriteLine(test);
                }
                return test;
            }
            throw new NotImplementedException();

        }

        public Collision DetailedCollision(IHitbox other)
        {
            if (other is HitboxAABB)
            {
                AxisAlignedBoundedBox otherBox = ((HitboxAABB)other).box;
                double x = Math.Max(box.x, otherBox.x);
                double w = Math.Min(box.x + box.Width, otherBox.x + otherBox.Width) - x;
                double y = Math.Max(box.y, otherBox.y);
                double h = Math.Min(box.y + box.Height, otherBox.y + otherBox.Height) - y;

                return new Collision(new AxisAlignedBoundedBox(x, w, y, h));
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    
}
