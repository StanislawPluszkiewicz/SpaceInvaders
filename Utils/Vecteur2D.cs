using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Vector2D
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

        public double Dot(Vector2D other)
        {
            return x * other.x + y * other.y;
        }

        public Vector2D OrthogonalProjection(Vector2D point)
        // projects point on this
        {
            return (this.Dot(point) / point.Norme) * point;
        }
        public Vector2D(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }

        public static Vector2D operator+ (Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator- (Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator- (Vector2D v)
        {
            return new Vector2D(-v.x, -v.y);
        }

        public static Vector2D operator* (double k, Vector2D v)
        {
            return new Vector2D(k * v.x, k * v.y);
        }

        public static Vector2D operator *(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector2D operator* (Vector2D v, double k)
        {
            return new Vector2D(k * v.x, k * v.y);
        }

        public static Vector2D operator/ (Vector2D v, double k)
        {
            if (k == 0)
                throw new DivideByZeroException("Divison par zero invalide!");
            return new Vector2D(v.x / k, v.y / k);
        }
    }

    
}
