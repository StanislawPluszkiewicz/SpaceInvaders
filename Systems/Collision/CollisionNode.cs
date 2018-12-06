using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Collision
{
    class CollisionNode : Node
    {
        public CollisionComponent CollisionComponent { get; set; }

        public CollisionNode(Entity entity)
        {
            CollisionComponent = entity.Components[typeof(CollisionComponent)] as CollisionComponent;
        }

        public new static bool HasToBeCreated(Entity entity) => entity is Collidable;

    }
}
