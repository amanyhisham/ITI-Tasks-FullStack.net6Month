using Day1Linq;
using System.Linq;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //query1->sort and distinct
            Console.WriteLine("-----------------------------Query1------------------------------------------");
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var query = numbers.Distinct().OrderBy(x => x).ToList();
            foreach (int x in query)
            {
                Console.WriteLine(x);
            }
            //query2->Multiply 
            Console.WriteLine("-----------------------------Query2------------------------------------------");
            var query2 = query.Select(n=>new
            {
                Number = n,
                Multiply = n * n
            });
            foreach (var x in query2)
            {
                Console.WriteLine($"Number = {x.Number} Multiply = {x.Multiply}");
             }
            //query3->filter
            Console.WriteLine("-----------------------------Query3------------------------------------------");
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            var query3=names.Where(n => n.Length == 3);
            foreach (string x in query3)
            {
                Console.WriteLine(x);
            }
            //query4->filter2
            Console.WriteLine("-----------------------------Query4------------------------------------------");
            var query4 = names.Where(n => n.Contains("a" )||n.Contains("A")).OrderBy(n => n.Length);
            foreach (string x in query4)
            {
                Console.WriteLine(x);
            }
            //query5->filter3
            Console.WriteLine("-----------------------------Query5------------------------------------------");
            var query5 = names.Take(2);
            foreach (string x in query5)
            {
                Console.WriteLine(x);
            }
            //query6->class Getnam fullname
             Console.WriteLine("-----------------------------Query6------------------------------------------");
            List<Student> students = new List<Student>()
             {
    new Student()
    {
        ID = 1,
        FirstName = "Ali",
        LastName = "Mohammed",

        subjects = new Subject[]
        {
            new Subject(){ Code = 22 , Name = "EF"},
            new Subject(){ Code = 33 , Name = "UML"}
        }
    },

    new Student()
    {
        ID = 2,
        FirstName = "Mona",
        LastName = "Gala",

        subjects = new Subject[]
        {
            new Subject(){ Code = 22 , Name = "EF"},
            new Subject(){ Code = 34 , Name = "XML"},
            new Subject(){ Code = 25 , Name = "JS"}
        }
    },

    new Student()
    {
        ID = 3,
        FirstName = "Yara",
        LastName = "Yousf",

        subjects = new Subject[]
        {
            new Subject(){ Code = 22 , Name = "EF"},
            new Subject(){ Code = 25 , Name = "JS"}
        }
    },
     new Student(){ ID=4, FirstName="Ali", LastName="Ali",
        subjects=new Subject[]{ new Subject(){ Code=33,Name="UML"}}}
};
            var query6 = students.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                NoSubject =s.subjects.Count()
            });
            foreach (var student in query6)
            {
                Console.WriteLine($"Student: {student.FullName}, Number of Subjects: {student.NoSubject}");
            }
            //query7->Orderby
            Console.WriteLine("-----------------------------Query7------------------------------------------");
            var query7= students.OrderByDescending(s=>s.FirstName).ThenBy(s=>s.LastName).Select(s=>s.FirstName+" "+s.LastName);
            foreach(var student in query7)
            {
                Console.WriteLine(student);
            }
            //query8->selectmany
            Console.WriteLine("-----------------------------Query8------------------------------------------");
            var query8 = students.SelectMany(s => s.subjects, (s, sub) => new
            {
                StudentName = s.FirstName + " " + s.LastName,
                SubjectName = sub.Name
            }
            );
            foreach (var student in query8)
            {
                Console.WriteLine($"StudentName = {student.StudentName}, SubjectName = {student.SubjectName} ");
            }
            //query9-BONUS — GroupBy
            Console.WriteLine("-----------------------------Query9------------------------------------------");
            var query9 = students.GroupBy(s => s.FirstName + " " + s.LastName);
            foreach (var Group  in query9)
            {
                Console.WriteLine($"{Group.Key}");

                foreach (var student in Group)
                {
                    foreach(var subject in student.subjects)
                    {
                        Console.WriteLine("   " + subject.Name);
                    }

                }


            }



        }

    }
}