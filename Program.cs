using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BankVM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person.People = ReadWrite.ReadPeople();

            while (true)
            { 
                Person user = Person.Login();
                if (user != null)
                {
                    Display.AccountMenu(user);
                }
            }
        }
    }
}
