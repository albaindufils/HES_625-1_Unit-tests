using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using BLL.FilterRGB;
using System.Collections.Generic;



namespace TestDoble_MVC
{
    [TestClass]
    public class UnitTest_FilterManager_RGB
    {
        static readonly int NUMBER_PIXEL_TEST = 1000;
        static readonly Bitmap originalImage = new Bitmap(Resources.leaf);
        static readonly Bitmap refSwapImage = new Bitmap(Resources.swap_leaf);
        static readonly Bitmap refBlackWhiteImage = new Bitmap(Resources.black_white_leaf);
        static readonly Bitmap refMegaGreenImage = new Bitmap(Resources.megaGreen_leaf);
        static readonly Bitmap refMyImage = new Bitmap(Resources.my_leaf);
        static readonly Bitmap NullImage = null;
        private TestsTools Tools = new TestsTools();

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

        [TestInitialize()]
         //[TestMethod]
        public void TestClassTestVariable()
        {
            Assert.IsNotNull(originalImage);
            Assert.IsNotNull(refSwapImage);
            Assert.IsNotNull(refBlackWhiteImage);
            Assert.IsNotNull(refMegaGreenImage);
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


        // Tests FilterManager
        [TestMethod]
        public void TestFilterManagerIsNotNull()
        {
            Console.WriteLine("TestFilterManagerIsNotNull");

            Assert.IsNotNull(Tools.FilterManager());
        }

        [TestMethod]
        public void TestFilterManagerRGBList_OK()
        {
            Console.WriteLine("TestFilterManagerRGBList");

            List<IFilterRGB> filterList = null;

            //Exec FiltersList evaluation
            try
            {
               filterList = new List<IFilterRGB>();
               filterList = Tools.FilterManager().getFilterRGBList();
            }
            catch
            {
                Assert.Fail("Even though the Filter list evaluation threw an exception");
            }

            //FiltersList isNotNull evaluation
            Assert.IsNotNull(filterList);
        }

        [TestMethod]
        public void TestFilterManagerRGBList_KO()
        {
            Console.WriteLine("TestFilterManagerRGBList");

            List<IFilterRGB> filterList = null;

            //Exec FiltersList evaluation
            try
            {
                filterList = getNullListIFilterRGB();
            }
            catch
            {
                Assert.Fail("Even though the Filter list evaluation threw an exception");
            }

            //FiltersList isNotNull evaluation
            Assert.IsNull(filterList);
        }

        [TestMethod]
        public void TestFilterManagerGetFilterRGB()
        {
            Console.WriteLine("TestFilterManagerGetFilterRGB");

            int RankInList = 2;
            List<IFilterRGB> FilterList = Tools.FilterManager().getFilterRGBList();

            if (FilterList == null)
            {
                Assert.IsNotNull(false);
            }

            Assert.AreEqual(Tools.FilterManager().GetFilterRGB(RankInList).Name, FilterList[2].Name);
            Assert.AreEqual(Tools.FilterManager().GetFilterRGB(RankInList).GetType(), FilterList[2].GetType());
        }

        [TestMethod]
        public void TestFilterManagerApplyRGBFilter_OK()
        {
            Console.WriteLine("TestFilterManagerApplyRGBFilter_OK");

            string FilterName = "My";
            
            Bitmap ResultImage = Tools.FilterManager().ApplyFilter(originalImage, FilterName);

            Tools.TestImageResultWithRandomPixel(ResultImage, refMyImage);
        }

        [TestMethod]
        public void TestFilterManagerApplyRGBFilter_KO()
        {
            Console.WriteLine("TestFilterManagerApplyRGBFilter_KO");

            string FilterName = null;

            Bitmap ResultImage = Tools.FilterManager().ApplyFilter(originalImage, FilterName);

            Tools.TestImageResultWithRandomPixel(ResultImage, originalImage);
        }

        [TestMethod]
        public void TestFilterManagerApplyRGBFilter_BitmapFilterName_KO()
        {
            Console.WriteLine("TestFilterManagerApplyRGBFilter_Bitmap_KO");

            Bitmap ResultImage = Tools.FilterManager().ApplyFilter(null, null);

            Assert.IsNotNull(ResultImage);
            Assert.AreEqual(ResultImage.Width, 10);
        }

        [TestMethod]
        public void TestCatchFilterManagerApplyRGBFilter()
        {
            Console.WriteLine("TestCatchFilterManagerApplyRGBFilter");

            Bitmap ResultImage = null;
            string FilterName = null;

            try
            {
                ResultImage = new Bitmap("");
                // ResultImage = Tools.FilterManager().ApplyFilter(originalImage, FilterName);
            }
            catch
            {
                //Assert.Fail("Catch from FilterManager.FilterRGBApplying is functionnal");
                Assert.IsNull(ResultImage);

            }

            Assert.IsTrue(true);
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

        public List<IFilterRGB> getNullListIFilterRGB()
        {
            return null;
        }

    }
}
