using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.EdgeMatrix

{
    public interface IFilterMatrix
    {
        public static double[,] Sobel3x3Horizontal { get; }
        public static double[,] Sobel3x3Vertical { get; }
        public static double[,] Prewitt3x3Horizontal { get; }
        public static double[,] Prewitt3x3Vertical { get; }
        public static double[,] Kirsch3x3Horizontal { get; }
        public static double[,] Kirsch3x3Vertical { get; }

    }
}
