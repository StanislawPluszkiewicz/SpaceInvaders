using SpaceInvaders.Systems.Render;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems
{
    class SystemManager
    {

        public List<ISystem> systems;
        public RenderSystem renderSystem;

        /// <summary>
        /// Game watch
        /// </summary>
        Stopwatch watch = new Stopwatch();

        /// <summary>
        /// Last update time
        /// </summary>
        long lastTime = 0;

        int MAX_DELTA = 5; // 5ms between frames

        public SystemManager()
        {
            systems = new List<ISystem>();
        }

        public void AddSystem(ISystem system)
        {
            if (system.GetType() == typeof(RenderSystem))
            {
                renderSystem = (RenderSystem)system;
            }else
            {
                systems.Add(system);
            }
        }

        public void RemoveSystem(ISystem system)
        {
            try
            {
                if (system.GetType() == typeof(RenderSystem))
                {
                    renderSystem = null;
                }
                else
                {
                    systems.Remove(system);
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("SystemManager has no system " + system.GetType().Name);
                throw new KeyNotFoundException(e.Message);
            }
        }

        public void update()
        {
            int maxDelta = 5;
            long nt = watch.ElapsedMilliseconds;
            double deltaT = (nt - lastTime);

            for (; deltaT >= maxDelta; deltaT -= maxDelta)
            {
                foreach (ISystem system in systems)
                {
                    system.Update(deltaT);
                }
                renderSystem.Update(deltaT);
            }
            
            lastTime = nt;
            RenderForm.CreateRenderForm().Invalidate();
        }
    }
}

