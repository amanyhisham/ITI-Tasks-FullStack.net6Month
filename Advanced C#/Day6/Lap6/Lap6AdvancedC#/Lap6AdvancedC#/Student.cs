using System;
using System.Collections.Generic;
using System.Text;

namespace Lap6AdvancedC_
{
    public class Student
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public Grade Grade { get; set; }
        public string Address { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} - {Age} - {Grade} - {Address}");
        }
    }
    public enum Grade
    {
        A, B, C, D
    }



     
public class RuntimeTask
    {
        public static void Run()
        {
             
            Type type = typeof(Student);

             
            object obj = Activator.CreateInstance(type);
 
            type.GetProperty("Name").SetValue(obj, "Amany");
            type.GetProperty("Age").SetValue(obj, 22);
            type.GetProperty("Grade").SetValue(obj, Grade.A);
            type.GetProperty("Address").SetValue(obj, "Cairo");

           
            type.GetMethod("Print").Invoke(obj, null);
        }
    }
}
