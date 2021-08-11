using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    class ExceptionsHanding
    {
        static void Main()
        {
            int empid;
            string ename;
            try
            {
                Console.WriteLine("Enter ur Emp-ID :");
                empid = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter ur Name :");
                ename = Console.ReadLine();

                Console.WriteLine($"This is ur empid : {empid} and this ur name {ename}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter only digits");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Enter only digits");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Thanks for using the app");
            }
        }
    }
}
