using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankVM
{
    internal class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int IBAN { get; set; }
        public decimal Amount { get; set; } //"decimal" се използва за финансови изчисления
        public string Pass { get; set; }


        public Person (int id, string firstname, string lastname, int age, int iban, decimal amount, string pass)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            IBAN = iban;
            Amount = amount;
            Pass = pass;

        }

    }
}
