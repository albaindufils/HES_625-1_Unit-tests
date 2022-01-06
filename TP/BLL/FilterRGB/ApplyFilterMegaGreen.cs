using System.Drawing;


namespace BLL.FilterRGB
{
    public class ApplyFilterMegaGreen : AbsApplyFilterManager
    {

        public ApplyFilterMegaGreen()
        {
            Name = "MegaGreen";
        }

        public override Bitmap Filter(Bitmap bmp)
        {
            Color g = Color.Green;
            return ApplyFilterMegaWithBitmap(bmp, 280, 200, g);
        }

    }
}
