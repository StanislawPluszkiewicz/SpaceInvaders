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

        public ShootNode(GameObject entity)
        {
            MissileComponent = entity.GetComponent(typeof(MissileComponent)) as MissileComponent;
        }

        public new static bool HasToBeCreated(GameObject entity) => entity.GetType() == typeof(Player);
    }
}
