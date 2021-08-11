using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS1
{
    /// <summary>
    /// Create a class called BankAccount and have default constructor to take balance as 500 and another parameterized to take other than 500.
    /// </summary>
    class BnkAcc
    {
        string Accno;
        int Bal;

        private BnkAcc()
        {
            Accno = string.Empty;
            Bal = 0;
        }

        private BnkAcc(string acc, int bal)
        {
            this.Accno = acc;
            this.Bal = bal;

        }


    }
}
