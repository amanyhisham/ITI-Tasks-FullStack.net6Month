using System;
using System.Collections.Generic;
using System.Text;

namespace Lap3_DS_Stack_Queue
{
    public class Stack_Using_Array
    { 
        int size;
        int top;
        int [] stack;
        public Stack_Using_Array(int size)
        {
            this.size = size;
            top = -1;
            stack = new int[size];
        }
        //1.isEmpty
        public bool IsEmpty()
        {
            if (top == -1) return true;
            else return false;


        }
        //2.isFull
        public bool IsFull()
        {
            if (top == size - 1) return true;
            else return false;


        }
        //3.push  
        public void Push(int value) {
            if(IsFull())
            {
                Console.WriteLine("Sorry your stack is full");
                return;
            }
                top++;
                stack[top] = value;
            
        }
        //4.pop  
        public int pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Sorry your stack is already Empty");
                return -1;
            }
            int value = stack[top];
            top--;
            return value;

        }
        //5.Peek  
        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Sorry your stack is already Empty");
                return -1;
            }
            int value = stack[top];
            return value;

        }

         

    }
}
