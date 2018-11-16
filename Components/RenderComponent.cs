using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Components
{
    class RenderComponent : Component
    // Entities that have this component will be rendered
    {
        public Image Image { get; set; }
        public Vecteur2D View { get; set; }

        #region trail

        public bool HasTrail = false;
        public Image TrailImage{ get; set; }
        public Vecteur2D TrailOffset { get; set; }
        public List<Vecteur2D> TrailPositions { get; set; }
        private int TrailSize = 200;
        public void SetTrail(Image trailImage, Vecteur2D trailOffset)
        {
            TrailOffset = trailOffset;
            TrailImage = trailImage;
            HasTrail = true;
        }

        internal void UpdateTrail(Vecteur2D position)
        {
            if (TrailPositions.Count > TrailSize)
            {
                TrailPositions.RemoveAt(TrailSize);
            }
            TrailPositions.Insert(0, position + TrailOffset + new Vecteur2D(0, + Image.Size.Height / 2));
        }
        #endregion trail
        public RenderComponent(Entity e, Image image) : base(e)
        {
            Image = image;
            TrailPositions = new List<Vecteur2D>();
            View = new Vecteur2D(0, 0);
        }
    }
}
