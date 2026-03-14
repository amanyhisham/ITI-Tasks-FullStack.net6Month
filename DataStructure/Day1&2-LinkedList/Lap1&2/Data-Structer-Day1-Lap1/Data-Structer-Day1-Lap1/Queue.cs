using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structer_Day1_Lap1
{
    public class Queue : Double_Linked_list
    {
        //1-EnQueue
        public void Enqueu(Employee employee)
        {
            AddLast(employee);
        }
        //2-DeQueue
        public Employee Dequeue()
        {
            if (Head == null) return null;//no element

            Employee emp = Head.data;
            RemoveFirst();
            return emp;
        }
        //3-Peek
        public Employee Peek()
        {
            if (Head == null) return null;//no element

            return Head.data;
        }
        //4- is empty
        public bool isempty()
        {
            if (Head == null) return true;
            return false;
        }
    }
}
