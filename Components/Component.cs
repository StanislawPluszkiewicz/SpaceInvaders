using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{

    // <summary>
    // Contains only data relevant for an Entity
    // </summary>
    class Component {
        public Entity Entity;
        public Component(Entity e)
        {
            Entity = e;
        }
    }
}
