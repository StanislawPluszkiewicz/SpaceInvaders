using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.GeometricForms
{
    public class OrientedBoundedBox
    {
        private Vector2[] _points;
        public Vector2[] Points { get => _points; set => _points = value; }
        public OrientedBoundedBox(params Vector2[] points)
        {
            Points = new Vector2[4];
            if (points.Count() != 4)
            {
                throw new Exception("Oritented Bounded Box must have 4 points");
            }
            else
            {
                Points = points;
            }
        }

    }
}
