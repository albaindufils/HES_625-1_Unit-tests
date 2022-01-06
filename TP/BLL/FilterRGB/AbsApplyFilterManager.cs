using System.Drawing;

namespace BLL.FilterRGB
{
    public abstract class AbsApplyFilterManager : IFilterRGB
    {
        public string Name { get; set; }

        public Bitmap ApplyFilterWithBitmap(Bitmap bmp, int alpha, int red, int green, int blue)
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

        public Bitmap ApplySwapFilterWithBitmap(Bitmap bmp, int alpha, int green, int blue, int red)
        {
            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.B / blue, c.G / green);
                    temp.SetPixel(i, x, cLayer);
                }
            return temp;
        }

        public Bitmap ApplyFilterMegaWithBitmap(Bitmap bmp, int max, int min, Color co)
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

        public abstract Bitmap Filter(Bitmap bmp);

    }
}
