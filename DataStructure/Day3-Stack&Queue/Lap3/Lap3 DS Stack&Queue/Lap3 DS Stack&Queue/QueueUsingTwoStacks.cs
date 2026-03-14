using System;
using System.Collections.Generic;
using System.Text;

namespace Lap3_DS_Stack_Queue
{
    public class QueueUsingTwoStacks
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();
        public QueueUsingTwoStacks()
        {
            this.stack1 = new Stack<int>();
            this.stack2 = new Stack<int>();
        }
        //1.Enqueue
        public void Enqueue(int value)
        {
            this.stack1.Push(value);
        }
        //2.IsEmpty
        public bool IsEmpty()
        {
            if (stack1.Count == 0 && stack2.Count == 0) return true;
            return false;

        }
        //3.Dequeue
        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }

            }

            return stack2.Pop();



        }
        //4.Front
        public int Front()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }

            }

            return stack2.Peek();



        }

    }
}
