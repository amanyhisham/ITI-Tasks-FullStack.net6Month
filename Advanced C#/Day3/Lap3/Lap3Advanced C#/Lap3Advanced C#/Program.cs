namespace Lap3Advanced_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------company------------------------------------------");
            Company company =new Company("TechCorp", 10000);
            Employee emp1 = new Employee("amany", 5000);
            Employee emp2 = new Employee("ali", 2500);
            Employee emp3 = new Employee("amira", 3100);


            company.AddEmployee(emp1);
            company.AddEmployee(emp2);
            company.AddEmployee(emp3);


            emp1.IncreaseSalary(500);  
            emp2.IncreaseSalary(300);
            Console.WriteLine("----------------------------delegate------------------------------------------");
            List<Employee> highSalary = company.FilterEmployees(e => e.Salary > 3000);
            foreach (var emp in highSalary)
            {
                Console.WriteLine(emp.Name + " = " + emp.Salary);
            }
        }
    }
}
