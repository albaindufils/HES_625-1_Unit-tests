using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Image.Classes
{
    public static class FilterMatrix
    {

        public static Bitmap ApplyFilter(Bitmap bmp, int alpha, int red, int blue, int green)
        {
            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.G / green, c.B / blue);
                    temp.SetPixel(i, x, cLayer);
                }
            return temp;
        }

        

        //black and white filter
        public static Bitmap BlackWhite(this Bitmap temp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < temp.Height; y++)
                for (int x = 0; x < temp.Width; x++)
                {
                    c = temp.GetPixel(x, y);
                    rgb = GetBlackRgbCalculed(c);
                    temp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return temp;

        }
        public static int GetBlackRgbCalculed(Color c)
        {
            return (int)((c.R + c.G + c.B) / 3);
        }

        //apply color filter to swap pixel colors
        public static Bitmap ApplyFilterSwap(this Bitmap bmp)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = GetColorSwaped(c);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        public static Color GetColorSwaped(Color c)
        {
            return Color.FromArgb(c.A, c.G, c.B, c.R);
        }

        //apply color filter to swap pixel colors
        private static Bitmap ApplyFilterMega(this Bitmap bmp, int max, int min, Color co)
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
        public static Bitmap ApplyFilterMegaGreen(this Bitmap sourceBitmap)
        {
            Color c = Color.Green;
            return ApplyFilterMega(new Bitmap(sourceBitmap), 230, 110, c);
        }

        public static Bitmap ApplyFilterMegaBlue(this Bitmap sourceBitmap)
        {
            Color c = Color.Blue;
            return ApplyFilterMega(new Bitmap(sourceBitmap), 230, 110, c);
        }

    }
}
