using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders.Systems.Shoot
{
    class ShootSystem : ISystem
    {
        List<Node> nodes;

        public void Update(double time)
        {
            nodes = Engine.instance.nodesByType[typeof(ShootNode)];
            bool shoot = false;
            if (Engine.instance.keyPressed.Contains(Keys.Space))
            {
                shoot = true;
            }

            foreach (ShootNode node in nodes)
            {
                node.MissileComponent.TimeSinceLastShoot += time;
                if (shoot && node.MissileComponent.TimeSinceLastShoot >= node.MissileComponent.FireRate)
                {
                    node.MissileComponent.TimeSinceLastShoot = 0;
                    GameObject e = Engine.instance.GetEntityByNode(node);
                    Engine.instance.AddEntity(new Missile(e));
                }
            }
        }
    }
}
