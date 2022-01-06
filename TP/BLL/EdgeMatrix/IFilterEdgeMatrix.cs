using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BLL.EdgeMatrix
{
    public interface IFilterEdgeMatrix
    {
        public string Name { set; get; }

        public Bitmap ConvolutionFilter(Bitmap sourceBitmap,
                                                double[,] xFilterMatrix,
                                                double[,] yFilterMatrix,
                                                      double factor,
                                                           int bias,
                                                            bool grayscale);

        public Bitmap ApplyEdgeMatrixFilter(Bitmap sourceBitmap);

    }
}
