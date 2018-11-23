using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Systems.Collision
{
    class CollisionSystem : ISystem
    {

        public List<Node> nodes;
        private bool[,] collideableTruthTable;

        public CollisionSystem()
        {
            InitializeCollisionTruthTable();
        }

        private void InitializeCollisionTruthTable()
        {
            collideableTruthTable = new bool[Enum.GetNames(typeof(CollisionTag)).Length, Enum.GetNames(typeof(CollisionTag)).Length];
            SetCollisionTag(CollisionTag.PLAYER, CollisionTag.ENNEMI, true);
            SetCollisionTag(CollisionTag.PLAYER, CollisionTag.ENNEMI_MISSILE, true);
            SetCollisionTag(CollisionTag.ENNEMI, CollisionTag.PLAYER_MISSILE, true);
            SetCollisionTag(CollisionTag.PLAYER_MISSILE, CollisionTag.ENNEMI_MISSILE, true);
            //SetCollisionCollisionTag(CollisionTag.ENNEMI_MISSILE, CollisionTag.BUNKER, true);
        }
        private void SetCollisionTag (CollisionTag t1, CollisionTag t2, bool value)
        {
            collideableTruthTable[(int)t1, (int)t2] = value;
            collideableTruthTable[(int)t2, (int)t1] = value;
        }
        
        private bool CanCollide(CollisionTag t1, CollisionTag t2)
        {
            return collideableTruthTable[(int)t1, (int)t2];
        }

        public void Update(double time)
        {
            nodes = Engine.instance.nodesByType[typeof(CollisionNode)];

            for(int iOrigin = 0; iOrigin < nodes.Count; iOrigin++)
            {
                CollisionNode origin = nodes[iOrigin] as CollisionNode;
                if (origin == null) { continue; } // if cast failed
                for (int iOther = 0; iOther < nodes.Count; iOther++)
                {
                    CollisionNode other = nodes[iOther] as CollisionNode;
                    if (other == null || origin == other) { continue; } // if cast failed
                    if (CanCollide(origin.CollisionComponent.Tag, other.CollisionComponent.Tag))
                    {
                        if (origin.CollisionComponent.Hitbox.Collides(other.CollisionComponent.Hitbox))
                        {
                            switch (origin.CollisionComponent.State)
                            {
                                case CollisionState.NotColliding:
                                    origin.CollisionComponent.onCollisionEnter(other.CollisionComponent.entity);
                                    origin.CollisionComponent.State = CollisionState.Colliding;
                                    break;
                                case CollisionState.Colliding:
                                    origin.CollisionComponent.onCollisionStay(other.CollisionComponent.entity);
                                    break;
                            }
                        }
                        else
                        {

                            if (origin.CollisionComponent.State == CollisionState.Colliding)
                            {
                                origin.CollisionComponent.State = CollisionState.NotColliding;
                                origin.CollisionComponent.onCollisionExit(other.CollisionComponent.entity);
                                // other might be colliding with another object 
                            }
                        }
                    }
                }
            }
        }
    }
}
