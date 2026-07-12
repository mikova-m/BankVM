using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankVM
{
    internal class ReadWrite
    {
        static string _filePath = @"..\..\Data\info.txt";

        public static List<Person> ReadPeople()
        {
            List<Person> people = new List<Person>();
            string[] lines = File.ReadAllLines(_filePath); //ИЗИСКВА USING SYSTEM.IO;

            for (int i = 1; i < lines.Length; i++) //Прескачаме антетката която е i=0
            {
                string[] parts = lines[i].Split(',');

                int id = int.Parse(parts[0]);
                string firstName = parts[1];
                string lastName = parts[2];
                int age = int.Parse(parts[3]);
                string iban = parts[4];
                double amount = double.Parse(parts[5]);
                string pass = parts[6];

                Person person = new Person(id, firstName, lastName, age, iban, amount, pass);
                people.Add(person);

            }

            return people;
        }

        public static void UpdatePeopleFile()
        {
            string antetka = "ID, FirstName, LastName, Age, IBAN, Amount, Pass: ";
            List<string> lines = new List<string>();

            lines.Add(antetka);
            foreach (Person c in Person.People) //обикаля
            {
                string info = c.ToString();//извлича като цсв текст
                lines.Add(info);
            }
            File.WriteAllLines(_filePath, lines);//Същински запис във файла
        }
    }
}
