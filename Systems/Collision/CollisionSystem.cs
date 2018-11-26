using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static SpaceInvaders.Components.CollisionComponent;

namespace SpaceInvaders.Systems.Collision
{
    class CollisionSystem : ISystem
    {

        public List<Node> nodes;
        public static readonly bool DEBUG = true;
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
            SetCollisionTag(CollisionTag.ENNEMI_MISSILE, CollisionTag.BUNKER, true);
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
                    if (other == null || iOrigin == iOther) { continue; } // if cast failed
                    if (CanCollide(origin.CollisionComponent.Tag, other.CollisionComponent.Tag))
                    {
                        if (origin.CollisionComponent.Hitbox.Collides(other.CollisionComponent.Hitbox))
                        {
                            origin.CollisionComponent.CollidingWith.Add(other.CollisionComponent);
                            switch (origin.CollisionComponent.State)
                            {
                                case CollisionState.NotColliding:
                                    origin.CollisionComponent.onCollisionEnter(other.CollisionComponent.entity);
                                    origin.CollisionComponent.State = CollisionState.Colliding;
                                    Utils.Collision collision = origin.CollisionComponent.Hitbox.DetailedCollision(other.CollisionComponent);
                                    Console.WriteLine("position x {0} y {1}", origin.TransformComponent.Position.x, origin.TransformComponent.Position.y);
                                    Console.WriteLine("image width {0} height {1}", origin.RenderComponent.Image.Width, origin.RenderComponent.Image.Height);
                                    Console.WriteLine("contact");
                                    Console.WriteLine("\t x {0} width {1}", collision.Contacts.X - origin.TransformComponent.Position.x, collision.Contacts.XPlusWidth - collision.Contacts.X);
                                    Console.WriteLine("\t y {0} height {1}", collision.Contacts.Y, collision.Contacts.YPlusHeight - collision.Contacts.Y);

                                    Vecteur4 rectToRecolorRelativeToEntity = new Vecteur4(collision.Contacts.Y - origin.TransformComponent.Position.y, collision.Contacts.Y - origin.TransformComponent.Position.y + collision.Contacts.YPlusHeight - collision.Contacts.Y, collision.Contacts.X - origin.TransformComponent.Position.x, collision.Contacts.X - origin.TransformComponent.Position.x + collision.Contacts.XPlusWidth - collision.Contacts.X);
                                    other.RenderComponent.Image = Tools.ChangeColor(other.RenderComponent.Image, collision.Contacts);
                                    break;
                                case CollisionState.Colliding:
                                    origin.CollisionComponent.onCollisionStay(other.CollisionComponent.entity);
                                    break;
                            }
                        }
                        else
                        {

                            if (origin.CollisionComponent.State == CollisionState.Colliding && origin.CollisionComponent.CollidingWith.Contains(other.CollisionComponent))
                            {
                                origin.CollisionComponent.State = CollisionState.NotColliding;
                                origin.CollisionComponent.onCollisionExit(other.CollisionComponent.entity);
                                origin.CollisionComponent.CollidingWith.Remove(other.CollisionComponent);
                                // other might be colliding with another object 
                            }
                        }
                    }
                }
            }
        }


    }
}
