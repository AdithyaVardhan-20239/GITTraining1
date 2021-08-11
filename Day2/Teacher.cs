using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class Teacher : Person
    {
        string[] batches;
        string[] skills;

        public Teacher()
        {
            name = "noname";
            batches = new string[5];
            skills = new string[15];
        }

        public Teacher(string nam, DateTime d, string[] bat, string[] skill) : base(nam, d)
        {
            this.batches = bat;
            this.skills = skill;
        }
    }

    class TestTeacher
    {
        public static void Main()
        {
            Teacher t1 = new Teacher("Lakshmi", DateTime.Today,
                new string[] { "MS", "Java", "Python" },
                new string[] { "C#", "Java" });
            Console.WriteLine(t1.name);
            Console.WriteLine(t1.BirthDay());
        }
    }

}
