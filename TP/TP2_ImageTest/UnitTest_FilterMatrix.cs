using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections;
using Image.Classes;





namespace TP2_ImageTest
{
    [TestClass]
    public class UnitTest_FilterMatrix
    {
       // private const string FILE_Origin = "TP2_ImageTest.Properties.Resources.sassafras-leaf.jpg";
        // private const string FILE_BlackWhite = "..\\Ressources\\sassafras-leaf.jpg";
        //private const string FILE_URI = "..\\Ressources\\sassafras-leaf.jpg";

        private Bitmap originalBitmap = new Bitmap(TP2_ImageTest.Properties.Resources.sassafras.jpg);

        [TestMethod]
        public void SourceImageNotNull()
        {
            //         PopulateFiltersList();

            //         foreach (Bitmap filter in FiltersList )
            //         {
            ////             Bitmap bitmap = (Bitmap) filter;
            //             Assert.IsNotNull(filter);

            //         }

            Assert.IsNotNull(originalBitmap);
            //Assert.IsNotNull(FilterMatrix.ApplyFilterMegaGreen(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyFilterSwap(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyFilterSwapDivide(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyMiaFilter(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyOneFilter(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyRainbowFilter(originalBitmap));
        }

        [TestMethod]
        public void FilterNotNull()
        {
            //         PopulateFiltersList();

            //         foreach (Bitmap filter in FiltersList )
            //         {
            ////             Bitmap bitmap = (Bitmap) filter;
            //             Assert.IsNotNull(filter);

            //         }

            Bitmap bitmap = FilterMatrix.ApplyFilterMegaBlue(originalBitmap);
            Assert.IsNotNull(bitmap);
            //Assert.IsNotNull(FilterMatrix.ApplyFilterMegaGreen(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyFilterSwap(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyFilterSwapDivide(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyMiaFilter(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyOneFilter(originalBitmap));
            //Assert.IsNotNull(FilterMatrix.ApplyRainbowFilter(originalBitmap));
        }







    }
}
