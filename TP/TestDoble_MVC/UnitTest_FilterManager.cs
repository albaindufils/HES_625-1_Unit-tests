﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class UnitTest_FilterManager
    {

        static readonly int NUMBER_PIXEL_TEST = 1000;
        static readonly Bitmap originalImage = new Bitmap(Resources.leaf);
        static readonly Bitmap refSwapImage = new Bitmap(Resources.swap_leaf);
        static readonly Bitmap refBlackWhiteImage = new Bitmap(Resources.black_white_leaf);
        static readonly Bitmap refMegaGreenImage = new Bitmap(Resources.megaGreen_leaf);
        static readonly Bitmap refMyImage = new Bitmap(Resources.my_leaf);
        static readonly Bitmap refSobelImage = new Bitmap(Resources.sobel3x3_leaf);
        static readonly Bitmap refPrewittImage = new Bitmap(Resources.prewitt3x3_leaf);
        static readonly Bitmap refLaplacianImage = new Bitmap(Resources.laplacian3x3_leaf);
        static readonly Bitmap NullImage = null;


        //[TestCleanup]
        //public void FilterTestCleanup()
        //{
        //    originalImage = null;
        //}

        //[TestInitialize]
        //public void FilterTestInitilize()
        //{
        //    originalImage = new Bitmap(Resources.leaf);
        //}

        [TestMethod]
        public void TestClassTestVariable()
        {
            Assert.IsNotNull(originalImage);
            Assert.IsNotNull(refSwapImage);
            Assert.IsNotNull(refBlackWhiteImage);
            Assert.IsNotNull(refMegaGreenImage);
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

        // Tests Balck & White filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageOfBlackAndWhiteFilter()
        {
            Console.WriteLine("TestNotNullRefImageAndResultImageOfBlackAndWhiteFilter");

            Bitmap blackWhiteImage = BlackWhiteFilter().Filter(originalImage);

            Assert.IsNotNull(blackWhiteImage);
            Assert.IsNotNull(refBlackWhiteImage);
        }

        [TestMethod]
        public void TestRefImageWithResultImageOfBlackAndWhiteFilter()
        {
            Console.WriteLine("TestRefImageWithResultImageOfBlackAndWhiteFilter");

            Bitmap blackWhiteImage = BlackWhiteFilter().Filter(originalImage);

            Assert.AreEqual(refBlackWhiteImage.Size, blackWhiteImage.Size);
            Assert.AreEqual(refBlackWhiteImage.GetType(), blackWhiteImage.GetType());

            Random rnd = new Random();

            // Control x pixels randomly
            for (int i = 0; i < NUMBER_PIXEL_TEST; i++)
            {
                // Random pixel X and Y
                var randX = rnd.Next(1, blackWhiteImage.Width - 1);
                var randY = rnd.Next(1, blackWhiteImage.Height - 1);

                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);

                var pixelBlackWhiteImage = blackWhiteImage.GetPixel(randX, randY);

                // Test image generated with manually generated B&W
                Assert.AreEqual(pixelBlackWhiteImage, refBlackWhiteImage.GetPixel(randX, randY));
            }
        }

        [TestMethod]
        public void TestOriginalImageWithResultImageOfBlackAndWhiteFilter()
        {
            Console.WriteLine("TestOriginalImageWithResultImageOfBlackAndWhiteFilter");

            Bitmap blackWhiteImage = BlackWhiteFilter().Filter(originalImage);

            Assert.AreEqual(originalImage.Size, blackWhiteImage.Size);
            Assert.AreEqual(originalImage.GetType(), blackWhiteImage.GetType());

            Random rnd = new Random();

            // Control x pixels randomly
            for (int i = 0; i < NUMBER_PIXEL_TEST; i++)
            {
                // Random pixel X and Y
                var randX = rnd.Next(1, blackWhiteImage.Width - 1);
                var randY = rnd.Next(1, blackWhiteImage.Height - 1);

                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);

                // Rgb for B&W
                var rgb = DirectClassBlackWhiteFilter().GetBlackRgbCalculed(originalImage.GetPixel(randX, randY));
                originalImage.SetPixel(randX, randY, Color.FromArgb(rgb, rgb, rgb));

                var pixelBlackWhiteImage = blackWhiteImage.GetPixel(randX, randY);

                // Test image generated with originalImage modified on the fly
                Assert.AreEqual(pixelBlackWhiteImage, originalImage.GetPixel(randX, randY));
            }
        }

        // Tests Swap filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageWithFilterSwap()
        {
            Console.WriteLine("TestRefImageAndResultImageNotNullWithFilterSwap");

            // Apply filter Swap
            Bitmap ResultImage = SwapFilter().Filter(originalImage);

            Assert.IsNotNull(ResultImage);
            Assert.IsNotNull(refSwapImage);
        }

        [TestMethod]
        public void TestResultOFFilterSwap()
        {
            Console.WriteLine("TestResultOFFilterSwap");

            // Apply filter Swap
            Bitmap ResultImage = SwapFilter().Filter(originalImage);

            TestImageResultWithRandomPixel(ResultImage, refSwapImage);
        }

        //Test My filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageWithFilterMy()
        {
            Console.WriteLine("TestNotNullRefImageAndResultImageWithFilterMy");

            // Apply filter My
            Bitmap ResultImage = MyFilter().Filter(originalImage);

            Assert.IsNotNull(ResultImage);
            Assert.IsNotNull(refMyImage);
        }

        [TestMethod]
        public void TestResultOFFilterMy()
        {
            Console.WriteLine("TestResultOFFilterMy");

            // Apply filter My
            Bitmap ResultImage = MyFilter().Filter(originalImage);

            TestImageResultWithRandomPixel(ResultImage, refMyImage);
        }

        //Test MegaGreen filter
        [TestMethod]
        public void TestNotNullRefImageAndResultImageWithFilterMegaGreen()
        {
            Console.WriteLine("TestNotNullRefImageAndResultImageWithFilterMegaGreen");

            // Apply filter Swap
            Bitmap ResultImage = MegaGreenFilter().Filter(originalImage);

            Assert.IsNotNull(ResultImage);
            Assert.IsNotNull(refMegaGreenImage);
        }

        [TestMethod]
        public void TestResultOFFilterMegGreen()
        {
            Console.WriteLine("TestResultOFFilterMegGreen");

            // Apply filter Swap
            Bitmap ResultImage = MegaGreenFilter().Filter(originalImage);

            TestImageResultWithRandomPixel(ResultImage, refMegaGreenImage);
        }

        // Tests FilterManager
        [TestMethod]
        public void TestFilterManagerIsNotNull()
        {
            Console.WriteLine("TestFilterManagerIsNotNull");

            Assert.IsNotNull(FilterManager());
        }

        [TestMethod]
        public void TestFilterManagerRGBList()
        {
            Console.WriteLine("TestFilterManagerRGBList");

            List<IFilterRGB> filterList = null;

            //Exec FiltersList evaluation
            try
            {
               filterList = new List<IFilterRGB>();
               filterList = FilterManager().getFilterRGBList();
            }
            catch
            {
                Assert.Fail("Even though the Filter list evaluation threw an exception");
            }

            //FiltersList isNotNull evaluation
            Assert.IsNotNull(filterList);
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
                filterList = FilterManager().getEdgeMatrixFilterList();
            }
            catch
            {
                Assert.Fail("Even though the Filter list evaluation threw an exception");
            }

            //FiltersList isNotNull evaluation
            Assert.IsNotNull(filterList);

        }

        [TestMethod]
        public void TestFilterManagerGetFilterRGB()
        {
            Console.WriteLine("TestFilterManagerGetFilterRGB");

            int RankInList = 2;
            List<IFilterRGB> FilterList = FilterManager().getFilterRGBList();

            if (FilterList == null)
            {
                Assert.IsNotNull(false);
            }

            Assert.AreEqual(FilterManager().GetFilterRGB(RankInList).Name, FilterList[2].Name);
            Assert.AreEqual(FilterManager().GetFilterRGB(RankInList).GetType(), FilterList[2].GetType());
        }

        [TestMethod]
        public void TestFilterManagerGetFilterEdgeMatrix()
        {
            Console.WriteLine("TestFilterManagerGetFilterEdgeMatrix");

            int RankInList = 2;
            List<IFilterEdgeMatrix> FilterList = FilterManager().getEdgeMatrixFilterList();

            if(FilterList == null)
            {
                Assert.IsNotNull(false);
            }

            Assert.AreEqual(FilterManager().GetFilteEdge(RankInList).Name, FilterList[2].Name);
            Assert.AreEqual(FilterManager().GetFilteEdge(RankInList).GetType(), FilterList[2].GetType());
        }

        [TestMethod]
        public void TestFilterManagerApplyRGBFilter()
        {
            Console.WriteLine("TestFilterManagerApplyRGBFilter");

            string FilterName = "My";
            
            Bitmap ResultImage = FilterManager().ApplyFilter(originalImage, FilterName);

            TestImageResultWithRandomPixel(ResultImage, refMyImage);
        }

        [TestMethod]
        public void TestFilterManagerApplyEgdeFilter()
        {
            Console.WriteLine("TestFilterManagerApplyEgdeFilter");

            string FilterName = "MegaGreen";

            Bitmap ResultImage = FilterManager().ApplyFilter(originalImage, FilterName);

            TestImageResultWithRandomPixel(ResultImage, refMegaGreenImage);

        }

        // Methods for Tests
        public IFilterRGB SwapFilter()
        {
            return new ApplyFilterSwap();
        }
        public IFilterRGB BlackWhiteFilter()
        {
            return new ApplyBlackAndWhiteFIlter();
        }

        public ApplyBlackAndWhiteFIlter DirectClassBlackWhiteFilter()
        {
            return new ApplyBlackAndWhiteFIlter();
        }

        public IFilterRGB MegaGreenFilter()
        {
            return new ApplyFilterMegaGreen();
        }
        public IFilterRGB MyFilter()
        {
            return new ApplyMyFilter();
        }

        public IFilterManager FilterManager()
        {
            return new FilterManager();
        }

        public void TestImageResultWithRandomPixel(Bitmap ResultImage, Bitmap RefImage)
        {
            Console.WriteLine("TestImageResultWithRandomPixel");

            Random rnd = new Random();

            //control size and Type of image
            Assert.AreEqual(RefImage.Size, ResultImage.Size);
            Assert.AreEqual(RefImage.GetType(), ResultImage.GetType());

            // Control x pixels randomly
            for (int i = 0; i < NUMBER_PIXEL_TEST; i++)
            {
                var randX = rnd.Next(1, ResultImage.Width - 1);
                var randY = rnd.Next(1, ResultImage.Height - 1);
                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);
                // Test image generated with manually generated B&W
                Assert.AreEqual(ResultImage.GetPixel(randX, randY), RefImage.GetPixel(randX, randY));
            }
        }

    }
}
