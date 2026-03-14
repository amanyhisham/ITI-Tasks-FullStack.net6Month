namespace Data_Structer_Day1_Lap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Double ll  Add
            //Double_Linked_list employees0 = new Double_Linked_list();
            //employees0.AddFirst(new Employee(1, 25, 5000, "IT"));
            //employees0.AddFirst(new Employee(2, 30, 7000, "HR"));
            //employees0.AddLast(new Employee(3, 20, 5000, "CS"));
            //employees0.AddLast(new Employee(4, 60, 5000, "AI"));
            ////display
            //Console.WriteLine(" All Employees: ");
            //employees0.Display();
            ////Count
            //Console.WriteLine("All Employees  Count: " + employees0.Count());
            ////search
            //Node node_search=employees0.Search(new Employee(4, 20, 5000, "CS"));
            //if (node_search != null) Console.WriteLine("\nFound: ==>" + node_search.data);
            //// Delete  
            //employees0.Delet(3);
            //Console.WriteLine("\nAfter deleting ID 3:");
            //employees0.Display();
            //// Get by index
            //Console.WriteLine("\nEmployee at index 1: ==> " + employees0.GetDataByIndex(1));




            ////10-Bulit in Linkedlist
            //LinkedList<Employee> employees = new LinkedList<Employee>();
            //employees.AddFirst(new Employee(8, 45, 5000, "Sales"));
            //employees.AddLast(new Employee(7, 50, 5000, "Data_Analyse"));
            //foreach (var emp in employees) {
            //    Console.WriteLine("\n"+emp);
            //}
            //var found_node = employees.Find(new Employee(8, 45, 5000, "SC"));
            //if (found_node != null)
            //    Console.WriteLine("\nFound: " + found_node.Value);
            //else
            //    Console.WriteLine("\nEmployee not found");



            //Q-Stack&&Queue
            //1.stack 
            Stack s1=new Stack();
            s1.Push(new Employee(15, 25, 5000, ".net"));
            s1.Push(new Employee(25, 30, 6000, "mearn"));
            s1.Push(new Employee(35, 35, 7000, "ui/ux"));
            ////element 35 -> 25 -> 15
            Console.WriteLine("Stack Pop: ");
            Console.WriteLine(s1.Pop());

            Console.WriteLine("Stack Peek: ");
            Console.WriteLine(s1.Peek());

            Console.WriteLine("Stack IsEmpty: ");
            Console.WriteLine(s1.IsEmpty());

            //1.queue 
            Queue q1 = new Queue();
            q1.Enqueu(new Employee(10, 40, 8000, "Data"));
            q1.Enqueu(new Employee(11, 45, 9000, "Security"));
            q1.Enqueu(new Employee(12, 50, 10000, "Cloud"));

            ////element 10 -> 11 -> 12
            Console.WriteLine("Queue Pop: ");
            Console.WriteLine(q1.Dequeue());

            Console.WriteLine("Queue Peek: ");
            Console.WriteLine(q1.Peek());

            Console.WriteLine("Queue IsEmpty: ");
            Console.WriteLine(q1.isempty());
        }
    }
}
