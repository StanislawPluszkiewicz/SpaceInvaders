using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Shoot
{
    class ShootNode : Node
    {
        public MissileComponent MissileComponent { get; set; }

        public ShootNode(Entity entity)
        {
            MissileComponent = entity.GetComponent(typeof(MissileComponent)) as MissileComponent;
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType() == typeof(Ennemi) || entity.GetType() == typeof(Player);
    }
}
