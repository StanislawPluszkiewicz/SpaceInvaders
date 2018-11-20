using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Entities.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Collision
{
    class MenuShortcutsNode : Node
    {
        public MenuShortcutsNode(Entity entity)
        {
        }

        public new static bool HasToBeCreated(Entity entity) => entity.GetType() == typeof(MenuShortcutsManager);

    }
}
