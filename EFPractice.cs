using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    class EFPractice
    {
        public static void Main()
        {
            //getEmpDetails();
            //getEmpDetailsbyID();
            //getEmpDetailsbyDeptID();
            //getMaxSal();
            //getSumofSal();
            //getEmpnameStartswithJ();
            //AddNewEmployee();
            //UpdateEmployeeDetails();
            //DeleteEmployee();
            //GetAllEmpDetails_SP();
            //UpdateEmpDetails_SP();
            //DeleteEmpDetails_SP();
            UpdateEmpName_SP_WithParams();
        }

        //All the employee name and sal
        private static void getEmpDetails()
        {
            var ctx = new AugTTS_2021Context();
            var emps = ctx.Emps;
            /*
             Using SQL type of queary
             var emps = from e in ctx.emps
                select e;
             */
            foreach (var e in emps)
            {
                Console.WriteLine(e.Ename + " " + e.Sal.ToString());
            }
        }

        //Employee detail with his ID 
        private static void getEmpDetailsbyID()
        {
            var ctx = new AugTTS_2021Context();
            var emp = ctx.Emps.Where(e => e.Empno == 7369).SingleOrDefault();
            Console.WriteLine(emp.Ename + " " + emp.Sal.ToString());
        }

        //List all emps who are in 10th dept
        private static void getEmpDetailsbyDeptID()
        {
            var ctx = new AugTTS_2021Context();
            var dept = ctx.Emps;
            foreach (var e in dept)
            {
                if (e.Deptno == 10)
                {
                    Console.WriteLine(e.Ename);
                }
            }
        }

        //What is the max sal in the emp table
        private static void getMaxSal()
        {
            var ctx = new AugTTS_2021Context();
            var sal = ctx.Emps.Max(e => e.Sal);
            Console.WriteLine(sal);

        }

        //what is the sum of salary in 10th dept
        private static void getSumofSal()
        {
            var ctx = new AugTTS_2021Context();
            var sum = ctx.Emps.Where(e => e.Deptno == 10).Sum(e => e.Sal);
            Console.WriteLine(sum);
        }

        //list all emps whose name starts with J
        private static void getEmpnameStartswithJ()
        {
            var ctx = new AugTTS_2021Context();
            var emps = from e in ctx.Emps
                       where e.Ename.StartsWith("J")
                       select e;
            foreach (var e in emps)
            {
                Console.WriteLine(e.Ename);
            }
        }

        //Adding a New Employee
        private static void AddNewEmployee()
        {
            var ctx = new AugTTS_2021Context();
            Emp employee = new();
            employee.Empno = 20239;
            employee.Ename = "Adithya";
            employee.Sal = 4000;
            employee.Deptno = 20;
            try
            {
                ctx.Emps.Add(employee);
                ctx.SaveChanges();
                Console.WriteLine("New employee Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }

        //Updating Info
        private static void UpdateEmployeeDetails()
        {
            var ctx = new AugTTS_2021Context();
            var emp = ctx.Emps.Where(e => e.Empno == int.Parse(Console.ReadLine())).SingleOrDefault();
            emp.Ename = "Sheela";
            emp.Sal = 4500; //Updating salary
            emp.Deptno = 10; //Updating Department
            emp.Job = "Trainer"; //Updating Job
            try
            {
                ctx.Emps.Update(emp);
                ctx.SaveChanges();
                Console.WriteLine("Employee Details are Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }

        //Deleting Employee
        private static void DeleteEmployee()
        {
            var ctx = new AugTTS_2021Context();
            var emp = ctx.Emps.Where(e => e.Empno == int.Parse(Console.ReadLine())).SingleOrDefault();
            try
            {
                ctx.Emps.Remove(emp);
                ctx.SaveChanges();
                Console.WriteLine("Employee Deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }

        //Calling Stored Procedure
        private static void GetAllEmpDetails_SP()
        {
            var ctx = new AugTTS_2021Context();
            try
            {
                var emps = ctx.Set<Emp>().FromSqlRaw("GetAllEmployeeDeatils").ToList();
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Ename + " " + emp.Sal);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }
        //Updating using SP
        private static void UpdateEmpDetails_SP()
        {
            var ctx = new AugTTS_2021Context();
            try
            {
                ctx.Database.ExecuteSqlRaw("UpdateEmpNamebyEmpno @p0,@p1", 20239, "Adithya");
                Console.WriteLine("Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }

        //Deleting Using Sp
        private static void DeleteEmpDetails_SP()
        {
            var ctx = new AugTTS_2021Context();
            try
            {
                ctx.Database.ExecuteSqlRaw("DeleteEmployeeByEmpno @p0", 2979);
                Console.WriteLine("Deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }

        // Updating with Params
        private static void UpdateEmpName_SP_WithParams()
        {
            var ctx = new AugTTS_2021Context();
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@empno",
                    SqlDbType = System.Data.SqlDbType.Int,Size = 10,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = 20239
                },
                new SqlParameter()
                {
                    ParameterName = "@newname",
                    SqlDbType = System.Data.SqlDbType.VarChar,Size = 10,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = "AdithyaVC"
                }
            };
            try
            {
                var result = ctx.Database.ExecuteSqlRaw("UpdateEmpNamebyEmpno @Empno,@newname", param);
                Console.WriteLine("Updated Using Params");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void DiscArch()
        {
            var ctx = new AugTTS_2021Context();
            try
            {
                var emp = ctx.Emps.Where(x => x.Empno == 20239).SingleOrDefault();
                ctx.Dispose();
                UpdateEmpName(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
