namespace Lap2AdvancedC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Step1-Task1 - Animals
            Console.WriteLine("-----------------Step1-Task1-------------------------------------------------------");
            Lion lion1 = new Lion();
            lion1.Name = "Simba";
            lion1.Age = 5;
            lion1.Roar();

            Sparrow sparrow1 = new Sparrow();
            sparrow1.Name = "lola";
            sparrow1.Age = 2;
            sparrow1.Fly();
            #endregion

            #region Step2-Task1 - Generic Cage
            Console.WriteLine("-----------------Step2-Task1-------------------------------------------------------------");
            Cage<Lion> cage = new Cage<Lion>();
            Lion lion2 = new Lion();
            lion2.Name = "Simba2";
            lion2.Age = 5;
            cage.Arrive(lion2);

            Lion firstLion = cage.residents[0];
            firstLion.Roar();
            #endregion

            #region Step3-Task1 - Type Safety Demo
            Console.WriteLine("-----------------Step3-Task1-------------------------------------------");

            Cage<Lion> lionCage = new Cage<Lion>();
            Lion lion = new Lion { Name = "Simba", Age = 5 };
            lionCage.Arrive(lion);         // Add Lion
            Sparrow sparrow = new Sparrow { Name = "Lola", Age = 2 };
             // lionCage.Arrive(sparrow);  

             
            #endregion

            #region Grades - Task1
            Console.WriteLine("-----------------Grades-Task1--------------------------------------------------");
            Dictionary<string, List<int>> studentGrades = new Dictionary<string, List<int>>();
            studentGrades["Ali"] = new List<int> { 80, 90, 100 };
            studentGrades["Sara"] = new List<int> { 70, 85 };

            // Add new grade
            string studentName = "Ali";
            int newGrade = 95;
            if (studentGrades.ContainsKey(studentName))
                studentGrades[studentName].Add(newGrade);
            else
                studentGrades[studentName] = new List<int> { newGrade };

            // Display averages
            foreach (var student in studentGrades)
            {
                double average = student.Value.Average();
                Console.WriteLine($"{student.Key} has average: {average}");
            }

            // Top student
            var topStudent = studentGrades.OrderByDescending(s => s.Value.Average()).First();
            Console.WriteLine($"\nTop student is {topStudent.Key} with average {topStudent.Value.Average()}");
            #endregion

            #region Todo List - Task2
            Console.WriteLine("-----------------Todo-Task2------------------------------------------------------------");
            Queue<string> tasks = new Queue<string>();
            //add task
            tasks.Enqueue("Study js");
            tasks.Enqueue("Study css");
            tasks.Enqueue("Study C#");

            Console.WriteLine($"You have {tasks.Count} tasks:");
            foreach (var task in tasks)
                Console.WriteLine(task);

            // Remove a completed task
            string completedTask = "Study C#";
            Queue<string> newQueue = new Queue<string>();
            while (tasks.Count > 0)
            {
                var task = tasks.Dequeue();
                if (task != completedTask)
                    newQueue.Enqueue(task);
            }
            tasks = newQueue;

             
            Console.WriteLine($"You have {tasks.Count} tasks:");
            foreach (var task in tasks)
                Console.WriteLine(task);
            #endregion

            #region Contacts - Task2
            Console.WriteLine("-----------------contact-Task2------------------------------------------------------------");
            Dictionary<string, string> contacts = new Dictionary<string, string>();
            contacts["Ali"] = "01012345678";
            contacts["Sara"] = "01087654321";
            contacts["Mona"] = "01111223344";

            string searchName = "Sara";
            string searchName2 = "amany";

            try
            {
                // First search
                string number = contacts[searchName];
                Console.WriteLine($"Phone number: {number}");
                // Second search
                string number2 = contacts[searchName2];
                Console.WriteLine($"Phone number: {number2}");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Contact not found!");
            }
            #endregion

            #region Browser History - Task2
            Console.WriteLine("-----------------Browser History-Task2--------------------------------------------------");
            Stack<string> browserHistory = new Stack<string>();

            browserHistory.Push("www.google.com");
            browserHistory.Push("www.youtube.com");
            browserHistory.Push("www.github.com");

            // Back Page
            string lastVisited = browserHistory.Pop();
            Console.WriteLine($"Back to: {lastVisited}");

            // All Pages
            Console.WriteLine("\nCurrent browser history:");
            foreach (var page in browserHistory)
                Console.WriteLine(page);
            #endregion

            #region Bouns
            Console.WriteLine("-----------------Bouns--------------------------------------------------");

            Dictionary<string, int> students = new Dictionary<string, int>();

            void AddStudent(string name, int age)
            {
                
                if (students.ContainsValue(age))
                {
                    Console.WriteLine($"Error: Cannot add {name}. Age {age} already exists.");
                    return;
                }

                students[name] = age;
                Console.WriteLine($"{name} added successfully!");
            }

            AddStudent("Ali", 20);
            AddStudent("Sara", 22);
            AddStudent("Mona", 20); // Error
            #endregion
        }
    }
}