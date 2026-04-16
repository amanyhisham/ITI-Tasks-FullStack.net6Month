
using System.Text;//stringBulider
namespace Lap6AdvancedC_
 {
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Predefined attribute
            Console.WriteLine("----------------------------------------task1---------------------------------------------");
            
            // Flags Example
            Console.WriteLine("---Flags Example---");
            TextStyling style = TextStyling.Bold | TextStyling.Italic;
            Console.WriteLine(style);
            TextStyling2 style2 = TextStyling2.Bold | TextStyling2.Italic;
            Console.WriteLine(style2);//without flags


            // Obsolete Example
            Console.WriteLine("---Obsolete Example----");
            AttributeDemo obj = new AttributeDemo();
            obj.OldMethod(); // Warning
            //obj.VeryOldMethod();//error
            obj.NewMethod(); // No warning



            #endregion
            #region custom attribute
            Console.WriteLine("----------------------------------------task2---------------------------------------------");
            ReflectionDemo.ShowAttribute();
            #endregion
            #region PermitiveAttribute
            Console.WriteLine("----------------------------Task3----------------------------------------------------------");
            primitiveAttribute.ShowPrimitiveMetadata();

            #endregion
            #region PersonMetadata
            Console.WriteLine("----------------------------------------task4---------------------------------------------");
            PersonMetadataDemo.ShowPersonInfo();
            #endregion
            #region classStudent
            Console.WriteLine("------------------------------------task5---------------------------------------------");
            RuntimeTask.Run();
            #endregion
            #region stringBuilder
            // Create StringBuilder object
            StringBuilder sb = new StringBuilder();

            // 1) Add "Hello"
            sb.Append("Hello");//hello
            sb.AppendLine(" Students");//hello student

            sb.Insert(5, " Amazing ");//hello amazing student

            sb.Replace("Students", "Amany");//hello amazing amany

            sb.Remove(5, 9);//hello amany

            
            Console.WriteLine(sb.ToString());
            #endregion
            #region exception
            Console.WriteLine("------------------------------------task6---------------------------------------------");
            StudentService service = new StudentService();

            try
            {
                service.CheckAge(15);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            #endregion
            #region static constructor
            Console.WriteLine("------------------------------------task7---------------------------------------------");

            Test.Show();

            #endregion
        }
    }
}
