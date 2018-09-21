using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Systems.Render
{
    public class RenderSystem : ISystem
    {
        RenderForm form = null;

        public RenderSystem()
        {
            form = RenderForm.instance;
        }


        public void Update(double time)
        {
            foreach(RenderNode target in Engine.instance.nodesByType[typeof(RenderNode)])
            {
                RenderForm.Render(Engine.instance.BufferedGraphics.Graphics, target);
            }
        }
    }
}
