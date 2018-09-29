using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Assembly initializa and cleanup methods
    /// </summary>
    [TestClass]
    public class MyClassesTestInitialization
    {
        // When unit testing framework calls this method, it passes an
        // instance of test context class.
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In the Assembly Initialize method.");
            // TODO: Create resources needed for your tests.
        }

        // this one does not requires a TestContext        
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // TODO: clean up any resources used by your tests.
        }
    }
}
