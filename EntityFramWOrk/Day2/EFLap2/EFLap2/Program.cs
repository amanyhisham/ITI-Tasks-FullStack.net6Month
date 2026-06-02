using EFLap2;
using Microsoft.EntityFrameworkCore;
using var context = new AppDbContext();

while (true)
{
    Console.WriteLine("\n===== University System =====");
    Console.WriteLine("1- Add Department");
    Console.WriteLine("2- Add Instructor");
    Console.WriteLine("3- Add Student");
    Console.WriteLine("4- Add Course");
    Console.WriteLine("5- Enroll Student in Course");
    Console.WriteLine("6- Show All Students with Details");
    Console.WriteLine("7- Show All Courses with Details");
    Console.WriteLine("8- Show All Departments with Details");
    Console.WriteLine("9- Update Student");
    Console.WriteLine("10- Delete Student");
    Console.WriteLine("0- Exit");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Department Name: ");
        var name = Console.ReadLine();
        var dept = new Department { Name = name };
        context.Departments.Add(dept);
        context.SaveChanges();
        Console.WriteLine(" Department Added! ID = " + dept.Id);
    }
    else if (choice == "2")
    {
        Console.Write("Instructor Name: ");
        var name = Console.ReadLine();
        Console.Write("Salary: ");
        var salary = decimal.Parse(Console.ReadLine());
        Console.Write("Department ID: ");
        var deptId = int.Parse(Console.ReadLine());

        var instructor = new Instructor { Name = name, Salary = salary, DepartmentId = deptId };
        context.Instructors.Add(instructor);
        context.SaveChanges();
        Console.WriteLine(" Instructor Added! ID = " + instructor.Id);
    }
    else if (choice == "3")
    {
        Console.Write("Student Name: ");
        var name = Console.ReadLine();
        Console.Write("Age: ");
        var age = int.Parse(Console.ReadLine());
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Department ID: ");
        var deptId = int.Parse(Console.ReadLine());

        var student = new Student { Name = name, Age = age, Email = email, DepartmentId = deptId };
        context.Students.Add(student);
        context.SaveChanges();
        Console.WriteLine(" Student Added! ID = " + student.Id);
    }
    else if (choice == "4")
    {
        Console.Write("Course Title: ");
        var title = Console.ReadLine();
        Console.Write("Credits: ");
        var credits = int.Parse(Console.ReadLine());
        Console.Write("Instructor ID: ");
        var instId = int.Parse(Console.ReadLine());

        var course = new Course { Title = title, Credits = credits, InstructorId = instId };
        context.Courses.Add(course);
        context.SaveChanges();
        Console.WriteLine(" Course Added! ID = " + course.Id);
    }
    else if (choice == "5")
    {
        Console.Write("Student ID: ");
        var studentId = int.Parse(Console.ReadLine());
        Console.Write("Course ID: ");
        var courseId = int.Parse(Console.ReadLine());
        Console.Write("Grade: ");
        var grade = double.Parse(Console.ReadLine());

        var enrollment = new Enrollment { StudentId = studentId, CourseId = courseId, Grade = grade };
        context.Enrollments.Add(enrollment);
        context.SaveChanges();
        Console.WriteLine(" Student Enrolled!");
    }
    else if (choice == "6")
    {
        // Eager Loading
        var students = context.Students
            .Include(s => s.Department)
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .ToList();

        Console.WriteLine("\n All Students:");
        Console.WriteLine("------------------------------------------");
        foreach (var s in students)
        {
            Console.WriteLine($"Name: {s.Name} | Age: {s.Age} | Dept: {s.Department?.Name}");
            foreach (var e in s.Enrollments)
            {
                Console.WriteLine($"    Course: {e.Course?.Title} | Grade: {e.Grade}");
            }
        }
        Console.WriteLine("------------------------------------------");
    }
    else if (choice == "7")
    {
        // Eager Loading
        var courses = context.Courses
            .Include(c => c.Instructor)
            .Include(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .ToList();

        Console.WriteLine("\n All Courses:");
        Console.WriteLine("------------------------------------------");
        foreach (var c in courses)
        {
            Console.WriteLine($"Course: {c.Title} | Credits: {c.Credits} | Instructor: {c.Instructor?.Name}");
            foreach (var e in c.Enrollments)
            {
                Console.WriteLine($"    Student: {e.Student?.Name} | Grade: {e.Grade}");
            }
        }
        Console.WriteLine("------------------------------------------");
    }
    else if (choice == "8")
    {
        // Eager Loading
        var departments = context.Departments
            .Include(d => d.Students)
            .Include(d => d.HeadInstructor)
            .ToList();

        Console.WriteLine("\n📋 All Departments:");
        Console.WriteLine("------------------------------------------");
        foreach (var d in departments)
        {
            Console.WriteLine($"Department: {d.Name}");
            Console.WriteLine($"    Head: {d.HeadInstructor?.Name ?? "Not Assigned"}");
            Console.WriteLine($"    Students:");
            foreach (var s in d.Students)
            {
                Console.WriteLine($"      - {s.Name}");
            }
        }
        Console.WriteLine("------------------------------------------");
    }
    else if (choice == "9")
    {
        Console.Write("Enter Student ID to Update: ");
        var id = int.Parse(Console.ReadLine());

        var student = context.Students.Find(id);
        if (student == null)
        {
            Console.WriteLine(" Student Not Found!");
        }
        else
        {
            Console.Write($"New Name ({student.Name}): ");
            var name = Console.ReadLine();
            Console.Write($"New Age ({student.Age}): ");
            var age = int.Parse(Console.ReadLine());
            Console.Write($"New Email ({student.Email}): ");
            var email = Console.ReadLine();

            student.Name = name;
            student.Age = age;
            student.Email = email;
            context.SaveChanges();
            Console.WriteLine(" Student Updated!");
        }
    }
    else if (choice == "10")
    {
        Console.Write("Enter Student ID to Delete: ");
        var id = int.Parse(Console.ReadLine());

        var student = context.Students.Find(id);
        if (student == null)
        {
            Console.WriteLine(" Student Not Found!");
        }
        else
        {
            Console.Write($"Are you sure you want to delete {student.Name}? (y/n): ");
            var confirm = Console.ReadLine();
            if (confirm == "y")
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine(" Student Deleted!");
            }
            else
            {
                Console.WriteLine("Cancelled!");
            }
        }
    }
}