using System.Drawing;

namespace BLL.FilterRGB
{
    public class ApplyMyFilter : AbsApplyFilterManager
    {

        public ApplyMyFilter()
        {
            Name = "My";
        }

        public override Bitmap Filter(Bitmap bmp)
        {
            return ApplyFilterWithBitmap(bmp, 1, 2, 3, 1);
        }

    }
}
