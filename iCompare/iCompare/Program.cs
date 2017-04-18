using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCompare
{
    class PeopleComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Age > p2.Age)
                return 1;
            else if (p1.Age < p2.Age)
                return -1;
            else
                return 0;
        }
    }

    class Person:IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Person p)
        {
            return this.Name.CompareTo(p.Name);
        }


        static void Main(string[] args)
        {

            Person p1 = new Person { Name = "Bill", Age = 34 };
            Person p2 = new Person { Name = "Tom", Age = 23 };
            Person p3 = new Person { Name = "Alice", Age = 21 };

            Person[] people = new Person[] { p1, p2, p3 };
            Array.Sort(people, new PeopleComparer());

            foreach (Person p in people)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.Age);
            }

            Console.ReadLine();

        }

       
    }
}
