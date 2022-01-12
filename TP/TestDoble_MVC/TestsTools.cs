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
    class TestsTools
    {
        static readonly int NUMBER_PIXEL_TEST = 1000;


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
                var randX = rnd.Next(1, ResultImage.Width - 5);
                var randY = rnd.Next(1, ResultImage.Height - 5);
                Console.WriteLine("Test for pixel x: " + randX + ", y: " + randY);
                // Test image generated with manually generated B&W
                Assert.AreEqual(ResultImage.GetPixel(randX, randY), RefImage.GetPixel(randX, randY));
            }
        }


    }
}
