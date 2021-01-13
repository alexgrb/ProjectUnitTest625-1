using DTO_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class FilterManager 
    {

        public Bitmap filterChoice(IFilterManager filtername, Bitmap sourceBitmap)
        {
            Bitmap errorBitmap = null;

            try
            {
                string filterValue = filtername.GetFilterName();
                Bitmap bitmapResult = sourceBitmap;

                //Check the name and call the good method for the good filter
                switch (filterValue)
                {
                    case "BlackNWhite":
                        bitmapResult = BlackAndWhiteFilter(sourceBitmap);
                        break;
                    case "Swap":
                        bitmapResult = SwapFilter(sourceBitmap);
                        break;
                    case "Mega Pink":
                        bitmapResult = FilterMega(sourceBitmap, 230, 110, Color.Pink);
                       
                        break;
                    default:
                        bitmapResult = sourceBitmap;
                        break;
                }
                return bitmapResult;
            }
            catch (Exception e)
            {
           
                return errorBitmap;
            }

        }

        //Method to apply the Swap filter
        public Bitmap SwapFilter(Bitmap sourceBitmap)
        {

            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {
                    Color c = sourceBitmap.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //Method to apply the BlackAndWhite filter
        public Bitmap BlackAndWhiteFilter(Bitmap sourceBitmap)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            int rgb;
            Color c;

            for (int y = 0; y < sourceBitmap.Height; y++)
                for (int x = 0; x < sourceBitmap.Width; x++)
                {
                    c = sourceBitmap.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    temp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return temp;
        }

        private Bitmap FilterMega(Bitmap bmp, int max, int min, Color co)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {

                    Color c = bmp.GetPixel(i, x);
                    if (c.G > min && c.G < max)
                    {
                        Color cLayer = Color.White;
                        temp.SetPixel(i, x, cLayer);
                    }
                    else
                    {
                        temp.SetPixel(i, x, co);
                    }

                }

            }
            return temp;
        }
    }


}
