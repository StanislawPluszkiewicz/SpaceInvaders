﻿using SpaceInvaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class MissileComponent : Component
    {
        public MissileComponent(Entity e, double damage = 1, double fireRate = 1) : base(e)
        {
            Damage = damage;
            FireRate = fireRate;
            TimeSinceLastShoot = 0;
            ShootProbability = BaseShootProbability = 1;
            ShootProbabilityIncrementation = 0.1f;
        }

        public double BaseShootProbability { get; set; } 
        public double ShootProbability { get; set; }
        public double ShootProbabilityIncrementation { get; set; }
        public double Damage { get; set; }
        public double FireRate { get; set; } // shoots per second
        public double TimeSinceLastShoot { get; set; }

    }
}
