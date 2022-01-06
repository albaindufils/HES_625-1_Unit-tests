using System.Drawing;

namespace BLL.FilterRGB
{
    public class ApplyBlackAndWhiteFIlter : AbsApplyFilterManager
    {
        public ApplyBlackAndWhiteFIlter()
        {
            Name = "Black&White";
        }

        public Bitmap BlackWhite(Bitmap temp)
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

        public int GetBlackRgbCalculed(Color c)
        {
            return (int)((c.R + c.G + c.B) / 3);
        }

        public override Bitmap Filter(Bitmap bmp)
        {
            return BlackWhite(bmp);
        }
    }
}
