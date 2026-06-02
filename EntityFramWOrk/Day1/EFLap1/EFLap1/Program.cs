using Microsoft.EntityFrameworkCore;
using var context = new AppDbContext();

while (true)
{
    Console.WriteLine("\n===== Employee System =====");
    Console.WriteLine("1- Add Employee");
    Console.WriteLine("2- Show All Employees");
    Console.WriteLine("3- Update Employee");
    Console.WriteLine("4- Delete Employee");
    Console.WriteLine("0- Exit");
    Console.Write("\nChoose: ");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Enter SSN: ");
        int ssn = int.Parse(Console.ReadLine());

        Console.Write("Enter First Name: ");
        string fname = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lname = Console.ReadLine();

        Console.Write("Enter Address: ");
        string address = Console.ReadLine();

        Console.Write("Enter Salary: ");
        int salary = int.Parse(Console.ReadLine());

        var emp = new Employee
        {
            Ssn = ssn,
            Fname = fname,
            Lname = lname,
            Address = address,
            Salary = salary
        };

        context.Employees.Add(emp);
        context.SaveChanges();
        Console.WriteLine(" Employee Added!");
    }

    else if (choice == "2")
    {
        var employees = context.Employees.ToList();

        if (employees.Count == 0)
        {
            Console.WriteLine("No Employees Found!");
        }
        else
        {
            Console.WriteLine("\n All Employees:");
            Console.WriteLine("------------------------------------------");
            foreach (var e in employees)
            {
                Console.WriteLine($"SSN: {e.Ssn} | Name: {e.Fname} {e.Lname} | Address: {e.Address} | Salary: {e.Salary}");
            }
            Console.WriteLine("------------------------------------------");
        }
    }


    else if (choice == "3")
    {
        Console.Write("Enter SSN to Update: ");
        int ssn = int.Parse(Console.ReadLine());

        var emp = context.Employees.Find(ssn);
        if (emp == null)
        {
            Console.WriteLine(" Employee Not Found!");
        }
        else
        {
            Console.Write("Enter New First Name: ");
            emp.Fname = Console.ReadLine();

            Console.Write("Enter New Last Name: ");
            emp.Lname = Console.ReadLine();

            Console.Write("Enter New Address: ");
            emp.Address = Console.ReadLine();

            Console.Write("Enter New Salary: ");
            emp.Salary = int.Parse(Console.ReadLine());

            context.SaveChanges();
            Console.WriteLine(" Employee Updated!");
        }
    }
    else if (choice == "4")
    {
        Console.Write("Enter SSN to Delete: ");
        int ssn = int.Parse(Console.ReadLine());

        var emp = context.Employees.Find(ssn);
        if (emp == null)
        {
            Console.WriteLine(" Employee Not Found!");
        }
        else
        {
            Console.Write($"Are you sure you want to delete {emp.Fname}? (y/n): ");
            var confirm = Console.ReadLine();

            if (confirm == "y")
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                Console.WriteLine(" Employee Deleted!");
            }
            else
            {
                Console.WriteLine("Cancelled!");
            }
        }
    }
    else if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine(" Invalid Choice!");
    }
}