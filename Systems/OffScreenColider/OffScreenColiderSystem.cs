using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.OffScreenColider
{
    class OffScreenColiderSystem : ISystem
    {
        List<Node> nodes;

        public void Update(double time)
        {
            nodes = Engine.instance.nodesByType[typeof(OffScreenColiderNode)];
            for(int i = 0; i < nodes.Count; i++)
            {
                OffScreenColiderNode n = nodes[i] as OffScreenColiderNode;
                if (! RenderForm.instance.ObjectIsOnScreen(n.RenderComponent))
                {
                    Engine.instance.RemoveEntity(Engine.instance.GetEntityByNode(n));
                }
            }
        }
    }
}
