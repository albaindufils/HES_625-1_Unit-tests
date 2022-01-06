using System.Drawing;

namespace BLL.EdgeMatrix
{
    class PrewittFilter : FilterEdgeMatrix
    {
        public PrewittFilter()
        {
            Name = "Prewitt Filter";
        }

        public override Bitmap ApplyEdgeMatrixFilter(Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                                            FilterMatrix.Sobel3x3Horizontal,
                                                              FilterMatrix.Sobel3x3Vertical,
                                                                   1.0, 0, true);
            return resultBitmap;
        }
    }
}
