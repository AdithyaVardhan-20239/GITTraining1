using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    /// <summary>
    /// A person has several attributes that include name, date of birth, address and marital status (single, married, divorced or widowed). 
    /// Create a four parameter constructor to initialise the fields Add properties for the fields.
    /// Write a method GetAge() to return the age of the person Write a method CanMarry() to return true or false 
    /// if a person can get married(people can get married over the age of 18 if they are not already maried)
    /// Write a simple driver program to test the class
    /// </summary>

    class Man
    {
        public string name;
        DateTime DOB;
        string adrs;
        string m_sts;

        public Man()
        {
            name = "N/A";
            DOB = DateTime.MinValue;
            adrs = "N/A";
            m_sts = "N/A";
        }

        public Man(string nam,DateTime dob, string addrs,string msts)
        {
            this.name = nam;
            this.DOB = dob;
            this.adrs = addrs;
            this.m_sts = msts;
        }

        public string setName(string nam)
        {
            return  $"You are Mr/Mrs/Ms : {nam}";
        }

        public string getName()
        {
            return this.name;
        }
        public string setAdrs(string addrs)
        {
            return $"This is Address : {addrs}";
        }

        public string getAdrs()
        {
            return this.adrs;
        }
        public string setMaritalSts(string msts)
        {
            return $"Your Marrital Status is : {msts}";
        }

        public string getMaritalSts()
        {
            return this.m_sts;
        }
        public string setDOB(DateTime dob)
        {
            return $"Your DOB is : {dob}";
        }
        public DateTime getDOB()
        {
            return this.DOB;
        }
        public int getAge()
        {
            int age = DateTime.Now.Subtract(this.DOB).Days;
            age = age / 365;
            return age;
        }

        public bool canMarry()
        {
            if (this.getAge() > 18 && this.getMaritalSts() != "Married")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string decision = canMarry() ? "can marry" : "can not marry";
            return $"{this.name} lives at {this.getAdrs()}, born on {this.getDOB()}, {this.getMaritalSts()}, {this.getAge()} years old and {decision}";
        }
    }

    class TestMan
    {
        static void Main()
        {
            Man m1 = new Man();
            Console.WriteLine(m1.name);
            Console.WriteLine(m1.getDOB());
            Console.WriteLine(m1.getAdrs());
            Console.WriteLine(m1.getMaritalSts());
            Console.WriteLine(m1.getAge());
            Console.WriteLine(m1.canMarry());
            Console.WriteLine(m1.ToString());

            Man m2 = new Man("Ford",new DateTime(2000, 5, 25),"XYZ lane","Single");
            Console.WriteLine(m2.name);
            Console.WriteLine(m2.getDOB());
            Console.WriteLine(m2.getAdrs());
            Console.WriteLine(m2.getMaritalSts());
            Console.WriteLine(m2.getAge());
            Console.WriteLine(m2.canMarry());
            Console.WriteLine(m2.ToString());
        }
    }


}
