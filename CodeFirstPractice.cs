using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst
{
    class CodeFirstPractice
    {
        static void Main()
        {
            //AddNewBook();
            //AddNewCstmrandOrder();
            //AddOrdertoCstmr();
            //NewOrdertoCstmr(2);
            //GetAllCustomerWithout_EagerLoading();
            //GetAllCustomersWithOrder_ExplicitLoading();
            //DelOrder(1);

        }

        private static void AddNewBook()
        {
            var ctx = new Context();
            Book book1 = new();
            book1.BookID = 1;
            book1.BookName = "EF CodeFirst";
            book1.Price = 100;
            try
            {
                ctx.Books.Add(book1);
                ctx.SaveChanges();
                Console.WriteLine("New Book Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }

        private static void AddNewCstmrandOrder()
        {
            var ctx = new Context();
            Customer cust = new();
            cust.Cstmr_ID = 1;
            cust.Cstmr_Name = "Adithya";

            Order ord = new();
            ord.Amount = 150;
            ord.Order_ID = 1;
            ord.OrderDate = DateTime.Today;

            ord.Cstmr = cust;
            //list <Order> myorders = new List<Order>();
            //myorders.Add(Ord);

            //cust.Orders = myorders;

            try
            {
                ctx.Orders.Add(ord);
                ctx.SaveChanges();
                Console.WriteLine("New Customer and Order are added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddOrdertoCstmr()
        {
            var ctx = new Context();
            Customer cust = new();
            cust.Cstmr_ID = 2;
            cust.Cstmr_Name = "AdithyaVC";

            Order ord = new();
            ord.Amount = 1500;
            ord.Order_ID = 2;
            ord.OrderDate = DateTime.Today;

            Order ord1 = new();
            ord1.Amount = 15;
            ord1.Order_ID = 3;
            ord1.OrderDate = DateTime.Today;

            Order ord2 = new();
            ord2.Amount = 15000;
            ord2.Order_ID = 4;
            ord2.OrderDate = DateTime.Today;


            //ord.Cstmr = cust;
            List<Order> myorders = new ();
            myorders.Add(ord);
            myorders.Add(ord1);
            myorders.Add(ord2);

            cust.Orders = myorders;

            try
            {
                ctx.Customers.Add(cust);
                ctx.SaveChanges();
                Console.WriteLine("New Customer and his Orders are added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void NewOrdertoCstmr(int id)
        {
            var ctx = new Context();
            var cust1 = ctx.Customers.Where(c => c.Cstmr_ID == id).SingleOrDefault();

            Order ord3 = new();
            ord3.Amount = 5000;
            ord3.Order_ID = 5;
            ord3.OrderDate = DateTime.Today;

            ord3.Cstmr = cust1;
            try
            {
                ctx.Orders.Add(ord3);
                ctx.SaveChanges();
                Console.WriteLine("Customer placed a new odered.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.ToString());
            }
        }

        private static void GetAllCustomerWithout_EagerLoading()
        {
            //Eager loading means that the related data is loaded from the database as part of the initial query
            var ctx = new Context();
            try
            {
                //var cust = ctx.Customers.Include("Orders");
                var cust = ctx.Customers.Include(o => o.Orders);
                foreach (var item in cust)
                {
                    Console.Write(item.Cstmr_Name);
                    Console.Write("---->");
                    foreach (var item1 in item.Orders)
                    {
                        Console.WriteLine(item1.Amount.ToString());
                    }
                    Console.WriteLine("\n-------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetAllCustomersWithOrder_ExplicitLoading()
        {

            //Explicit Loading Means that the related data is 
            //explicitly loaded from the database at a later time.
            //Needs MultipleActiveResultSet to be set to True in the connect string in the context class 
            var ctx = new Context();
            try
            {
                //var customers=ctx.Customers.Include("Orders");
                var customers = ctx.Customers;

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Cstmr_Name);
                    Console.WriteLine("_____________");

                    ctx.Entry(customer).Collection(o => o.Orders).Load();

                    foreach (var order in customer.Orders)
                    {
                        Console.WriteLine(order.Amount.ToString() + " " + order.OrderDate.ToString());
                    }
                    Console.WriteLine("_______________");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.ToString());
            }
        }

        private static void DelOrder(int ID)
        {
            var ctx = new Context();
            var del_Ord = ctx.Orders.SingleOrDefault(o => o.Order_ID == ID);
            try
            {

                ctx.Orders.Remove(del_Ord);
                ctx.SaveChanges();
                Console.WriteLine("Order deleted successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }
    }
}
