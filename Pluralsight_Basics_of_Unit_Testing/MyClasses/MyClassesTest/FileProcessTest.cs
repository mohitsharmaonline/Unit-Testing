using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;
/******************************************************************
* Unit test is nothing more than a class with methods
* ***************************************************************/

namespace MyClassesTest
{
    // They add these special attributes called TestClass and TestMethods.
    // These special attributes came from namespace 'using Microsoft.VisualStudio.TestTools.UnitTesting;'
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.bad";
        private string _GoodFileName;

        // It could be a little confusing, but the name of the
        // property here really needs to be TestContext only.
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();
            File.AppendAllText(_GoodFileName, "Some Text");
            fromCall = fp.FileExists(_GoodFileName);
            File.Delete(_GoodFileName);
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        // We want to pass an empty file name and get an exception back.
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");

            // Refer rtf doc Your_first_unit_test_arrange_act_assert_1
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch(ArgumentNullException)
            {
                // The test was a success
                return;
            }

            Assert.Fail("Call to FileExists did not throw an ArgumentNullException");
        }

        /*************************************************************************
         * This is a regular methods as compared to test method. You can have 
         * them too. They act as support methods only for main TestMethods 
         * that are used by testing framework.
         * **********************************************************************/
        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if(_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
