using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class Params
    {
        private static void swap(ref int x, ref int y)
        {
            Console.WriteLine($"inside swap()----> before swaping {x} , {y}");
            int t = x;
            x = y;
            y = t;
            Console.WriteLine($"inside swap()----> after swaping {x} , {y}");
        }
        private static void calc(int num, out int square, out int cube)
        {
            square = num * num;
            cube = square * num;
        }
        public static void Main()
        {
            int a = 10;
            int b = 30;
            Console.WriteLine($"inside main()----> before swaping {a} , {b}");
            swap(ref a, ref b);

            Console.WriteLine($"inside main()----> after swaping {a} , {b}");

        }
    }
}
