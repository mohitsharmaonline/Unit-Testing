
using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;
            if(!string.IsNullOrWhiteSpace(first))
            {
                if(isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
            people.Add(new Person() { FirstName = "John", LastName = "Kuhn" });
            people.Add(new Person() { FirstName = "Jim", LastName = "Ruhl" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Paul", "Sheriff", true));
            people.Add(CreatePerson("Michael", "Krasowski", true));

            return people;
        }

        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Steve", "Nystrom", false));
            people.Add(CreatePerson("John", "Kuhn", false));
            people.Add(CreatePerson("Jim", "Ruhl", false));

            return people;
        }

        public List<Person> GetSupervisorsAndEmployees()
        {
            List<Person> people = new List<Person>();

            people.AddRange(GetEmployees());
            people.AddRange(GetSupervisors());

            return people;
        }
    }
}
