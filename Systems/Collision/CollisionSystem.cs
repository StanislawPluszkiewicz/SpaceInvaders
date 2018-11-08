using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Collision
{
    class CollisionSystem : ISystem
    {

        public List<Node> nodes;
        public enum Tag { PLAYER=0, ENNEMI, PLAYER_MISSILE, ENNEMI_MISSILE };
        private bool[,] collideableTruthTable;

        public CollisionSystem()
        {
            collideableTruthTable = new bool[Enum.GetNames(typeof(Tag)).Length, Enum.GetNames(typeof(Tag)).Length];
            SetCollisionTag(Tag.PLAYER, Tag.ENNEMI, true);
            SetCollisionTag(Tag.PLAYER, Tag.ENNEMI_MISSILE, true);
            SetCollisionTag(Tag.ENNEMI, Tag.PLAYER_MISSILE, true);
            SetCollisionTag(Tag.PLAYER_MISSILE, Tag.ENNEMI_MISSILE, true);
        }

        private void SetCollisionTag (Tag t1, Tag t2, bool value)
        {
            collideableTruthTable[(int)t1, (int)t2] = value;
            collideableTruthTable[(int)t2, (int)t1] = value;
        }

        public void Update(double time)
        {
            nodes = Engine.instance.nodesByType[typeof(CollisionNode)];


        }
    }
}
