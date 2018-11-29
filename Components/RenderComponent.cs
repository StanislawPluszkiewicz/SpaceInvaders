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
        public Vector2D View { get; set; }

        #region trail

        public bool HasTrail = false;
        public Image TrailImage{ get; set; }
        public Vector2D TrailOffset { get; set; }
        public List<Vector2D> TrailPositions { get; set; }
        private int TrailSize = 200;
        public void SetTrail(Image trailImage, Vector2D trailOffset)
        {
            TrailOffset = trailOffset;
            TrailImage = trailImage;
            HasTrail = true;
        }

        internal void UpdateTrail(Vector2D position)
        {
            if (TrailPositions.Count > TrailSize)
            {
                TrailPositions.RemoveAt(TrailSize);
            }
            TrailPositions.Insert(0, position + TrailOffset + new Vector2D(0, + Image.Size.Height / 2));
        }
        #endregion trail
        public RenderComponent(Entity e, Image image) : base(e)
        {
            Image = image;
            TrailPositions = new List<Vector2D>();
            View = new Vector2D(0, 0);
        }
    }
}
