using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("MohitS")]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("JohnK")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualsCaseSensitiveTest()
        {
            string str1 = "Paul";
            string str2 = "paul";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("JohnK")]
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "John";

            Assert.AreNotEqual(str1, str2);
        }
        
        #endregion

        /***************************************************************
         * AreSame, AreNotSame: used to check if object variables 
         * points to same object.
         * 
         * IsInstanceofType, IsNotInstanceOfType: to check if object
         * variable is of specific type.
         * 
         * IsNull, IsNotNull: to check for null or not null.
         * ***************************************************************/

        [TestMethod]
        [Owner("JohnK")]
        public void AreSameTest()
        {
            FileProcessTest x = new FileProcessTest();
            FileProcessTest y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("JohnK")]
        public void AreNotSameTest()
        {
            FileProcessTest x = new FileProcessTest();
            FileProcessTest y = new FileProcessTest();

            Assert.AreNotSame(x, y);
        }


    }
}
