using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using BLL;
using DAL;
using DTO;
using WinForms_TestDoble;

namespace TestDoble_MVC
{
    [TestClass]
    public class UnitTest_PictureManager
    {
        public static Picture CreateEmptyPicture()
        {
            Picture img = new Picture();
            return img;
        }

        public static Picture CreateNullPicture()
        {
            Picture img = null;
            return img;
        }

        public static Picture CreatePicture()
        {
            Picture img = new Picture("Good_Image");

            img.Path = "Ressources.leaf";
            img.AppliedFilters.Add("Filter1");
            img.AppliedFilters.Add("Filter2");

            return img;
        }

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

        [TestMethod]
        public void NullPicture()
        {
            var pictureRepository = Substitute.For<IPictureRepository>();
            Picture img = CreateNullPicture();
            PictureManager testPictureManager = new PictureManager(pictureRepository);

            //Returns a null picture
            pictureRepository.GetById("Good_Image").Returns<Picture>(img);

            //Exec FiltersList evaluation
            try
            {
                img = CreateNullPicture();
                testPictureManager.AppliedListFilterIsEmpty("Good_Image");
            }
            catch
            {
                Assert.Fail("Even though the Filter list evaluation threw an exception");
            }

            Assert.AreEqual(null, img);
        }

        [TestMethod]
        public void EmptyPicture()
        {
            var pictureRepository = Substitute.For<IPictureRepository>();
            Picture img = CreateEmptyPicture();

            PictureManager testPictureManager = new PictureManager(pictureRepository);

            //Returns an empty valid picture
            pictureRepository.GetById("Good_Image").Returns<Picture>(img);

            //Exec FiltersList evaluation
            testPictureManager.AppliedListFilterIsEmpty("Good_Image");

            //As the test cannot fail
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void EmptyAppliedFilterList()
        {
            var pictureRepository = Substitute.For<IPictureRepository>();
            Picture img = CreateEmptyPicture();

            PictureManager testPictureManager = new PictureManager(pictureRepository);

            //Returns a empty picture with empty filter List
            pictureRepository.GetById("Good_Image").Returns<Picture>(img);

            //Exec FiltersList evaluation
            testPictureManager.AppliedListFilterIsEmpty("Good_Image");

            Assert.IsTrue(testPictureManager.ListAppliedFilter.Count == 0);
        }

        [TestMethod]
        public void NoEmptyAppliedFilterList()
        {
            var pictureRepository = Substitute.For<IPictureRepository>();
            Picture img = CreatePicture();

            PictureManager testPictureManager = new PictureManager(pictureRepository);

            //Returns a empty picture with empty filter List
            pictureRepository.GetById("Good_Image").Returns<Picture>(img);

            //Exec FiltersList evaluation
            testPictureManager.AppliedListFilterIsEmpty("Good_Image");

            Assert.IsTrue(testPictureManager.ListAppliedFilter.Count > 0);
        }

        [TestMethod]
        public void TestAddFilterInFilterList()
        {
            var pictureRepository = Substitute.For<IPictureRepository>();
            Picture img = CreatePicture();

            PictureManager testPictureManager = new PictureManager(pictureRepository);

            //Returns a empty picture with empty filter List
            pictureRepository.GetById("Good_Image").Returns<Picture>(img);

            //Exec FiltersList evaluation
            testPictureManager.AddInlistAppliedFilter("Good Filter in list");

            Assert.IsTrue(testPictureManager.ListAppliedFilter.Count > 0);
           
        }

    }
}
