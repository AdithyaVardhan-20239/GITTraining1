using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class Swap
    {
		static void Main(string[] args)
		{
			Console.WriteLine("Enter first number {0}:");
			int x = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter second number {0}:");
			int y = int.Parse(Console.ReadLine());
			Console.WriteLine($"Numbers before swaping {x} {y}");
			int temp;
			temp = x;
			x = y;
			y = temp;
			Console.WriteLine($"Numbers after swaping {x} {y}");

		}
	}
}
