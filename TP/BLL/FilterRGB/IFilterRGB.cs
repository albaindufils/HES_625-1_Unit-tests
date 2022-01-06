using System;
using System.Drawing;

namespace BLL.FilterRGB
{
    public interface IFilterRGB
    {
        public String Name { set; get; }

        public Bitmap Filter(Bitmap bmp);

    }
}
