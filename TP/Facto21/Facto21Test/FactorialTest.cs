using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facto21;
namespace Facto21Test
{
    [TestClass]
    public class FactorialTest
    {
        [TestMethod]
        public void TestFactorielNormal()
        {
            Factorial Fa = new Factorial();

            Fa.Compute(12);
            int MyResult = 479001600;
            Assert.AreEqual(Fa.TheResult, MyResult);
        }
        [TestMethod()]
        public void TestFactorielBelow0()
        {
            Factorial Fa = new Factorial();
            //below 0
            Fa.Compute(-5);
            int MyResult = -1;
            Assert.AreEqual(Fa.TheResult, MyResult);
        }
        [TestMethod()]
        public void TestFactorielEqual0()
        {
            Factorial Fa = new Factorial();
            
            Fa.Compute(0);
            int MyResult = 0;
            Assert.AreEqual(Fa.TheResult, MyResult);
        }
        [TestMethod()]
        public void TestFactorielOverflow()
        {
            Factorial Fa = new Factorial();
            
            Fa.Compute(100);
            int MyResult = -2;
            Assert.AreEqual(Fa.TheResult, MyResult);
        }
    }
}
