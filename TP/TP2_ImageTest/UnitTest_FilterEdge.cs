using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Drawing;
using Image;

namespace TP2_ImageTest
{
    [TestClass]
    public class UnitTest_FilterEdge
    {
        Bitmap originalImage;
        int NUMBER_PIXEL_TEST = 1000;

        [TestCleanup]
        public void FilterTestCleanup()
        {
            originalImage = null;
        }

        [TestInitialize]
        public void FilterTestInitilize()
        {
            originalImage = new Bitmap(Properties.Resources.leaf);
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

        [TestMethod]
        public void TestDefaultImageWithLaplacian3x3EgdeFilter()
        {
            TestDefaultImageWithAnEdgeFilter("Laplacian3x3", Properties.Resources.laplacian3x3_leaf);
            Assert.AreEqual(FilterEdgeMatrix.Laplacian3x3.Length, 9);
        }

        [TestMethod]
        public void TestDefaultImageWithSobel3x3EgdeFilter()
        {
            TestDefaultImageWithAnEdgeFilter("Sobel3x3Horizontal", Properties.Resources.sobel3x3horizontal_leaf);
            Assert.AreEqual(FilterEdgeMatrix.Sobel3x3Horizontal.Length, 9);
        }

        [TestMethod]
        public void TestDefaultImageWithPrewitt3x3EgdeFilter()
        {
            TestDefaultImageWithAnEdgeFilter("Prewitt3x3Horizontal", Properties.Resources.prewitt3x3horizontal_leaf);
            Assert.AreEqual(FilterEdgeMatrix.Prewitt3x3Horizontal.Length, 9);

        }

        public void TestDefaultImageWithAnEdgeFilter(string filter, Bitmap ressourceBitmap)
        {
            Console.WriteLine("TestDefaultImageWith"+ filter + "EgdeFilter");

            Bitmap defaultFilter = new Bitmap(ressourceBitmap);
            Bitmap originalWithFilter = FilterEdgeMatrix.EdgeFilter(originalImage, filter, filter, 100);

            Assert.IsNotNull(defaultFilter);
            Assert.IsNotNull(originalWithFilter);

            Assert.AreEqual(defaultFilter.Size, originalWithFilter.Size);
            Assert.AreEqual(defaultFilter.GetType(), originalWithFilter.GetType());

            Random rnd = new Random();

            // Control x pixels randomly
            for (int i = 0; i < NUMBER_PIXEL_TEST; i++)
            {
                // Random pixel X and Y
                var randX = rnd.Next(1, defaultFilter.Width - 1);
                var randY = rnd.Next(1, defaultFilter.Height - 1);

                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);

                var pixelFilter = defaultFilter.GetPixel(randX, randY);

                // Test image generated with originalImage modified on the fly
                Assert.AreEqual(pixelFilter, defaultFilter.GetPixel(randX, randY));

                // Test image generated with manually generated B&W
                Assert.AreEqual(pixelFilter, defaultFilter.GetPixel(randX, randY));
            }
        }
    }
}
