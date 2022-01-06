using System.Drawing;

namespace BLL.EdgeMatrix
{
    class Sobel3x3Filter : FilterEdgeMatrix
    {
        public Sobel3x3Filter()
        {
            Name = "Sobel Filter";
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
