using System.Linq.Expressions;

namespace Lap3_DS_Stack_Queue
{
     class Program
    {
        public static bool isBalance(String expression)
        {
            Stack<char> stackBalance = new Stack<char>();
            foreach (char c in expression)
            {
                if (c == '(')
                {
                    stackBalance.Push(c);
                }
                else if (c == ')')
                {
                    if (stackBalance.Count > 0)
                    {
                        stackBalance.Pop();
                    }
                    else if (stackBalance.Count == 0)
                    {
                        return false;
                    }
                }

            }
            if (stackBalance.Count > 0) return false;
            else return true;
        }
        static void Main(string[] args)
        {
            //1.task1
            Console.WriteLine("----------------------Task1 Stack usingArray------------------------");
            Console.WriteLine("This task Stack using array");
            //5->4->3->2->1
            Stack_Using_Array s1 = new Stack_Using_Array(5);
            Console.WriteLine(s1.IsEmpty()); // True
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);
            s1.Push(4);
            s1.Push(5);
            Console.WriteLine(s1.IsFull()); // True
            Console.WriteLine(s1.IsEmpty()); // False
            Console.WriteLine(s1.Peek()); // 5
            Console.WriteLine(s1.pop()); // 5
            Console.WriteLine(s1.pop()); // 4

            //2.task2
            Console.WriteLine("----------------------Task2 Queue usingArray------------------------");
            Console.WriteLine("This task queue using array");
            // 10->20->30->40->50
            Queue_using_Array q1= new Queue_using_Array(5);
            Console.WriteLine(q1.IsEmpty());//true
            q1.Enqueue(10);
            q1.Enqueue(20);
            q1.Enqueue(30);
            Console.WriteLine(q1.IsEmpty());//false
            q1.Enqueue(40);
            q1.Enqueue(50);
            Console.WriteLine(q1.IsFull());//True
            Console.WriteLine(q1.Front());//10
            Console.WriteLine(q1.Dequeue());//10
            Console.WriteLine(q1.Dequeue());//20

            //3.task3(Reverse)
            Console.WriteLine("----------------------Task3 Reverse------------------------");
            Console.WriteLine("Enter Your Word Want Reverse : ");
            string input= Console.ReadLine();
            Stack<char> charStack=new Stack<char>();
            foreach(char c in input)
            {
                charStack.Push(c);
            }
            while(charStack.Count > 0)
            {
                Console.Write(charStack.Pop());
            }

            //4.task4(Balance)
            Console.WriteLine("----------------------Task4 Balance------------------------");
            Console.WriteLine("Enter Your Expression want chack Balance or no : ");
            string input2 = Console.ReadLine();
            bool res = isBalance(input2);
            if (res == true) { Console.WriteLine("IsBalance expression"); }
            else { Console.WriteLine("NotBalance expression"); }

            //5.Bonus(Queue using Two Stacks)
            Console.WriteLine("----------------------Task5 Bouns------------------------");
            QueueUsingTwoStacks queue = new QueueUsingTwoStacks();
            Console.WriteLine(queue.IsEmpty());//true
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            Console.WriteLine(queue.IsEmpty());//false
            Console.WriteLine(queue.Front());//10
            Console.WriteLine(queue.Dequeue());//10
            Console.WriteLine(queue.Dequeue());//20
            Console.WriteLine(queue.Front());//30









        }
    }
}
