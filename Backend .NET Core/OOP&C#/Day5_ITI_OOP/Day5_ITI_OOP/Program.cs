namespace Day5_ITI_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    #region Dynamic_stack
        //    DynamicStack s1 = new DynamicStack(8);//stack with 8size
        //    //put value with pop funcation
        //    s1.push(10);
        //    s1.push(20);
        //    s1.push(30);
        //    s1.push(40);
        //    s1.push(50);
        //    s1.push(60);
        //    s1.push(70);
        //    s1.push(80);
        //    s1.push(90);
        //    s1.push(100);
        //    //return value
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    Console.WriteLine(s1.pop());
        //    #endregion
        //    #region Dynamic_queue
        //    Queue q1 = new Queue(8);//stack with 8size
        //    //put value with pop funcation
        //    q1.Enqueue(10);
        //    q1.Enqueue(20);
        //    q1.Enqueue(30);
        //    q1.Enqueue(40);
        //    q1.Enqueue(50);
        //    q1.Enqueue(60);
        //    q1.Enqueue(70);
        //    q1.Enqueue(80);
        //    q1.Enqueue(90);
        //    q1.Enqueue(100);
        //    //return value
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());
        //    Console.WriteLine(q1.Dequeue());

        //    #endregion
        //    #region complex

        //    Complex c1 = new Complex(3, 4);
        //    Complex c2 = new Complex(5, 6);
        //    Complex c3 = new Complex();

        //    c3 = c1 + c2;
        //    Console.WriteLine(c3.Print()); //8+10i


        //    c3 = c1 + 10;
        //    Console.WriteLine(c3.Print()); //13+4i

        //    c3 = 9 + c2;
        //    Console.WriteLine(c3.Print()); //14+6i

        //    if (c1 == c2)
        //    {
        //        Console.WriteLine($"Two complex are Equle {c1} == {c2}");

        //    }
        //    else
        //    {
        //        Console.WriteLine($"\"Two complex are not Equle {c1} !== {c2}");
        //    }
        //    if (c1 != c2)
        //    {
        //        Console.WriteLine($"Two complex are  not Equle {c1}!= {c2}");

        //    }
        //    else
        //    {
        //        Console.WriteLine($"{c1} and {c2} are Equel");
        //    }


        //    #endregion
            #region StackConcation
            DynamicStack S1 = new DynamicStack(5);
            DynamicStack S2 = new DynamicStack(5);
            DynamicStack S3 = new DynamicStack();
            S1.push(10);
            S1.push(20);
            S1.push(30);
            S1.push(40);
            S1.push(50);
            S2.push(60);
            S2.push(70);
            S2.push(80);
            S2.push(90);
            S2.push(100);
            S3 = S2 + S1;
            //S3.push(200);
            //S3.push(300);
            //S3.push(400);
            //S3.push(500);
            //S3.push(600);
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
            Console.WriteLine(S3.pop());
           




            #endregion
        }
    }
}
