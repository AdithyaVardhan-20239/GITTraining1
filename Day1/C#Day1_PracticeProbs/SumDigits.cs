using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class SumDigits
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number :");
            int x = int.Parse(Console.ReadLine());
            int sum = 0,temp = 0,a=x;
            while (x > 0)
            {
                temp = x%10;
                x = x / 10;
                sum =sum+ temp;
            }
            Console.WriteLine($"The sum of digits of given number {a} is {sum}");

        }
    }
}
