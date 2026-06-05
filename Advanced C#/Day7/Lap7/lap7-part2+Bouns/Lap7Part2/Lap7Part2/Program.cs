using System;
using System.IO;

namespace Lap7_Files
{
    internal class Program
    {
        static string filePath = "students.txt";

        static void Main(string[] args)
        {
            CreateFileIfNotExists();

            bool running = true;
            while (running)
            {
                Console.Clear();
                ShowMenu();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": ViewStudents(); break;
                    case "3": SearchStudent(); break;
                    case "4":
                        running = false;
                        Console.WriteLine("Goodbye!"); break;
                    default:
                        Console.WriteLine("Invalid choice! Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("============================");
            Console.WriteLine("  Student Management System ");
            Console.WriteLine("============================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Exit");
            Console.WriteLine("============================");
        }

        static void CreateFileIfNotExists()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Console.WriteLine("File created: " + filePath);
            }
        }

        static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("=== Add Student ===");

            bool continueAdding = true;
            while (continueAdding)
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    File.AppendAllText(filePath, name + "\n");
                    Console.WriteLine("Saved: " + name);
                }
                else
                {
                    Console.WriteLine("Name cannot be empty!");
                }

                Console.Write("Add another student? (y/n): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "y") continueAdding = false;
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        static void ViewStudents()
        {
            Console.Clear();
            Console.WriteLine("=== All Students ===");

            string[] students = File.ReadAllLines(filePath);

            if (students.Length == 0)
            {
                Console.WriteLine("No students found!");
            }
            else
            {
                Console.WriteLine("Total: " + students.Length);
                Console.WriteLine("-------------------");
                for (int i = 0; i < students.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(students[i]))
                        Console.WriteLine((i + 1) + ". " + students[i]);
                }
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        static void SearchStudent()
        {
            Console.Clear();
            Console.WriteLine("=== Search Student ===");

            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine().ToLower();

            string[] students = File.ReadAllLines(filePath);
            bool found = false;

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].ToLower().Contains(searchName))
                {
                    Console.WriteLine("Found at line " + (i + 1) + ": " + students[i]);
                    found = true;
                }
            }

            if (!found) Console.WriteLine("Student not found!");

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }
    }
}