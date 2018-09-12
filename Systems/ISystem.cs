using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems
{
    abstract class System
    {
        // <summary>
        // Nodes on which the system acts
        // </summary>
        // List<Node> nodes;
        public virtual void Update(double time) { }
    }
}
