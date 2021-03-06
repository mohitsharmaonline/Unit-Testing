﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

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

        [TestMethod]
        public void GetEmployeesTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> employees;

            employees = mgr.GetEmployees();

            CollectionAssert.AllItemsAreInstancesOfType(collection: employees,
                expectedType: typeof(Employee));
        }

        [TestMethod]
        public void IsCollectionOfTypeSupervisorsAndEmployeeTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisorsAndEmployees();

            CollectionAssert.AllItemsAreNotNull(peopleActual);
        }

        [TestMethod]
        [Owner("JohnK")]
        public void DoEmployeesExistsTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();

            super.Employees.Add(new Employee()
            {
                FirstName = "Jim",
                LastName = "Ruhl"
            });

            Assert.IsTrue(super.Employees.Count > 0);
        }
    }
}
