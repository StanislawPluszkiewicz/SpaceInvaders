using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems
{
    class SystemManager
    {
        public List<System> systems;

        public void AddSystem(System system, int priority=1)
        {
            systems.Add(system);
            // TODO priority
        }

        public void RemoveSystem(System system)
        {
            try
            {
               systems.Remove(system);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("SystemManager has no system " + system.GetType().Name);
                throw new KeyNotFoundException(e.Message);
            }
        }

        public void update(double time)
        {
            foreach (System system in systems)
            {
                system.Update(time);
            }
        }
    }
}
