using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Vecteur2D
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


        public Vecteur2D(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }

        public static Vecteur2D operator+ (Vecteur2D v1, Vecteur2D v2)
        {
            return new Vecteur2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vecteur2D operator- (Vecteur2D v1, Vecteur2D v2)
        {
            return new Vecteur2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vecteur2D operator- (Vecteur2D v)
        {
            return new Vecteur2D(-v.x, -v.y);
        }

        public static Vecteur2D operator* (double k, Vecteur2D v)
        {
            return new Vecteur2D(k * v.x, k * v.y);
        }

        public static Vecteur2D operator *(Vecteur2D v1, Vecteur2D v2)
        {
            return new Vecteur2D(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vecteur2D operator* (Vecteur2D v, double k)
        {
            return new Vecteur2D(k * v.x, k * v.y);
        }

        public static Vecteur2D operator/ (Vecteur2D v, double k)
        {
            if (k == 0)
                throw new DivideByZeroException("Divison par zero invalide!");
            return new Vecteur2D(v.x / k, v.y / k);
        }

    }

    
}
