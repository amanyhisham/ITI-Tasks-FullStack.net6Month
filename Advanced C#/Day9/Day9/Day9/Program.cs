using System;

namespace Day9
{
    internal class Program
    {
        // Tuple method - returns 3 values at once
        static (string name, int total, double average) GetStudentInfo()
        {
            string name = "Ahmed";
            int[] marks = { 85, 90, 78, 92, 88 };

            int total = 0;
            foreach (int mark in marks)
                total += mark;

            double average = total / marks.Length;

            return (name, total, average);
        }

        static void Main(string[] args)
        {
            // call the method and get the 3 values
            var student = GetStudentInfo();

            Console.WriteLine("Student Name : " + student.name);
            Console.WriteLine("Total Marks  : " + student.total);
            Console.WriteLine("Average Grade: " + student.average);

            Console.ReadKey();
        }
    }
}