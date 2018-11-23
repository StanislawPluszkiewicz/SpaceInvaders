﻿using SpaceInvaders.Entities;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Systems.Move.MoveKynematicObject
{
    class MoveDynamicSystem : ISystem
    {
        private List<Node> moveNodes;

        public void Update(double time)
        {
            Engine engine = Engine.instance;
            moveNodes = Engine.instance.nodesByType[typeof(MoveDynamicNode)];

            foreach (MoveDynamicNode node in moveNodes)
            {
                node.TransformComponent.Position += time * node.VelocityComponent.Velocity;
                
                if (node.RenderComponent.HasTrail)
                {
                    node.RenderComponent.UpdateTrail(node.TransformComponent.Position);
                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../Resources/anim/missile_sound.wav");
                    //player.Play();
                }
            }
        }
    }
}
