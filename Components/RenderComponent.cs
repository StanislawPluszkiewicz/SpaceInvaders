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
        public List<LocatedImage> Images { get; set; }
        public Vector2 View { get; set; }
        public int Width{ get; private set; }
        public int Height { get; private set; }

        #region trail

        public bool HasTrail = false;
        public Image TrailImage{ get; set; }
        public Vector2 TrailOffset { get; set; }
        public List<Vector2> TrailPositions { get; set; }
        private int TrailSize = 200;
        public void SetTrail(Image trailImage, Vector2 trailOffset)
        {
            TrailOffset = trailOffset;
            TrailImage = trailImage;
            HasTrail = true;
        }

        internal void UpdateTrail(Vector2 position)
        {
            if (TrailPositions.Count > TrailSize)
            {
                TrailPositions.RemoveAt(TrailSize);
            }
            TrailPositions.Insert(0, position + TrailOffset + new Vector2(0, + Images.Size.Height / 2));
        }
        #endregion trail
        public RenderComponent(Entity e, params LocatedImage[] images) : base(e)
        {
            Images = image;
            TrailPositions = new List<Vector2>();
            View = new Vector2(0, 0);
        }
    }

    public class LocatedImage
    {
        public LocatedImage(Image image, Vector2 location)
        {
            Image = image;
            Location = location;
        }

        public Image Image { get; set; }
        public Vector2 Location { get; set; }
        public int Height
        {
            get
            {
                return Image.Height;
            }
        }
        public int Width
        {
            get
            {
                return Image.Width;
            }
        }
    }
}
