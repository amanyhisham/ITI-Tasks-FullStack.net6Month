using Lap5AdvancedC;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        #region Task 1 - var & Complex Type

        Console.WriteLine("-------------------------Task1-------------------------");

        var data = GetData(); // List<Dictionary<string, object>>

        foreach (var item in data)
        {
            foreach (var kv in item)
            {
                Console.WriteLine($"{kv.Key} : {kv.Value}");
            }

            Console.WriteLine("----------------");
        }

        #endregion


        #region Task 2 - Extension Methods

        Console.WriteLine("--------------------------------Task2--------------------------------");

        #region Email Validation

        Console.WriteLine("******** Email validation ********");

        string email1 = "amany43@gmail.com";
        string email2 = "wrongemail";

        Console.WriteLine(email1.IsValidEmail()); // True
        Console.WriteLine(email2.IsValidEmail()); // False

        #endregion


        #region Above Average Numbers

        Console.WriteLine("******** Above average numbers ********");

        List<int> numbers = new List<int>() { 10, 20, 30, 40, 50 };

        var result = numbers.GetAboveAverage();

        Console.WriteLine("Numbers above average:");

        foreach (var num in result)
        {
            Console.WriteLine(num);
        }

        #endregion


        #region Friendly Date

        Console.WriteLine("******** Friendly Date ********");

        DateTime today = DateTime.Today;
        DateTime yesterday = DateTime.Today.AddDays(-1);
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime oldDate = new DateTime(2020, 5, 10);

        Console.WriteLine(today.ToFriendlyDate());
        Console.WriteLine(yesterday.ToFriendlyDate());
        Console.WriteLine(tomorrow.ToFriendlyDate());
        Console.WriteLine(oldDate.ToFriendlyDate());

        #endregion

        #endregion


        #region Task 3 - foreach with Zoo

        Console.WriteLine("--------------------------------Task3--------------------------------");

        Zoo zoo = new Zoo();

        zoo.AddAnimal(new Animal("Lion"));
        zoo.AddAnimal(new Animal("Sparrow"));
        zoo.AddAnimal(new Animal("Elephant"));

        zoo.ShowAnimals();

        #endregion
    }


    #region Task 1 Method

    static List<Dictionary<string, object>> GetData()
    {
        return new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>()
            {
                { "Name", "Ali" },
                { "Age", 22 }
            },
            new Dictionary<string, object>()
            {
                { "Name", "Sara" },
                { "Age", 23 }
            }
        };
    }

    #endregion
}