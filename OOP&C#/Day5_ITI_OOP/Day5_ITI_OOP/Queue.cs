using System;
using System.Collections.Generic;
using System.Text;

namespace Day5_ITI_OOP
{
     class Queue
    {//data 0.1
        int[] arr;
        int size;
        int front;
        int rear;
    //cotrs 0.3
    public Queue()
        {
            size = 5;
            arr = new int[size];
            front = 0;
            rear = 0;
        }
        public Queue(int _size)
        {
            size = _size;
            arr = new int[size];
            front = 0;
            rear = 0;
        }
    //push element == Enqueue
    public void Enqueue(int value)
        {
            if (rear < size)//still have place
            {
                arr[rear] = value;
                rear++;
            }
            else
            {
                Console.WriteLine("Queue is Full");

            }
        }
    //pop element == Dequeue
    public int Dequeue()
        {
             if (front < rear)
            {
                 int value= arr[front];
                front++;
                 return value;
            }
            else
            {
                Console.WriteLine("Queue is EMPTY");
                return -1;
            }
        }
    }
}
