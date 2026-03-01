using System;
using System.Collections.Generic;
using System.Text;

namespace Day5_ITI_OOP
{
    class DynamicStack
    {//Data 0.1
        int[] arr;
        int size;
        int tops;
        //setter&getter -> useless (pop& push)
        //cots 0.3
        public DynamicStack()
        {
            size = 5;
            tops = 0;
            arr = new int[size];
        }
        public DynamicStack(int _size)
        {
            size = _size;
            tops = 0;
            arr = new int[size];
        }
        //funcation push
        public void push(int value)
        {
            if (tops != size)//empty
            {
                arr[tops] = value;
                tops++;
            }
            else
            {
                Console.WriteLine("FULL!!!");

            }
        }
        //funcation pop == print
        public int pop()
        {
            int res = -1;
            if (tops != 0)//full
            {
                tops--;
                res = arr[tops];
                return res;

            }
            else
            {
                Console.WriteLine("EMPTY!!!");
                return -1;

            }
        }
        //opertor+ at stack
        public static DynamicStack operator +(DynamicStack s1, DynamicStack s2)
        {
            int newSize = s1.size + s2.size;
            DynamicStack result = new DynamicStack(newSize);

            for (int i = 0; i < s2.tops; i++)
            {
                result.push(s2.arr[i]);

            }
            for (int i=0;i<s1.tops;i++)
            {
                result.push(s1.arr[i]);

            }
            

            return result;


        }





    }
}
