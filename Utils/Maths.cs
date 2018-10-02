using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Maths
    {
        public static double Clamp(double value, double start, double end)
        {
            if (value < start)
            {
                value = start;
            }
            else if (value > end)
            {
                value = end;
            }
            return value;
        }
    }
}
