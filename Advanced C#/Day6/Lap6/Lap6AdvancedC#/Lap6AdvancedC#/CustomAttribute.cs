using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lap6AdvancedC_
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StereoTypeAttribute : Attribute
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public StereoTypeAttribute(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }


    [StereoType("StereoType", "Represents a person in system")]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void SayHello()
        {
            Console.WriteLine("Hello Amany");
        }
    }

    //REflection to read the custom attribute
    public class ReflectionDemo
    {
        public static void ShowAttribute()
        {
            Type type = typeof(Person);

            object[] attributes = type.GetCustomAttributes(false);

            foreach (var attr in attributes)
            {
                if (attr is StereoTypeAttribute stereo)
                {
                    Console.WriteLine("Type: " + stereo.Type);
                    Console.WriteLine("Description: " + stereo.Description);
                }
            }
        }
    }
    //REflection to read the person properties
public class PersonMetadataDemo
    {
        public static void ShowPersonInfo()
        {
            Type type = typeof(Person);

            Console.WriteLine("Class Name: " + type.Name);
            

            Console.WriteLine("\n--- Properties ---");
            foreach (var prop in type.GetProperties()) //
            {
                Console.WriteLine(prop.Name + " : " + prop.PropertyType.Name);
            }

            Console.WriteLine("\n--- Methods ---");
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("\n--- Attributes ---");
            foreach (var attr in type.GetCustomAttributes())
            {
                Console.WriteLine(attr.GetType().Name);
            }
        }
    }


}
