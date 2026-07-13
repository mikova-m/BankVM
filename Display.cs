using System;

namespace BankVM
{
    internal class Display
    {
         public static void AccountMenu()
         {
            Person user = Program.ActiveUser; // взимаме активния потребител от Program.cs

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=== Моля изберете ===");
                Console.ResetColor();

                Console.WriteLine($"Баланс: {user.Amount} евро");//добавено от нас, няма го като изискване, но е полезно и удобно
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
                    //case 1: Person.AddMoney(user);break; 
                    case 1: user.AddMoneyUsingInstancion();break;    
                    case 2: Person.GetMoney(user);break;                                                
                    case 3: Person.SendMoney(user);break;               
                    case 4: Person.ChangePassword(user);break;                      
                    case 5:
                        ReadWrite.UpdatePeopleFile(); // записва промените във файла
                        Console.WriteLine("Излизане от акаунта...(натиснете enter)");
                        Console.ReadLine();
                        return;
                    default: Environment.Exit(0); break;
                }
            }
         }
    }
}
