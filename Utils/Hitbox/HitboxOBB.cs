using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Utils.Hitbox
{
    /// <summary>
    /// 
    /// Supports oriented boundary box hitbox
    /// </summary>
    class HitboxOBB : IHitbox
    {
        // TODO, implement one day :)

        public List<Vector2D> points;
        private List<Edge> edges;

        public HitboxOBB(params Vector2D[] _points)
        {
            points = new List<Vector2D>();
            edges = new List<Edge>();
            foreach (Vector2D point in _points)
            {
                points.Add(point);
            }
            if (points.Count == 4)
            {
                edges.Add(new Edge(0, 1));
                edges.Add(new Edge(1, 2));
                edges.Add(new Edge(2, 3));
                edges.Add(new Edge(3, 0));
            }
        }

        public bool Collides(IHitbox _other)
        {
            //if (_other is HitboxOBB)
            //{
            //    HitboxOBB other = _other as HitboxOBB;

            //    foreach (Edge edge in edges)
            //    {
            //        Vector2D origin = points[edge.a];
            //        Vector2D dest = points[edge.b];
            //        foreach(Vector2D u in points)
            //        {
            //            if (u == origin || u == dest) { continue; }

            //        }
            //    }
            //}
            throw new NotImplementedException();
        }

        public Collision DetailedCollision(CollisionComponent otherCollisionComponent)
        {
            throw new NotImplementedException();
        }

    }

    internal class Edge
    {
        public int a;
        public int b;

        public Edge(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
