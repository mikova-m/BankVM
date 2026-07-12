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
        public double Amount { get; set; } //"decimal" се използва за финансови изчисления
        public string Pass { get; set; }


        public Person(int id, string firstName, string lastName, int age, string iban, double amount, string pass)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IBAN = iban;
            Amount = amount;
            Pass = pass;

        }

        static public Person Login() //за да може да се използва в другия клас
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== Вход в банката ======");// in profile

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
                    Console.WriteLine($"ДОБРЕ ДОШЪЛ,");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"=== {user.FirstName} {user.LastName} ===");
                    Console.ResetColor();

                    Display.AccountMenu(user); // отваря менюто на клиента
                }
                else
                {
                    Console.WriteLine("Грешно ID или парола!");
                    Console.ReadLine();
                }
            }
        }


        public static void AddMoney(Person user)
        {
            Console.Write("Сума за добавяне (в евро): ");
            double amountToAdd = double.Parse(Console.ReadLine());

            if (amountToAdd > 0)
            {
                user.Amount += amountToAdd;
                Console.WriteLine($"Успешно добавихте {amountToAdd} евро");
                Console.WriteLine($"Баланс: {user.Amount} евро.");
            }
            else
            {
                Console.WriteLine("Моля, въведете положителна сума.");
            }
        }

        public static void GetMoney(Person user)
        {
            Console.Write("Сума за теглене (в евро): ");
            double amountToGet = double.Parse(Console.ReadLine());
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


            Person recipient = null;
            foreach (Person p in People)

                if (recipient != null)

                {
                    if (p.IBAN == recipientIban)
                    {
                        recipient = p;
                        break;
                    }
                }

            if (recipient == null)
            {
                Console.WriteLine("Не съществува клиент с този IBAN.");
                return;
            }

            //Не позволяваме превод към самия себе си.
            if (recipient == user)
            {
                Console.WriteLine("Не можете да прехвърляте пари към себе си.");
                return;
            }

            Console.Write("Сума за изпращане (в евро): ");
            double amountToSend = double.Parse(Console.ReadLine());

            if (amountToSend > 0 && amountToSend <= user.Amount)
            {
                user.Amount -= amountToSend;
                recipient.Amount += amountToSend;
                Console.WriteLine($"Успешно изпратихте {amountToSend} евро на {recipient.FirstName} {recipient.LastName}");
                Console.WriteLine($"Нов баланс: {user.Amount} евро.");
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

        public string PersonInfoAsCSV()
        {
            string info = $"{ID}, {FirstName}, {LastName}, {Age}, {IBAN}, {Amount}, {Pass}";
            return info;
        }

    }
}
