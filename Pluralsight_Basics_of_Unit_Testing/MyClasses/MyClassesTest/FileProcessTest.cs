using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            // Assert.Inclusive() is like a todo saying hey we need to write testcase here.
            Assert.Inconclusive();
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            // Assert.Inclusive() is like a todo saying hey we need to write testcase here.
            Assert.Inconclusive();
        }

        // We want to pass an empty file name and get an exception back.
        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            // Assert.Inclusive() is like a todo saying hey we need to write testcase here.
            Assert.Inconclusive();
        }
    }
}
