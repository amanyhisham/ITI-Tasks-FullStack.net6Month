namespace Data_Structer_Day1_Lap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Double ll  Add
            Double_Linked_list employees0 = new Double_Linked_list();
            employees0.AddFirst(new Employee(1, 25, 5000, "IT"));
            employees0.AddFirst(new Employee(2, 30, 7000, "HR"));
            employees0.AddLast(new Employee(3, 20, 5000, "CS"));
            employees0.AddLast(new Employee(4, 60, 5000, "AI"));
            //display
            Console.WriteLine(" All Employees: ");
            employees0.Display();
            //Count
            Console.WriteLine("All Employees  Count: " + employees0.Count());
            //search
            Node node_search=employees0.Search(new Employee(4, 20, 5000, "CS"));
            if (node_search != null) Console.WriteLine("\nFound: ==>" + node_search.data);
            // Delete  
            employees0.Delet(3);
            Console.WriteLine("\nAfter deleting ID 3:");
            employees0.Display();
            // Get by index
            Console.WriteLine("\nEmployee at index 1: ==> " + employees0.GetDataByIndex(1));




            //10-Bulit in Linkedlist
            LinkedList<Employee> employees = new LinkedList<Employee>();
            employees.AddFirst(new Employee(8, 45, 5000, "Sales"));
            employees.AddLast(new Employee(7, 50, 5000, "Data_Analyse"));
            foreach (var emp in employees) {
                Console.WriteLine("\n"+emp);
            }
            var found_node = employees.Find(new Employee(8, 45, 5000, "SC"));
            if (found_node != null)
                Console.WriteLine("\nFound: " + found_node.Value);
            else
                Console.WriteLine("\nEmployee not found");

        }
    }
}
