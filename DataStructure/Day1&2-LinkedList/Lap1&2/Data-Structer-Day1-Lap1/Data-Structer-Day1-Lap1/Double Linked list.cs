using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Data_Structer_Day1_Lap1
{
    public class Double_Linked_list
    {
        public Node Head;
        public Node Tail;
         public Double_Linked_list()
        {
            Head = null;
            Tail = null;
         }
        //1-AddLast  ==Insertlast ==============>  has complixity o(1)
        public void AddLast(Employee emp_Data)
        {
            Node nd = new Node(emp_Data);
            if (nd != null)// has data
            {
                if(Head==null)//no-list
                {
                    Head = Tail = nd;
                }
                else
                {
                    Tail.Next = nd;
                    nd.prev = Tail;
                    Tail = nd;
                }
             }
        }
        //2-AddFirst   ==============> has complixity o(1)
        public void AddFirst(Employee emp_Data)
        {
            Node nd = new Node(emp_Data);
            if (nd != null)// has data
            {
                if (Head == null)//no-list
                {
                    Head = Tail = nd;
                }
                else
                {
                    nd.Next = Head;
                    Head.prev = nd;
                    Head = nd;
                }
             }
        }
        //3-Display Employee =======================>time o(n)
        public void Display()
        {
            Node nd = Head;
            while (nd != null)
            {
                Console.WriteLine(nd.data);
                nd = nd.Next;
            }
        }
        //4- Count========================> O(n)
        public int Count()
        {
            int count = 0;
            Node nd = Head;
            while (nd != null) {
                count++;
                nd = nd.Next;
            }
            return count;
        }
        //5- Search========================> O(n)
        public Node Search(Employee emp) { 
            Node nd = Head;
              while (nd != null) {
                    if (nd.data.ID== emp.ID) return nd;
                    else  nd = nd.Next; 

                    
               }
                return null;
        }
        //6- RemoveFirst========================> O(1)
        public void RemoveFirst() {
            if (Head == null) return;//no list
            else if (Head != null)
            {
                if(Head==Tail) Head = Tail = null;//1 node
                else
                {
                    Head = Head.Next;
                    Head.prev = null;
                  }

            }
        }

   //7- RemoveLast========================> O(1)
        public void RemoveLast()
        {
            if (Tail == null) return; 
            else if (Tail != null)
            {
                if (Head == Tail) Head = Tail = null;//1 node
                else
                {
                    Tail = Tail.prev;
                    Tail.Next = null;
                 }

            }
        }
        // 8- Delet base Id========================> O(n)
        public void Delet(int Id)
        {
            Node nd = Head;
            while (nd != null) {
                if (nd.data.ID == Id) {
                    if (Head == nd) RemoveFirst();
                    else if (Tail == nd) RemoveLast();
                    else
                    {
                        nd.prev.Next = nd.Next;
                        nd.Next.prev = nd.prev; 
                         
                    }
                    return;
                    
                }
                nd = nd.Next;
            }
        }
        // 9- Get Data by Index========================> O(n)
        public Employee GetDataByIndex(int index)
        {
            if (index < 0 || index > Count()) return null;
            else
            {
                Node nd = Head;

                for (int i = 0; i < index; i++)
                {
                     
                    nd = nd.Next;
                }
                return nd.data;
            }
        }
    }
}
