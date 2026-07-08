using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankVM
{
    internal class Person
    {
        public static List<Person> People = new List<Person>();

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string IBAN { get; set; }
        public decimal Amount { get; set; } //"decimal" се използва за финансови изчисления
        public string Pass { get; set; }


        public Person(int id, string firstName, string lastName, int age, string iban, decimal amount, string pass)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IBAN = iban;
            Amount = amount;
            Pass = pass;

        }

        static void Login()
        {
            Console.Clear();

            Console.Write("Въведете ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Въведете парола: ");
            string pass = Console.ReadLine();


            Person user = null;

            foreach (Person c in People)
            {
                if (c.ID == id && c.Pass == pass)
                {
                    user = c;
                    break;
                }
            }


            if (user != null)
            {
                Console.WriteLine("Успешен вход!");
                Console.WriteLine($"Добре дошъл, {user.FirstName} {user.LastName}");
                Console.Read();

                Display.AccountMenu(); // отваря менюто на клиента
            }
            else
            {
                Console.WriteLine("Грешно ID или парола!");
                Console.ReadKey();
            }
        }


        public static void AddMoney(Person user)
        {
            Console.Write("Сума за добавяне (в евро): ");
            decimal amountToAdd = decimal.Parse(Console.ReadLine());

            if (amountToAdd > 0)
            {
                user.Amount += amountToAdd;
                Console.WriteLine($"Успешно добавихте {amountToAdd} евро. Нов баланс: {user.Amount} евро.");
            }
            else
            {
                Console.WriteLine("Моля, въведете положителна сума.");
            }
        }

        public static void GetMoney(Person user)
        {
            Console.Write("Сума за теглене (в евро): ");
            decimal amountToGet = decimal.Parse(Console.ReadLine());
            if (amountToGet > 0 && amountToGet <= user.Amount)
            {
                user.Amount -= amountToGet;
                Console.WriteLine($"Успешно изтеглихте {amountToGet} евро. Нов баланс: {user.Amount} евро.");
            }
            else if (amountToGet > user.Amount)
            {
                Console.WriteLine("Недостатъчен баланс за тази операция.");
            }
            else
            {
                Console.WriteLine("Моля, въведете положителна сума.");
            }
        }

        public static void SendMoney(Person user)
        {
            Console.Write("Въведете IBAN на получателя: ");
            string recipientIban = Console.ReadLine();
            Person recipient = People.FirstOrDefault(p => p.IBAN == recipientIban);//help и може ли това да се направи така? със стринг
            if (recipient != null)
            {
                Console.Write("Сума за изпращане (в евро): ");
                decimal amountToSend = decimal.Parse(Console.ReadLine());
                if (amountToSend > 0 && amountToSend <= user.Amount)
                {
                    user.Amount -= amountToSend;
                    recipient.Amount += amountToSend;
                    Console.WriteLine($"Успешно изпратихте {amountToSend} евро на {recipient.FirstName} {recipient.LastName}. Нов баланс: {user.Amount} евро.");
                }
                else if (amountToSend > user.Amount)
                {
                    Console.WriteLine("Недостатъчен баланс за тази операция.");
                }
                else
                {
                    Console.WriteLine("Моля, въведете положителна сума.");
                }
            }
            else
            {
                Console.WriteLine("Не съществува потребител с този IBAN.");
            }

        }

        public static void ChangePassword(Person user)
        {
            Console.Write("Въведете нова парола: ");
            string newPassword = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPassword))//help 
            {
                user.Pass = newPassword;
                Console.WriteLine("Паролата е успешно променена.");
            }
            else
            {
                Console.WriteLine("Паролата не може да бъде празна.");
            }
        }

        public static void Exit(Person user)
        {
            ReadWrite.UpdatePeopleFile();
            Console.WriteLine("Данните са записани. Излизане от системата...");
            Console.ReadKey();
            Login();
        }



    }
}
