using System;

namespace BankVM
{
    internal class Program
    {
        public static Person ActiveUser = null;

        static void Main(string[] args)
        {
            Person.People = ReadWrite.ReadPeople();

            while (true)
            {
                ActiveUser = Person.Login();
                Display.AccountMenu();

            }
        }
    }
}
