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
        protected GameObject entity;
        public Component(GameObject e)
        {
            entity = e;
        }
    }
}
