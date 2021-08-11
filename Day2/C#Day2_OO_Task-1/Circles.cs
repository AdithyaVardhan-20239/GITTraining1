using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    /// <summary>
    /// Circle is a class with property radius and methods setRadius(), getRadius(), 
    /// calcDiameter(), calcArea(). Use double precision for everything. Write appropriate driver program to test the methods.
    /// </summary>
    class Circles
    {
        double rad;

        public Circles()
        {
            rad = 0;
        }

        public Circles(double r)
        {
            this.rad = r;
        }

        public double setRadius()
        {
            this.rad = double.Parse(Console.ReadLine());
            return this.rad;
        }

        public double getRadius()
        {
            return this.rad;
        }

        public double calcDiameter()
        {
            return 2 * (this.rad);
        }

        public double calcArea()
        {
            return (Math.PI) * (this.rad) * (this.rad);
        }
    }

    class TestCircles
    {
        static void Main()
        {
            Circles c = new Circles();
            Console.WriteLine(c.calcArea());
            Console.WriteLine(c.calcDiameter());

            Circles c1 = new Circles(15);
            Console.WriteLine(c1.calcArea());
            Console.WriteLine(c1.calcDiameter());
        }
    }
}
