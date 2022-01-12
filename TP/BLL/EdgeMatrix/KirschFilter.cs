using System.Drawing;

namespace BLL.EdgeMatrix
{
    public class KirschFilter : FilterEdgeMatrix
    {
        public KirschFilter()
        {
            Name = "Kirsch Filter";
        }

        public override Bitmap ApplyEdgeMatrixFilter(Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                                            FilterMatrix.Kirsch3x3Horizontal,
                                                              FilterMatrix.Kirsch3x3Vertical,
                                                                   1.0, 0, true);
            return resultBitmap;
        }
    }
}
