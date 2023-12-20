using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


     public partial class Program
    {
        public static string GenerateCsvFileFunc()
        {
            List<Person> people = GenerateRandomPeople(1000);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "people_dataset.csv");

            var writer = new StreamWriter(filePath);
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(people);
            writer.Close();

            Console.WriteLine($"generate CSV file succesfully, saved to: {filePath}");
            return filePath;
        }

        static List<Person> GenerateRandomPeople(int count)
        {
            List<Person> people = new List<Person>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                string firstName = GetRandomFirstName();
                string lastName = GetRandomLastName();
                int age = random.Next(18, 71); // Random age between 18 and 70
                double weight = random.NextDouble() * (300 - 100) + 100; // Random weight between 100 and 300 lbs
                string gender = random.Next(2) == 0 ? "Male" : "Female";

                people.Add(new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Weight = Math.Round(weight, 2),
                    Gender = gender
                });
            }

            return people;
        }

        static string GetRandomFirstName()
        {
            string[] firstNames = { "Gitty", "Tamar", "Lea", "Efrat", "Noa" };
            Random random = new Random();
            return firstNames[random.Next(firstNames.Length)];
        }

        static string GetRandomLastName()
        {
            string[] lastNames = { "Doe", "Smith", "Johnson", "Williams", "Jones" };
            Random random = new Random();
            return lastNames[random.Next(lastNames.Length)];

        }


    }

