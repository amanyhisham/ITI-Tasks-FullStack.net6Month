using System;
using System.Collections.Generic;
using System.Text;

namespace Lap4_Ds_Alogrithms
{
    public class Node
    {
        public EmployeeUpdata data;
        public Node prev;
        public Node Next;
        public Node(EmployeeUpdata emp)
        {
            this.data = emp;
            this.prev = null;
            this.Next = null;

        }



    }
}
