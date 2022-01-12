using System.Drawing;

namespace BLL.EdgeMatrix
{
    public class PrewittFilter : FilterEdgeMatrix
    {
        public PrewittFilter()
        {
            Name = "Prewitt Filter";
        }

        public override Bitmap ApplyEdgeMatrixFilter(Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                                            FilterMatrix.Prewitt3x3Horizontal,
                                                              FilterMatrix.Prewitt3x3Vertical,
                                                                   1.0, 0, true);
            return resultBitmap;
        }
    }
}
