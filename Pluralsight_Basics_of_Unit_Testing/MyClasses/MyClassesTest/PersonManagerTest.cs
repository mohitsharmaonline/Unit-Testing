using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson(first: "Paul", last: "Sheriff", 
                isSupervisor: false);

            Assert.IsInstanceOfType(value: per, expectedType: typeof(Employee));

        }
    }
}
