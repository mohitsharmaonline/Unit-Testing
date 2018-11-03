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


        #endregion
    }
}
