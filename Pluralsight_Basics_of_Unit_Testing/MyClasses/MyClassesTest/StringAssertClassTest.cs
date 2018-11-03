

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "John Kuhn";
            string str2 = "Kuhn";

            StringAssert.Contains(value: str1, substring: str2);
        }
    }
}
