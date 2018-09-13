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
        List<RenderNode> renderNodes;
        RenderForm form = null;

        public RenderSystem()
        {
            renderNodes = new List<RenderNode>();
            form = RenderForm.CreateRenderForm();
        }


        public void Update(double time)
        {
            foreach(RenderNode target in renderNodes)
            {
                
            }
        }
    }
}
