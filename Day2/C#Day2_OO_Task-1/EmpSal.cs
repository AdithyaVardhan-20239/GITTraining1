using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    /// <summary>
    /// Create a class called EmployeeSalary with attributes as EmployeeId, name, Basic salary, HR allowance, Travel Allowant, % of income tax deduction. 
    /// Provide appropriate visibility (private/public/protected/static)  of all the attributes. 
    /// Create a constructor to accept employee salary details.
    /// </summary>
    class EmpSal
    {
        int EmpID;
        string ename;
        int bscsal;
        int HRallo;
        int trvlallo;

        public EmpSal()
        {
            EmpID = 0;
            ename = string.Empty;
            bscsal = 0;
            HRallo = 0;
            trvlallo = 0;
        }

        public EmpSal(int id, int bsal, int h_allo, int t_allo, string nam)
        {
            this.EmpID = id;
            this.bscsal = bsal;
            this.HRallo = h_allo;
            this.trvlallo = t_allo;
        }

        public double Inctax(int bsal, int h_allo, int t_allo)
        {
            int grs_sal = bsal + h_allo + t_allo;
            double inc_tax;
            if (grs_sal < 250000 && grs_sal >= 0)
            {
                inc_tax = 0;
            }
            else if (grs_sal >= 250000 && grs_sal < 500000)
            {
                inc_tax = (2.5 * grs_sal) / 100;
            }
            else if (grs_sal >= 500000 && grs_sal < 750000)
            {
                inc_tax = (5 * grs_sal) / 100;
            }
            else if (grs_sal >= 750000 && grs_sal < 1000000)
            {
                inc_tax = (7.5 * grs_sal) / 100;
            }
            else
            {
                inc_tax = (10 * grs_sal) / 100;
            }

            return inc_tax;

        }

    }

    class TeastInctax
    {
        public static void Main()
        {
            EmpSal e1 = new EmpSal(125,400000,100000,100000,"Chiya");
            Console.WriteLine(e1.Inctax(400000, 100000, 100000));
        }
    }
}
