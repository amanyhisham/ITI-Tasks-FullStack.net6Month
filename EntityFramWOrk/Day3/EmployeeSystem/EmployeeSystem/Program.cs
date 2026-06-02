using Dapper;
using Microsoft.Data.SqlClient;
using EmployeeSystem;
var connectionString = "Server=.\\SQLEXPRESS03;Database=EmployeeDB;Trusted_Connection=True;Encrypt=False;";

while (true)
{
    Console.WriteLine("\n===== Employee System =====");

    // Part 2: Multiple Rows
    Console.WriteLine("1- Show All Employees");

    // Part 2: Single Row
    Console.WriteLine("2- Show Employee by ID");

    // Part 3: Scalar Queries----------------->get one value
    Console.WriteLine("3- Count / Max / Avg Salary");

    // Part 4: Data Manipulation
    Console.WriteLine("4- Add Department");
    Console.WriteLine("5- Add Employee");
    Console.WriteLine("6- Update Employee Salary");
    Console.WriteLine("7- Delete Employee");

    // Part 5: Relationship
    Console.WriteLine("8- Show Employees with Department");

    // Part 6: Stored Procedures
    Console.WriteLine("9- Add Employee (Stored Procedure)");
    Console.WriteLine("10- Show All Employees (Stored Procedure)");

    Console.WriteLine("0- Exit");
    Console.Write("\nChoose: ");

    var choice = Console.ReadLine();
    using var connection = new SqlConnection(connectionString);
     if (choice == "1")
    {
        var sql = "SELECT * FROM Employees";
        var employees = connection.Query<Employee>(sql);//---------->dapper get data and put on list to make easy for DB

        Console.WriteLine("\nAll Employees:");
        Console.WriteLine("------------------------------------------");
        foreach (var e in employees)
        {
            Console.WriteLine($"ID: {e.Id} | Name: {e.Name} | Salary: {e.Salary}");
        }
        Console.WriteLine("------------------------------------------");
    }
    else if (choice == "2")
    {
        Console.Write("Enter Employee ID: ");
        var id = int.Parse(Console.ReadLine());

        var sql = "SELECT * FROM Employees WHERE Id = @Id";
        var employee = connection.QueryFirstOrDefault<Employee>(sql, new { Id = id });

        if (employee == null)
            Console.WriteLine("Employee Not Found!");
        else
            Console.WriteLine($"ID: {employee.Id} | Name: {employee.Name} | Salary: {employee.Salary}");
    }
    else if (choice == "3")
    {
        var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Employees");
        var maxSalary = connection.ExecuteScalar<decimal>("SELECT MAX(Salary) FROM Employees");
        var avgSalary = connection.ExecuteScalar<decimal>("SELECT AVG(Salary) FROM Employees");

        Console.WriteLine($"\n Total Employees: {count}");
        Console.WriteLine($" Highest Salary: {maxSalary}");
        Console.WriteLine($" Average Salary: {avgSalary:F2}");
    }
    else if (choice == "4")
    {
        Console.Write("Department Name: ");
        var name = Console.ReadLine();

        var sql = "INSERT INTO Departments (Name) VALUES (@Name)";
        var rows = connection.Execute(sql, new { Name = name });

        Console.WriteLine(rows > 0 ? "Department Added!" : "Failed!");

    }
    else if (choice == "5")
    {
        Console.Write("Employee Name: ");
        var name = Console.ReadLine();

        Console.Write("Salary: ");
        var salary = decimal.Parse(Console.ReadLine());

        Console.Write("Department ID: ");
        var deptId = int.Parse(Console.ReadLine());

        var sql = "INSERT INTO Employees (Name, Salary, DepartmentId) VALUES (@Name, @Salary, @DepartmentId)";
        var rows = connection.Execute(sql, new { Name = name, Salary = salary, DepartmentId = deptId });

        Console.WriteLine(rows > 0 ? "Employee Added!" : "Failed!");
    }
    else if (choice == "6")
    {
        Console.Write("Enter Employee ID: ");
        var id = int.Parse(Console.ReadLine());

        Console.Write("Enter New Salary: ");
        var salary = decimal.Parse(Console.ReadLine());

        var sql = "UPDATE Employees SET Salary = @Salary WHERE Id = @Id";
        var rows = connection.Execute(sql, new { Salary = salary, Id = id });

        Console.WriteLine(rows > 0 ? "Salary Updated!" : " Employee Not Found!");
    }
    else if (choice == "7")
    {
        Console.Write("Enter Employee ID: ");
        var id = int.Parse(Console.ReadLine());

        Console.Write("Are you sure? (y/n): ");
        var confirm = Console.ReadLine();

        if (confirm == "y")
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";
            var rows = connection.Execute(sql, new { Id = id });

            Console.WriteLine(rows > 0 ? " Employee Deleted!" : "Employee Not Found!");
        }
        else
        {
            Console.WriteLine("Cancelled!");
        }
    }
    else if (choice == "8")
    {
        var sql = @"SELECT e.Id, e.Name, e.Salary, d.Name AS DepartmentName 
                FROM Employees e 
                INNER JOIN Departments d ON e.DepartmentId = d.Id";

        var employees = connection.Query<Employee>(sql);

        Console.WriteLine("\nEmployees with Departments:");
        Console.WriteLine("------------------------------------------");
        foreach (var e in employees)
        {
            Console.WriteLine($"Name: {e.Name} | Salary: {e.Salary} | Dept: {e.DepartmentName}");
        }
        Console.WriteLine("------------------------------------------");
    }
    else if (choice == "9")
    {
        Console.Write("Employee Name: ");
        var name = Console.ReadLine();

        Console.Write("Salary: ");
        var salary = decimal.Parse(Console.ReadLine());

        Console.Write("Department ID: ");
        var deptId = int.Parse(Console.ReadLine());

        var rows = connection.Execute("InsertEmployee",
            new { Name = name, Salary = salary, DepartmentId = deptId },
            commandType: System.Data.CommandType.StoredProcedure);

        Console.WriteLine(rows > 0 ? "✅ Employee Added!" : "❌ Failed!");
    }
    else if (choice == "10")
    {
        var employees = connection.Query<Employee>("GetAllEmployees",
            commandType: System.Data.CommandType.StoredProcedure);

        Console.WriteLine("\n All Employees (Stored Procedure):");
        Console.WriteLine("------------------------------------------");
        foreach (var e in employees)
        {
            Console.WriteLine($"ID: {e.Id} | Name: {e.Name} | Salary: {e.Salary}");
        }
        Console.WriteLine("------------------------------------------");
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
