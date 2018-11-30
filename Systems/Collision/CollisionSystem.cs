using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;
using static SpaceInvaders.Utils.Hitbox.Hitbox;

namespace SpaceInvaders.Systems.Collision
{
    class CollisionSystem : ISystem
    {
        public static readonly bool DEBUG = false;

        public List<Node> nodes;
        private bool[,] collideableTruthTable;
        private Dictionary<CollisionTag, List<CollisionTag>> canCollideWith;
        //private Dictionary<CollisionTag, List<CollisionNode>> segmentedNodes;

        public object CollisionState { get; private set; }

        public CollisionSystem()
        {
            canCollideWith = new Dictionary<CollisionTag, List<CollisionTag>>();
            foreach (CollisionTag tag in (CollisionTag[])Enum.GetValues(typeof(CollisionTag)))
            {
                canCollideWith[tag] = new List<CollisionTag>();
            }
            collideableTruthTable = new bool[Enum.GetNames(typeof(CollisionTag)).Length, Enum.GetNames(typeof(CollisionTag)).Length];

            SetCollisionTag(CollisionTag.PLAYER, CollisionTag.ENNEMI_MISSILE, true);
            SetCollisionTag(CollisionTag.ENNEMI, CollisionTag.PLAYER_MISSILE, true);
            SetCollisionTag(CollisionTag.PLAYER_MISSILE, CollisionTag.ENNEMI_MISSILE, true);
            SetCollisionTag(CollisionTag.ENNEMI_MISSILE, CollisionTag.BUNKER, true);
            SetCollisionTag(CollisionTag.PLAYER_MISSILE, CollisionTag.BUNKER, true);
        }

        private void SetCollisionTag (CollisionTag t1, CollisionTag t2, bool value)
        {
            collideableTruthTable[(int)t1, (int)t2] = value;
            collideableTruthTable[(int)t2, (int)t1] = value;
            canCollideWith[t1].Add(t2);
            canCollideWith[t2].Add(t1);
        }
        
        private bool CanCollide(CollisionTag t1, CollisionTag t2)
        {
            return collideableTruthTable[(int)t1, (int)t2];
        }

        public void Update(double time)
        {
            nodes = Engine.instance.nodesByType[typeof(CollisionNode)];
            //segmentedNodes = new Dictionary<CollisionTag, List<CollisionNode>>();
            //foreach (CollisionTag tag in (CollisionTag[])Enum.GetValues(typeof(CollisionTag)))
            //{
            //    segmentedNodes[tag] = new List<CollisionNode>();
            //}
            //foreach (CollisionNode node in nodes)
            //{
            //    segmentedNodes[node.CollisionComponent.Tag].Add(node);
            //}

            //int iterations = 0;
            //foreach (CollisionTag originTag in (CollisionTag[])Enum.GetValues(typeof(CollisionTag)))
            //{
            //    for (int iOrigin = 0; iOrigin < segmentedNodes[originTag].Count; iOrigin++)
            //    {
            //        CollisionNode origin = segmentedNodes[originTag][iOrigin] as CollisionNode;
            //        foreach (CollisionTag otherTag in (CollisionTag[])Enum.GetValues(typeof(CollisionTag)))
            //        {
            //            for (int iOther = 0; iOther < segmentedNodes[otherTag].Count; iOther++)
            //            {
            //                CollisionNode other = segmentedNodes[otherTag][iOther] as CollisionNode;
            //                if (origin != other)
            //                {
            //                    iterations++;
            //                    CheckCollision(origin, other);
            //                }
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine("1ere methode: {0} iterations", iterations);

            for (int iOrigin = 0; iOrigin < nodes.Count; iOrigin++)
            {
                if (Engine.instance.nodesByType[typeof(CollisionNode)].Contains(nodes[iOrigin]))
                {

                    for (int iOther = 0; iOther < nodes.Count; iOther++)
                    {

                        if (Engine.instance.nodesByType[typeof(CollisionNode)].Contains(nodes[iOther]))
                        {
                            if (iOrigin != iOther)
                            {
                                CheckCollision((CollisionNode)nodes[iOrigin], (CollisionNode)nodes[iOther]);
                            }
                        }
                    }
                }
                
            }
        }


        private void CheckCollision(CollisionNode origin, CollisionNode other)
        {
            if (CanCollide(origin.CollisionComponent.Tag, other.CollisionComponent.Tag))
            {
                if (origin.CollisionComponent.Hitbox.MayBeColliding(other.CollisionComponent.Hitbox))
                {
                    Utils.Collision collision = origin.CollisionComponent.Hitbox.GetCollision(other.CollisionComponent);
                    origin.CollisionComponent.Hitbox.CollidingWith.Add(other.CollisionComponent);
                    switch (origin.CollisionComponent.Hitbox.State)
                    {
                        case HitboxState.NOT_COLLIDING:
                            origin.CollisionComponent.onCollisionEnter(collision);
                            origin.CollisionComponent.Hitbox.State = HitboxState.COLLIDING;
                            break;
                        case HitboxState.COLLIDING:
                            origin.CollisionComponent.onCollisionStay(collision);
                            break;
                    }
                }
                else
                {

                    if (origin.CollisionComponent.Hitbox.State == HitboxState.COLLIDING && origin.CollisionComponent.Hitbox.CollidingWith.Contains(other.CollisionComponent))
                    {
                        Utils.Collision collision = origin.CollisionComponent.Hitbox.GetCollision(other.CollisionComponent);
                        origin.CollisionComponent.Hitbox.CollidingWith.Remove(other.CollisionComponent);
                        if (origin.CollisionComponent.Hitbox.CollidingWith.Count == 0)
                        {
                            origin.CollisionComponent.Hitbox.State = HitboxState.NOT_COLLIDING;
                        }
                        origin.CollisionComponent.onCollisionExit(collision);
                    }
                }
            }
        }

    }
}
