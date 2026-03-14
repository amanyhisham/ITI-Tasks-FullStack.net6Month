using System;
using System.Collections.Generic;
using System.Text;

namespace Lap3_DS_Stack_Queue
{
    public class Queue_using_Array
    {
        int size;
        int[] queue;
        int front;
        int back;
        public Queue_using_Array(int size)
        {
            this.size = size;
            queue=new int[size];
            front = -1;
            back = -1;
        }
        //1.isempty
        public bool IsEmpty()
        {
            if (front == -1) return true;
            else return false;
        }
        //2.Isfull
        public bool IsFull()
        {
            if (back == size-1) return true;
            else return false;
        }
        //3.enqueue
        public void Enqueue(int val)
        {
            if (IsFull())
            {
                Console.WriteLine("Sorry queue is full");
                return;
            }
           if(IsEmpty())
            {
                front = 0;
            }
            back++;
            queue[back] = val;
        }
        //4.Dequeue
        public int Dequeue()
        {
             
            if (IsEmpty())
            {
                Console.WriteLine("Sorry queue is Empty");
                return -1;
            }
            int value = queue[front];
               front++;
            return value;
            if (front > back)
            {
                front = -1;
                back=-1;
            }
         }
        //5.front
        public int Front()
        {

            if (IsEmpty())
            {
                Console.WriteLine("Sorry queue is Empty");
                return -1;
            }
            return queue[front];
        }


    }
}
