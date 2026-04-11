
namespace Lap1Advanced_C_
{
    interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    interface IColor
    {
        string GetColor();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------Task1------------------------");
            PhoneBook pb = new PhoneBook();
            pb[123] = "Amany";
            pb["Ali"] = 456;
            Console.WriteLine(pb[123]);    // Amany
            Console.WriteLine(pb["Ali"]);  // 456
            Console.WriteLine("-------------------------------------Task1------------------------");
            Person p = new Person();
            p.FirstName = "Amany";
            p.LastName = "Hisham";
            //p.FullName="amayhesham"--------->error
            Console.WriteLine(p.FullName); // Amany Hisham
            p.Age = 22;
            Console.WriteLine(p.Age);      // 22
            p.Password = "secret"; //ReadOnly
             //Console.WriteLine(p.Password); ------------>error
            Console.WriteLine("-------------------------------------Task3------------------------");
            Rectangle rect = new Rectangle(4, 5, "Red");
            Console.WriteLine("Rectangle-----------");
            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.GetColor());
            Console.WriteLine("Square-----------");
            Square sq = new Square(3, "Blue");
            Console.WriteLine(sq.CalculateArea());
            Console.WriteLine(sq.CalculatePerimeter());
            Console.WriteLine(sq.GetColor());
            Console.WriteLine("Circle-----------");
            Circle c = new Circle(2, "Green");
            Console.WriteLine(c.CalculateArea());
            Console.WriteLine(c.CalculatePerimeter());
            Console.WriteLine(c.GetColor());

        }
    }
}
