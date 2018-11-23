using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Entities.Missiles;
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
        Random random;

        public ShootSystem()
        {
            random = new Random();
        }

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
                    
                Entity e = Engine.instance.GetEntityByNode(node);
                if (node.MissileComponent.TimeSinceLastShoot >= node.MissileComponent.FireRate)
                {
                    node.MissileComponent.TimeSinceLastShoot = 0;
                    if (e is Player && shoot)
                    {
                        Engine.instance.AddEntity(new PlayerMissile(e));
                    }
                    else if (e is Ennemi)
                    {
                        if (random.Next(0, 200) < node.MissileComponent.ShootProbability)
                        {
                            Engine.instance.AddEntity(new EnnemiMissile(e));
                            node.MissileComponent.ShootProbability = node.MissileComponent.BaseShootProbability;
                        }
                        else
                        {
                            node.MissileComponent.ShootProbability += node.MissileComponent.ShootProbabilityIncrementation;
                        }
                    }
                    

                }


            }
        }
    }
}
