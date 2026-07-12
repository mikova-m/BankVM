using System;

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
                Display.AccountMenu(user);

            }
        }
    }
}
