using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class MissileComponent : Component
    {
        public MissileComponent(GameObject e, double damage = 1, double fireRate = 1) : base(e)
        {
            Damage = damage;
            FireRate = fireRate;
            TimeSinceLastShoot = 0;
        }

        public double Damage { get; set; }
        public double FireRate { get; set; } // shoots per second
        public double TimeSinceLastShoot { get; set; }

    }
}
