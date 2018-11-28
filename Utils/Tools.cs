using SpaceInvaders.Components;
using SpaceInvaders.Utils.Hitbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Tools
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scrBitmap"></param>
        /// <param name="rectToColor">Relative to image</param>
        /// <returns></returns>
        public static bool ChangeAABBColor(RenderComponent renderComponent, Vecteur4 rectToColor)
        {
            Color actualColor;
            bool bitmapHasChanged = false;
            for (int i = (int)rectToColor.X; i < (int)rectToColor.XPlusWidth; i++)
            {
                for (int j = (int)rectToColor.Y; j < (int)rectToColor.YPlusHeight; j++)
                {
                    actualColor = ((Bitmap)renderComponent.Image).GetPixel(i, j);
                    if (actualColor.A == 255 && actualColor.R == 0 && actualColor.B == 0 && actualColor.G == 0)
                    {
                        ((Bitmap)renderComponent.Image).SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                        bitmapHasChanged = true;
                    }

                }
            }
            return bitmapHasChanged;
        }
    }
}
