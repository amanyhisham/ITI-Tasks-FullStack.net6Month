using BusinessLogicLayer;
using BusinessLogicLayer.Model;

namespace PresentionLier
{
    internal class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option:");
                Console.WriteLine("1 to Display All Authors");
                Console.WriteLine("2 to Add new Author");
                Console.WriteLine("3 to Delete Author");
                Console.WriteLine("4 to Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DisplayAllAuthors();
                        WaitForKey();
                        break;

                    case "2":
                        Console.Clear();
                        AddNewAuthor();
                        WaitForKey();
                        break;
                    case "3":
                        Console.Clear();
                        DeleteAuthor();
                        WaitForKey();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        WaitForKey();
                        break;
                }



                static void WaitForKey()
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey(true);
                }

                static void DisplayAllAuthors()
                {
                    Console.WriteLine("===============================================");
                    AuthorManger authorManager = new AuthorManger();
                    Console.WriteLine("All Authors:");
                    Console.WriteLine();
                    List<Author> authors = authorManager.getAllAuthor();//list of authors

                    for (int i = 0; i < authors.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {authors[i]}");//row ==auther 9 attribute
                    }
                }

                static void AddNewAuthor()
                {
                    Console.WriteLine("===============================================");
                    AuthorManger authorManager = new AuthorManger();
                    Author newAuthor = new Author();

                    Console.WriteLine("Enter Author ID:");
                    newAuthor.Id = Console.ReadLine();

                    Console.WriteLine("Enter First Name:");
                    newAuthor.fName = Console.ReadLine();

                    Console.WriteLine("Enter Last Name:");
                    newAuthor.lName = Console.ReadLine();

                    Console.WriteLine("Enter Phone:");
                    newAuthor.Phone = Console.ReadLine();

                    Console.WriteLine("Enter Address:");
                    newAuthor.address = Console.ReadLine();

                    Console.WriteLine("Enter City:");
                    newAuthor.City = Console.ReadLine();

                    Console.WriteLine("Enter State:");
                    newAuthor.State = Console.ReadLine();

                    Console.WriteLine("Enter Zip Code:");
                    newAuthor.Zip = Console.ReadLine();

                    Console.WriteLine("Is there a contract? (yes/no):");
                    string contractInput = Console.ReadLine().ToLower();

                    newAuthor.Contract = (contractInput == "yes");

                    Console.WriteLine();
                    int rowsAffected = authorManager.addAuthor(newAuthor);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Author added successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to add author");
                    }

                    Console.WriteLine($"{rowsAffected} rows Affected");
                }

                static void DeleteAuthor()
                {
                    Console.WriteLine("===============================================");
                    AuthorManger authorManager = new AuthorManger();

                    Console.WriteLine("Enter the ID of the author to delete:");

                    string id = Console.ReadLine();

                    Console.WriteLine();
                    int rowsAffected = authorManager.deletAuthor(id);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Author deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete author with ID: {id}");
                    }

                    Console.WriteLine($"{rowsAffected} rows Affected");
                }

            }
        }
    }
}
