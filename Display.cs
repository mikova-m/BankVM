using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankVM
{
    internal class Display
    {
         public static void AccountMenu(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n=== Моля изберете ===");
            Console.ResetColor();

            Console.WriteLine("1) Добавяне на пари (депозит) ");
            Console.WriteLine("2) Изтегляне на пари");
            Console.WriteLine("3) Прехвърляне на пари към друг клиент");
            Console.WriteLine("4) Смяна на паролата");

            Console.WriteLine("5) Изход от акаунт");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Вашият избор:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            int choose = int.Parse(Console.ReadLine()); //запомня избора
            Console.ResetColor();

            switch (choose)//Има грешка
            {
                case 1: Person.AddMoney(); break;
                case 2: Person.GetMoney(); break;
                case 3: Person.SendMoney(); break;
                case 4: Person.ChangePass(); break;
                default: Environment.Exit(0); break;
            }

            AccountMenu();
        }
    }
}
