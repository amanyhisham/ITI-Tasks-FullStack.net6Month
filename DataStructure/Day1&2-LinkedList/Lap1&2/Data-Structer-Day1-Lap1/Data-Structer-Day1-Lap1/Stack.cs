using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structer_Day1_Lap1
{
    public class Stack : Double_Linked_list
    {
        //1.push
        public void Push(Employee employee) { 
            AddFirst(employee);
        }
        //2- pop
        public Employee Pop()
        {
            if (Head == null) return null;//no element

            Employee emp = Head.data;
            RemoveFirst();
            return emp;
        }
        //3- peek ==>Know first element
        public Employee Peek()
        {
            if (Head == null) return null;

            return Head.data;
        }
        //4- isempty  
        public bool IsEmpty()
        {
            if (Head == null) return true; //empty already
            else return false;
        }
    }
}
