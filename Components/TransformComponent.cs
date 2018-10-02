using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class TransformComponent : Component
    {
        private Vecteur2D position;
        public Vecteur2D Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                RenderComponent renderComponent = (RenderComponent)this.entity.GetComponent(typeof(RenderComponent));
                renderComponent.View = position;
            }
        }
        public Vecteur2D Rotation { get; set; }
        public Vecteur2D LocalScale { get; set; }

        public TransformComponent(GameObject e) : base(e)
        {
            position = new Vecteur2D(0,0);
            Rotation = new Vecteur2D(0, 0);
            LocalScale = new Vecteur2D(1, 1);
        }
    }
}
