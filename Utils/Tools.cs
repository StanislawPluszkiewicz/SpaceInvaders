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
        public static Image ChangeColor(Image scrBitmap, Vecteur4 rectToColor)
        {
            Console.WriteLine(rectToColor.X);
            Console.WriteLine(rectToColor.XPlusWidth);
            Console.WriteLine(rectToColor.Y);
            Console.WriteLine(rectToColor.YPlusHeight);

            Color newColor = Color.FromArgb(0, 0, 0, 0);
            Color actualColor;
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = (int)rectToColor.X; i < (int)rectToColor.XPlusWidth; i++)
            {
                for (int j = (int)rectToColor.Y; j < (int)rectToColor.YPlusHeight; j++)
                {
                    actualColor = ((Bitmap)scrBitmap).GetPixel(i, j);
                    newBitmap.SetPixel(i, j, newColor);
                }
            }
            return newBitmap;
        }
    }
}
