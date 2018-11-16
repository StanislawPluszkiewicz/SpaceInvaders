using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Entities.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Collision
{
    class CollisionNode : Node
    {
        public RenderComponent RenderComponent { get; set; }
        public TransformComponent TransformComponent { get; set; }
        public CollisionComponent CollisionComponent { get; set; }

        public CollisionNode(Entity entity)
        {
            RenderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
            TransformComponent = entity.GetComponent(typeof(TransformComponent)) as TransformComponent;
            CollisionComponent = entity.GetComponent(typeof(CollisionComponent)) as CollisionComponent;
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType().GetInterfaces().Contains(typeof(ICollidable));

    }
}
