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
        RenderComponent RenderComponent { get; set; }
        TransformComponent TransformComponent { get; set; }

        public CollisionNode(GameObject entity)
        {
            RenderComponent = entity.GetComponent(typeof(RenderComponent)) as RenderComponent;
            TransformComponent = entity.GetComponent(typeof(TransformComponent)) as TransformComponent;
        }

        public new static bool HasToBeCreated(GameObject entity) => entity.GetType().GetInterfaces().Contains(typeof(ICollidable));

    }
}
