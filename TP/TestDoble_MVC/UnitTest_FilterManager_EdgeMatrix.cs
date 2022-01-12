using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using NSubstitute;
using BLL;
using BLL.FilterRGB;
using BLL.EdgeMatrix;
using DAL;
using DTO;
using System.Collections.Generic;

namespace TestDoble_MVC
{
    [TestClass]
    public class UnitTest_FilterManager_EdgeMatrix
    {

        static readonly int NUMBER_PIXEL_TEST = 1000;
        static readonly Bitmap originalImage = new Bitmap(Resources.leaf);
        static readonly Bitmap refSobelImage = new Bitmap(Resources.sobel3x3_leaf);
        static readonly Bitmap refPrewittImage = new Bitmap(Resources.prewitt3x3_leaf);
        static readonly Bitmap refLaplacianImage = new Bitmap(Resources.laplacian3x3_leaf);
        static readonly Bitmap NullImage = null;
        private TestsTools Tools = new TestsTools();

        [TestMethod]
        public void TestClassTestVariable()
        {
            Assert.IsNotNull(originalImage);
            Assert.IsNotNull(refSobelImage);
            Assert.IsNotNull(refPrewittImage);
            Assert.IsNotNull(refLaplacianImage);
            Assert.IsNull(NullImage);
        }

        [TestMethod]
        public void TestDefaultImageProperties()
        {
            Console.WriteLine("TestImageProperties");
            Assert.IsNotNull(originalImage);
            Assert.AreEqual(originalImage.Width, 241);
            Assert.AreEqual(originalImage.Height, 350);
            Assert.AreEqual(originalImage.GetPixel(50, 50), Color.FromArgb(255, 255, 255, 255));
            Assert.AreEqual(originalImage.GetPixel(150, 150), Color.FromArgb(255, 15, 148, 7));
        }

        // Tests Sobel filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageOfSobelFilter()
        {
            Console.WriteLine("TestNotNullRefImageAndResultImageOfSobelFilter");

            Bitmap ResultImage = SobelFilter().ApplyEdgeMatrixFilter(originalImage);

            Assert.IsNotNull(ResultImage);
            Assert.IsNotNull(refSobelImage);
        }

        // Tests Sobel filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageOfPrewittFilter()
        {
            Console.WriteLine("TestNotNullRefImageAndResultImageOfPrewittFilter");

            Bitmap ResultImage = PrewittFilter().ApplyEdgeMatrixFilter(originalImage);

            Assert.IsNotNull(ResultImage);
            Assert.IsNotNull(refSobelImage);
        }

        // Tests Sobel filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageOfKirschFilter()
        {
            Console.WriteLine("TestNotNullRefImageAndResultImageOfKirschFilter");

            Bitmap ResultImage = KirschFilter().ApplyEdgeMatrixFilter(originalImage);

            Assert.IsNotNull(ResultImage);
            Assert.IsNotNull(refSobelImage);
        }


        // Tests FilterManager
        [TestMethod]
        public void TestFilterManagerIsNotNull()
        {
            Console.WriteLine("TestFilterManagerIsNotNull");

            Assert.IsNotNull(Tools.FilterManager());
        }

        [TestMethod]
        public void TestFilterManagerEdgeFilterList()
        {
            Console.WriteLine("TestFilterManagerEdgeFilterList");

            List<IFilterEdgeMatrix> filterList = null;

            //Exec FiltersList evaluation
            try
            {
                filterList = new List<IFilterEdgeMatrix>();
                filterList = Tools.FilterManager().getEdgeMatrixFilterList();
            }
            catch
            {
                Assert.Fail("Even though the Filter list evaluation threw an exception");
            }

            //FiltersList isNotNull evaluation
            Assert.IsNotNull(filterList);
        }

        [TestMethod]
        public void TestFilterManagerGetFilterEdgeMatrix()
        {
            Console.WriteLine("TestFilterManagerGetFilterEdgeMatrix");

            int RankInList = 2;
            List<IFilterEdgeMatrix> FilterList = Tools.FilterManager().getEdgeMatrixFilterList();

            if (FilterList == null)
            {
                Assert.IsNotNull(false);
            }

            Assert.AreEqual(Tools.FilterManager().GetFilteEdge(RankInList).Name, FilterList[2].Name);
            Assert.AreEqual(Tools.FilterManager().GetFilteEdge(RankInList).GetType(), FilterList[2].GetType());
        }

        [TestMethod]
        public void TestFilterManagerApplyEgdeFilter()
        {
            Console.WriteLine("TestFilterManagerApplyEgdeFilter");

            string FilterName = "Prewitt Filter";

            Bitmap ResultImage = Tools.FilterManager().ApplyFilter(originalImage, FilterName);

            Tools.TestImageResultWithRandomPixel(ResultImage, refPrewittImage);
        }

        [TestMethod]
        public void TestConvolutionFilter()
        {
            Console.WriteLine("TestConvolutionFilter");

            Bitmap ResultImage = PrewittFilter().ConvolutionFilter(originalImage,
                                                FilterMatrix.Prewitt3x3Horizontal,
                                                              FilterMatrix.Prewitt3x3Vertical,
                                                                   1.0, 0, true);
            Assert.IsNotNull(true);
            Tools.TestImageResultWithRandomPixel(ResultImage, refPrewittImage);
        }

        [TestMethod]
        public void TestFilterManagerApplyRGBFilterWithBitmapNull()
        {
            Console.WriteLine("TestFilterManagerApplyRGBFilterWithBitmapNull");

            Bitmap ResultImage = null;
           string FilterName = "Prewitt Filter";

            try
            {
                ResultImage = new Bitmap("");
                ResultImage = Tools.FilterManager().ApplyFilter(null, FilterName);
            }
            catch
            {
                // Assert.Fail("Catch from FilterManager.FilterRGBApplying is functionnal");
                Assert.IsNull(ResultImage);
            }

            Assert.IsFalse(false);
        }

        // Methods for Tests
        private IFilterEdgeMatrix SobelFilter()
        {
            return new Sobel3x3Filter();
        }

        private IFilterEdgeMatrix PrewittFilter()
        {
            return new PrewittFilter();
        }

        private IFilterEdgeMatrix KirschFilter()
        {
            return new KirschFilter();
        }
    }
}
