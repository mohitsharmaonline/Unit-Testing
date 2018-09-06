using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
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
        [TestMethod]
        public void FileNameDoesExists()
        {
            // Arrange
            FileProcess fp = new FileProcess();

            // Acting
            bool fromCall = fp.FileExists(@"C:\Windows\regedit.exe");

            // Assert
            Assert.IsTrue(fromCall);

            // Refer rtf doc Your_first_unit_test_arrange_act_assert

            
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            // Arrange
            FileProcess fp = new FileProcess();

            // Acting
            bool fromCall = fp.FileExists(@"C:\BadFileName.bad");

            // Assert
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
    }
}
