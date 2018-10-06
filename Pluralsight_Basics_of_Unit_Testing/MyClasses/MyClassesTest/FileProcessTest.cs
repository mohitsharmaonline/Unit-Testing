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

        #region Class Initialization and Ceanup
        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the class Initialize.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // TODO: cleanup of resources.
        }
        #endregion

        #region Test Initialization and cleanup
        // This would not have static keyword, because this method
        // does not run once only, it runs every time the test is run.
        // We don't need to pass test context in this method, as these
        // methods by default have access to Testcontext object.
        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName == nameof(FileNameDoesExists))
            {
                SetGoodFileName();
                if (!string.IsNullOrWhiteSpace(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        public void TestCleanup()
        {
            if (TestContext.TestName == nameof(FileNameDoesExists))
            {
                if (!string.IsNullOrWhiteSpace(_GoodFileName))
                {
                    TestContext.WriteLine($"Delting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion

        // It could be a little confusing, but the name of the
        // property here really needs to be TestContext only.
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("Check to see if file does exist.")]
        [Owner("MohitS")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            
            //TestContext.WriteLine($"Creating the file {_GoodFileName}");
            //File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine($"Testing the file {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            //TestContext.WriteLine($"Deleting the file {_GoodFileName}");
            //File.Delete(_GoodFileName);
            Assert.IsTrue(fromCall);

            // Move to rtf file Demo_using_testcontext
        }

        [TestMethod]
        [Timeout(3000)] // 3 second
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000); // Sleep for 4 second.
        }

        [TestMethod]
        [Description("Check to see if file does not exist.")]
        [Owner("MohitS")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore()]
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
        [Owner("JohnK")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");

            // Refer rtf doc Your_first_unit_test_arrange_act_assert_1
        }

        [TestMethod]
        [Owner("JimR")]
        [Priority(1)]
        [TestCategory("Exception")]
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
