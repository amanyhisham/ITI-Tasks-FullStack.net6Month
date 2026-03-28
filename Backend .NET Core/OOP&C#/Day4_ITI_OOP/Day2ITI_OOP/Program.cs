namespace Day2ITI_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {  ///1.ctor on complex & static counter on complex
            Complex c1 = new Complex();//defult
            Complex c2 = new Complex(6, 8);//2paramter
            Complex c3 = new Complex(5);//one
            Console.WriteLine(c1.Print());
            Console.WriteLine(c2.Print());
            Console.WriteLine(c3.Print());
            Console.WriteLine(Complex.Getcounter());

            ///2-Composition line,rect
            ///2.1 line
            Line l1 = new Line();
            Console.WriteLine(l1.PrintLine());
            //2.2 rectangle

            Rectangle r1 = new Rectangle(1,2,3,5);
            Console.WriteLine(r1.PrintRect());

            ///3.aggregation circle,regtangle
            ///3.1 regtangle
            Tringle t1 = new Tringle();
            //create 3 point not related
            Point pnt1 = new Point(3, 4);
            Point pnt2 = new Point(5, 6);
            Point pnt3 = new Point(7, 8);
            //set value to tringle(assiacation)
            t1.SetP1(pnt1);
            t1.SetP2(pnt2);
            t1.SetP3(pnt3);
            //print
            Console.WriteLine(t1.PrintTringle());

            ////3.2cicle
            Circle circle = new Circle();
            Point pnt = new Point(3, 4);
            circle.SetP1(pnt);
            circle.SetR2(5);
            Console.WriteLine(circle.PrintCricle());





        }
    }
}
