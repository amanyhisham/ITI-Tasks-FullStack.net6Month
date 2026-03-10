using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structer_Day1_Lap1
{
    public class Node
    {
        public Employee data;
        public Node prev;
        public Node Next;
        public Node(Employee emp) {
            this.data = emp;
            this.prev = null;
            this.Next = null;

        }



    }
}
