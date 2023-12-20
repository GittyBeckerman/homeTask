
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    public static void Main()
    {
        try
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("hello! to enter csvFile Path enter 1,/n to generate automaticly csv file enter 2 /n , CancellationToken exit enter 0");
                string info = Console.ReadLine();
                if (info == "1")
                {
                    Console.WriteLine("please enter valid path of your csv file");
                    string path = Console.ReadLine();
                    List<Person> people = ReadCsvFile(path);
                    CalculateAndPrintResults(people);

                }
                if (info == "2")
                {
                    string path = GenerateCsvFileFunc();
                    List<Person> people = ReadCsvFile(path);
                    CalculateAndPrintResults(people);

                }
                if (info == "0")
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("wrong output, please try again");
                }

                // Read CSV file and load data into a list of People
                //rum the function that calculate the averages
            }
        }
        catch(Exception e) {
            Console.WriteLine(e.Message);
        }

    }

    public static  List<Person> ReadCsvFile(string filePath)
    {
        List<Person> people = new List<Person>();

        var reader = new StreamReader(filePath);
            reader.ReadLine(); // Skip header
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                people.Add(new Person
                {
                    FirstName = values[0],
                    LastName = values[1],
                    Age = int.Parse(values[2]),
                    Weight = double.Parse(values[3]),
                    Gender = values[4]
                });
            }
        

        return people;
    }

    public  static void CalculateAndPrintResults(List<Person> people)
    {
        // Calculate average age of all people
        double averageAge = people.Average(p => p.Age);
        Console.WriteLine($"Average Age of All People: {averageAge:F2}");

        // Count people weighing between 120lbs and 140lbs
        int countWeightBetween120And140 = people.Count(p => p.Weight >= 120 && p.Weight <= 140);
        Console.WriteLine($"Total People Weighing between 120lbs and 140lbs: {countWeightBetween120And140}");

        // Calculate average age of people weighing between 120lbs and 140lbs
        double averageAgeWeightBetween120And140 = people
            .Where(p => p.Weight >= 120 && p.Weight <= 140)
            .Average(p => p.Age);
        Console.WriteLine($"Average Age of People Weighing between 120lbs and 140lbs: {averageAgeWeightBetween120And140:F2}");
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Gender { get; set; }
}