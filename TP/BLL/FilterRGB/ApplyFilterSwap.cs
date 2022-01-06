using System.Drawing;

namespace BLL.FilterRGB
{
    public class ApplyFilterSwap : AbsApplyFilterManager 
    {

        public ApplyFilterSwap()
        {
            Name = "Swap";
        }

        public override Bitmap Filter(Bitmap bmp)
        {
            return ApplySwapFilterWithBitmap(bmp, 1, 1, 1, 1);
        }

    }
}
