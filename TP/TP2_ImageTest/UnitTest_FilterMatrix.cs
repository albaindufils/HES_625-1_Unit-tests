using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;


namespace TP2_ImageTest
{
    [TestClass]
    public class UnitTest_FilterMatrix
    {

        [TestMethod]
        public void TestImageProperties()
        {
            Console.WriteLine("TestMethod1:");
            Bitmap b = new Bitmap(Properties.Resources.leaf);
            Console.WriteLine(b.Height);
            Assert.IsNotNull(b);
            Assert.AreEqual(b.Width, 241);
            Assert.AreEqual(b.Width, 350);
        }
    }
}
