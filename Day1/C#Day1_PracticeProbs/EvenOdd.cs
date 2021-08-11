using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class EvenOdd
    {
		static void Main(string[] args)
		{
			Console.WriteLine("Even a number {0}:");
			int x = int.Parse(Console.ReadLine());
			if (x % 2 == 0)
			{
				Console.WriteLine($"The given number {x} is Even");
			}
			else
			{
				Console.WriteLine($"The given number {x} is Odd");
			}
		}
	}
}
