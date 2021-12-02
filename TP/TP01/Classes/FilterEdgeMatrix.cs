using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Image
{
    public class FilterEdgeMatrix
    {
        public static double[,] Laplacian3x3
        {
            get
            {
                return new double[,] 
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
            }
        }

        public static double[,] Laplacian5x5
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, 24, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1  }, };
            }
        }

        public static double[,] LaplacianOfGaussian
        {
            get
            {
                return new double[,] 
                { {  0,   0, -1,  0,  0 },
                  {  0,  -1, -2, -1,  0 },
                  { -1,  -2, 16, -2, -1 },
                  {  0,  -1, -2, -1,  0 },
                  {  0,   0, -1,  0,  0 }, };
            }
        }

        public static double[,] Gaussian3x3
        {
            get
            {
                return new double[,] 
                { { 1, 2, 1, },
                  { 2, 4, 2, },
                  { 1, 2, 1, }, };
            }
        }

        public static double[,] Gaussian5x5Type1
        {
            get
            {
                return new double[,] 
                { { 2, 04, 05, 04, 2 },
                  { 4, 09, 12, 09, 4 },
                  { 5, 12, 15, 12, 5 },
                  { 4, 09, 12, 09, 4 },
                  { 2, 04, 05, 04, 2 }, };
            }
        }

        public static double[,] Gaussian5x5Type2
        {
            get
            {
                return new double[,]
                { {  1,   4,  6,  4,  1 },
                  {  4,  16, 24, 16,  4 },
                  {  6,  24, 36, 24,  6 },
                  {  4,  16, 24, 16,  4 },
                  {  1,   4,  6,  4,  1 }, };
            }
        }

        public static double[,] Sobel3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -2,  0,  2, },
                  { -1,  0,  1, }, };
            }
        }

        public static double[,] Sobel3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  2,  1, },
                  {  0,  0,  0, },
                  { -1, -2, -1, }, };
            }
        }

        public static double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -1,  0,  1, },
                  { -1,  0,  1, }, };
            }
        }

        public static double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, }, };
            }
        }


        public static double[,] Kirsch3x3Horizontal
        {
            get
            {
                return new double[,]
                { {  5,  5,  5, },
                  { -3,  0, -3, },
                  { -3, -3, -3, }, };
            }
        }

        public static double[,] Kirsch3x3Vertical
        {
            get
            {
                return new double[,]
                { {  5, -3, -3, },
                  {  5,  0, -3, },
                  {  5, -3, -3, }, };
            }
        }

        public static Bitmap EdgeFilter(Bitmap img, string xfilter, string yfilter, int threeshold)
        {
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            switch (xfilter)
            {
                case "Laplacian3x3":
                    xFilterMatrix = FilterEdgeMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    xFilterMatrix = FilterEdgeMatrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    xFilterMatrix = FilterEdgeMatrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    xFilterMatrix = FilterEdgeMatrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    xFilterMatrix = FilterEdgeMatrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    xFilterMatrix = FilterEdgeMatrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    xFilterMatrix = FilterEdgeMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    xFilterMatrix = FilterEdgeMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    xFilterMatrix = FilterEdgeMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    xFilterMatrix = FilterEdgeMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    xFilterMatrix = FilterEdgeMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    xFilterMatrix = FilterEdgeMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    xFilterMatrix = FilterEdgeMatrix.Laplacian3x3;
                    break;
            }

            switch (yfilter)
            {
                case "Laplacian3x3":
                    yFilterMatrix = FilterEdgeMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    yFilterMatrix = FilterEdgeMatrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    yFilterMatrix = FilterEdgeMatrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    yFilterMatrix = FilterEdgeMatrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    yFilterMatrix = FilterEdgeMatrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    yFilterMatrix = FilterEdgeMatrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    yFilterMatrix = FilterEdgeMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    yFilterMatrix = FilterEdgeMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    yFilterMatrix = FilterEdgeMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    yFilterMatrix = FilterEdgeMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    yFilterMatrix = FilterEdgeMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    yFilterMatrix = FilterEdgeMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    yFilterMatrix = FilterEdgeMatrix.Laplacian3x3;
                    break;
            }

            if (img.Height > 0)
            {
                Bitmap newbitmap = img;
                BitmapData newbitmapData = new BitmapData();
                newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

                byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
                byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                newbitmap.UnlockBits(newbitmapData);

                double blue = 0.0;
                double green = 0.0;
                double red = 0.0;

                double blueX = 0.0;
                double greenX = 0.0;
                double redX = 0.0;

                double blueY = 0.0;
                double greenY = 0.0;
                double redY = 0.0;

                double blueTotal = 0.0;
                double greenTotal = 0.0;
                double redTotal = 0.0;

                int filterOffset = 1;
                int calcOffset = 0;

                int byteOffset = 0;

                for (int offsetY = filterOffset; offsetY <
                    newbitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        newbitmap.Width - filterOffset; offsetX++)
                    {
                        blueX = greenX = redX = 0;
                        blueY = greenY = redY = 0;

                        blueTotal = greenTotal = redTotal = 0.0;

                        byteOffset = offsetY *
                                     newbitmapData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * newbitmapData.Stride);

                                blueX += (double)(pixelbuff[calcOffset]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenX += (double)(pixelbuff[calcOffset + 1]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redX += (double)(pixelbuff[calcOffset + 2]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                blueY += (double)(pixelbuff[calcOffset]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenY += (double)(pixelbuff[calcOffset + 1]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redY += (double)(pixelbuff[calcOffset + 2]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];
                            }
                        }

                        //blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                        blueTotal = 0;
                        greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                        //redTotal = Math.Sqrt((redX * redX) + (redY * redY));
                        redTotal = 0;

                        if (blueTotal > 255)
                        { blueTotal = 255; }
                        else if (blueTotal < 0)
                        { blueTotal = 0; }

                        if (greenTotal > 255)
                        { greenTotal = 255; }
                        else if (greenTotal < 0)
                        { greenTotal = 0; }

                        try
                        {
                            if (greenTotal < threeshold)
                            {
                                greenTotal = 0;
                            }
                            else
                            {
                                greenTotal = 255;
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }


                        if (redTotal > 255)
                        { redTotal = 255; }
                        else if (redTotal < 0)
                        { redTotal = 0; }

                        resultbuff[byteOffset] = (byte)(blueTotal);
                        resultbuff[byteOffset + 1] = (byte)(greenTotal);
                        resultbuff[byteOffset + 2] = (byte)(redTotal);
                        resultbuff[byteOffset + 3] = 255;
                    }
                }

                Bitmap resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);

                BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                         resultbitmap.Width, resultbitmap.Height),
                                                          ImageLockMode.WriteOnly,
                                                      PixelFormat.Format32bppArgb);

                Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
                resultbitmap.UnlockBits(resultData);
                // return resultbitmap
                // pictureBoxResult.Image = resultbitmap;
                // resultBitmap = resultbitmap;
                return resultbitmap;
            }

            return null;
        }
    }

}
