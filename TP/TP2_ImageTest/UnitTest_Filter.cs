using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Image.Classes;

namespace TP2_ImageTest
{
    [TestClass]
    public class UnitTest_Filter
    {
        Bitmap originalImage;
        public UnitTest_Filter()
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
        public void TestDefaultImageWithBlackAndWhiteFilter()
        {
            Console.WriteLine("TestDefaultImageWithBlackAndWhiteFilter");
            Bitmap defaultBlackWhiteImage = new Bitmap(Properties.Resources.black_white_leaf);

            Bitmap blackWhiteImage = FilterMatrix.BlackWhite(originalImage);

            Assert.IsNotNull(blackWhiteImage);
            Assert.IsNotNull(defaultBlackWhiteImage);

            Assert.AreEqual(defaultBlackWhiteImage.Size, blackWhiteImage.Size);
            Assert.AreEqual(defaultBlackWhiteImage.GetType(), blackWhiteImage.GetType());

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                // Random pixel X and Y
                var randX = rnd.Next(1, blackWhiteImage.Width - 1);
                var randY = rnd.Next(1, blackWhiteImage.Height - 1);

                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);

                // Rgb for B&W
                var rgb = FilterMatrix.GetBlackRgbCalculed(originalImage.GetPixel(randX, randY));
                originalImage.SetPixel(randX, randY, Color.FromArgb(rgb, rgb, rgb));

                var pixelBlackWhiteImage = blackWhiteImage.GetPixel(randX, randY);

                // Test image generated with originalImage modified on the fly
                Assert.AreEqual(pixelBlackWhiteImage, originalImage.GetPixel(randX, randY));

                // Test image generated with manually generated B&W
                Assert.AreEqual(pixelBlackWhiteImage, defaultBlackWhiteImage.GetPixel(randX, randY));
            }
        }
        [TestMethod]
        public void TestDefaultImageWithFilterSwap()
        {
            Console.WriteLine("TestDefaultImageWithBlackAndWhiteFilter");
            Bitmap defaultSwapImage = new Bitmap(Properties.Resources.swap_leaf);

            Bitmap swapImage = FilterMatrix.ApplyFilterSwap(originalImage);

            Assert.IsNotNull(swapImage);
            Assert.IsNotNull(defaultSwapImage);

            Assert.AreEqual(defaultSwapImage.Size, swapImage.Size);
            Assert.AreEqual(defaultSwapImage.GetType(), swapImage.GetType());
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var randX = rnd.Next(1, swapImage.Width - 1);
                var randY = rnd.Next(1, swapImage.Height - 1);
                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);
                originalImage.SetPixel(randX, randY, FilterMatrix.GetColorSwaped(originalImage.GetPixel(randX, randY)));

                var pixelSwappedImage = swapImage.GetPixel(randX, randY);

                // Test image generated with originalImage modified on the fly
                Assert.AreEqual(pixelSwappedImage, originalImage.GetPixel(randX, randY));

                // Test image generated with manually generated B&W
                Assert.AreEqual(pixelSwappedImage, defaultSwapImage.GetPixel(randX, randY));
            }
        }
    }
}
