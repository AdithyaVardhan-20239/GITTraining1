using System;

namespace ConsoleAppCS1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("We are @" + System.DateTime.Now);

            int empid ;
            string ename;
            Console.WriteLine($"Enter emp id :");
            empid = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter ur name :");
            ename = Console.ReadLine();

            Console.WriteLine($"Your emp id is {empid} and ur name is {ename}");

        }
    }
}
