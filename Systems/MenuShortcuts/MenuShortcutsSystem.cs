using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders.Systems.Collision
{
    class MenuShortcutsSystem : ISystem
    {

        public List<Node> nodes;

        public void Update(double time)
        {
            nodes = Engine.instance.nodesByType[typeof(MenuShortcutsNode)];

            // Pause
            if (Engine.instance.keyPressed.Contains(Keys.P))
            {
                Engine.instance.Pause = !Engine.instance.Pause;
                Engine.instance.keyPressed.Remove(Keys.P);
            }

            if (Engine.instance.keyPressed.Contains(Keys.Escape))
            {
                Engine.instance.Pause = !Engine.instance.Pause;
                Engine.instance.keyPressed.Remove(Keys.Escape);
            }
        }
    }
}
