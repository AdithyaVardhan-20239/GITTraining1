using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class Person
    {
        public string name;
        DateTime DOB;

        public Person()
        {
            name = "undifined";
            DOB = DateTime.Today;
        }

        public Person(string nam, DateTime dob)
        {
            this.name = nam;
            this.DOB = dob;
        }

        public string BirthDay()
        {
            return $"{this.name} birthday is {this.DOB:MMM}-{this.DOB.Day}";
        }
    }

    class TestPerson
    {
        public static void Main()
        {
            Person p = new Person();
            Console.WriteLine(p.name);

            Person p1 = new Person("Chiya",new DateTime(2000,5,25));
            Console.WriteLine(p1.name);
            Console.WriteLine(p1.BirthDay());
        }
    }

}
