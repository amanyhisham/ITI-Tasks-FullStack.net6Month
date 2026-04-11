namespace Day6_ITI_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            //squara
            Squara s1 =new Squara(5);
            Console.WriteLine(s1.Area());
            s1.setdim1(10);
            s1.setdim1(20);
            Console.WriteLine(s1.Area());

            //Rectangle
            Rectangle r1 = new Rectangle(2, 5);
            Console.WriteLine(r1.Area());

            //Triangle
            Triangle t1 = new Triangle(2, 5);
            Console.WriteLine(t1.Area());

            //cricle
            Circle c1 = new Circle(2);
            Console.WriteLine(c1.Area());
            c1.setreduisc(5);
            Console.WriteLine(c1.Area());

            ///Track for summation
            Rectangle[] rectangles = new Rectangle[2]
            {
                new Rectangle(2,5),
                new Rectangle(3,4)
             };
            Squara[] squares = new Squara[2]
            {
                new Squara(10),
                new Squara(10)
            };
            Triangle[] triangles =new Triangle[2]
            {
                new Triangle(2,5),
                new Triangle(2,5)
            };

            Circle[] circles = new Circle[2]
                { 
                new Circle(3),
                new Circle(4)
            };
            Console.WriteLine(SummationOfArea.sumOFAllAreasV1(rectangles, squares, triangles, circles));

            GeoShap[] GeoShaps = 
            {
               new Rectangle(2,5),
                new Rectangle(3,4),
                 new Squara(10),
                new Squara(10),
                 new Triangle(2,5),
                new Triangle(2,5),
                 new Circle(3),
                new Circle(4)

            };
            Console.WriteLine(SummationOfArea.sumOFAllAreasV2(GeoShaps));

        }
    }
}
