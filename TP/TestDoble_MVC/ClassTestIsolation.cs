using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using BLL.FilterRGB;

namespace TestDoble_MVC
{
    [TestClass]
    public class ClassTestIsolation
    {
        private TestsTools Tools = new TestsTools();
        static readonly Bitmap originalImage = new Bitmap(Resources.leaf);
        static readonly Bitmap refSwapImage = new Bitmap(Resources.swap_leaf);
        static readonly Bitmap refBlackWhiteImage = new Bitmap(Resources.black_white_leaf);
        static readonly Bitmap refMegaGreenImage = new Bitmap(Resources.megaGreen_leaf);
        static readonly Bitmap refMyImage = new Bitmap(Resources.my_leaf);
        static readonly Bitmap NullImage = null;

        [TestMethod]
        public void TestResultOFFilterSwap()
        {
            Console.WriteLine("TestResultOFFilterSwap");

            // Apply filter Swap
            Bitmap ResultImage = SwapFilter().Filter(originalImage);

            Tools.TestImageResultWithRandomPixel(ResultImage, refSwapImage);
        }

        [TestMethod]
        public void TestResultOFFilterMegGreen()
        {
            Console.WriteLine("TestResultOFFilterMegGreen");

            // Apply filter Swap
            Bitmap ResultImage = MegaGreenFilter().Filter(originalImage);

            Tools.TestImageResultWithRandomPixel(ResultImage, refMegaGreenImage);
        }


        [TestMethod]
        public void TestResultOFFilterMy()
        {
            Console.WriteLine("TestResultOFFilterMy");

            // Apply filter My
            Bitmap ResultImage = MyFilter().Filter(originalImage);


            Tools.TestImageResultWithRandomPixel(ResultImage, refMyImage);
        }


        // Methods for Tests
        private IFilterRGB SwapFilter()
        {
            return new ApplyFilterSwap();
        }
        private IFilterRGB BlackWhiteFilter()
        {
            return new ApplyBlackAndWhiteFIlter();
        }

        private ApplyBlackAndWhiteFIlter DirectClassBlackWhiteFilter()
        {
            return new ApplyBlackAndWhiteFIlter();
        }

        private IFilterRGB MegaGreenFilter()
        {
            return new ApplyFilterMegaGreen();
        }
        private IFilterRGB MyFilter()
        {
            return new ApplyMyFilter();
        }



    }
}
