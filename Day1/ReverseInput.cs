using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class ReverseInput
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter the number {0}:");
			int x = int.Parse(Console.ReadLine());
			Console.WriteLine($"Number before reversing {x}");
			int temp = 0;
			while (x > 0)
			{
				temp = temp * 10;
				temp = temp + (x % 10);
				x = x / 10;
			}
			Console.WriteLine($"Number after reversing is {temp} ");
		}
	}
}
