using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    public class Vector2
    {

        /// <summary>
        /// Points
        /// </summary>
        public double x, y;
        public double Norme
        {
            get
            {
                return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            }
        }

        public double Dot(Vector2 other)
        {
            return x * other.x + y * other.y;
        }

        public Vector2 OrthogonalProjection(Vector2 point)
        // projects point on this
        {
            return (this.Dot(point) / point.Norme) * point;
        }
        public Vector2(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }

        public static Vector2 operator+ (Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator- (Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator- (Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator* (double k, Vector2 v)
        {
            return new Vector2(k * v.x, k * v.y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector2 operator* (Vector2 v, double k)
        {
            return new Vector2(k * v.x, k * v.y);
        }

        public static Vector2 operator/ (Vector2 v, double k)
        {
            if (k == 0)
                throw new DivideByZeroException("Divison par zero invalide!");
            return new Vector2(v.x / k, v.y / k);
        }
    }

    
}
