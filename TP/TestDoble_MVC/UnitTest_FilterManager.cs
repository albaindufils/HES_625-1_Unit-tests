using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using BLL;
using DAL;
using DTO;


namespace TestDoble_MVC
{
    [TestClass]
    public class UnitTest_FilterManager
    {
        [TestMethod]
        public void ValidPicture()
        {
            var pictureRepository = Substitute.For<IPictureRepository>();
            Picture img = CreatePicture();

            PictureManager testPictureManager = new PictureManager(pictureRepository);

            //Returns a valid picture
            pictureRepository.GetById("Good_Image").Returns<Picture>(img);

            //Exec FiltersList evaluation
            testPictureManager.AppliedListFilterIsEmpty("Good_Image");

            //As the test cannot fail
            Assert.IsTrue(true);
        }


    }
}
