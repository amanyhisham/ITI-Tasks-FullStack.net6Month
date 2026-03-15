namespace Lap4_Ds_Alogrithms
{
    internal class Program

    {//Bubble sort
        public static void BubbleSort(EmployeeUpdata[] emp)
        {
            int size=emp.Length;
             for(int i = 0; i < size - 1; i++)
            {
                for(int j = 0; j < size - i - 1; j++)
                {
                    if (emp[j].CompareTo(emp[j+1]) > 0)
                    {
                        EmployeeUpdata temp  ;
                        temp = emp[j];
                        emp[j] = emp[j+1];
                        emp[j + 1] = temp;

                    }
                }
            }

        }
        //BinerySearch Iterative
        public static int BinarySearchIterative(EmployeeUpdata[] emp, EmployeeUpdata Element) {
            int left = 0;
            int right = emp.Length - 1;
            while (left <= right) {
                int mid = (left + right) / 2;
                int res = emp[mid].CompareTo(Element);
                if (res == 0) return mid;
                else if (res < 0) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        
        }
        //BinerySearch Recursive
        public static int BinarySearchRecursive(EmployeeUpdata[] emp, EmployeeUpdata Element,int left,int right)
        {
            if (left > right) return -1;//base 
            int mid = (left + right) / 2;
            int res = emp[mid].CompareTo(Element);
            if (res == 0) return mid;
            else if (res < 0) return BinarySearchRecursive( emp,   Element,   mid + 1,  right);
            else return BinarySearchRecursive(emp, Element, left, mid - 1);

        }


        static void Main(string[] args)
        {
            //1.Task1(Comarable)
            Console.WriteLine("--------------Task1---Comarable--------------------------");
            EmployeeUpdata emp1=new EmployeeUpdata(25, 5000, "IT", new DateTime(2020, 5, 1));
            EmployeeUpdata emp2 = new EmployeeUpdata(30, 7000, "HR", new DateTime(2023, 3, 1));
            EmployeeUpdata emp3 = new EmployeeUpdata(28, 6000, "Sales", new DateTime(2020, 5, 1));
            Console.WriteLine(emp1.CompareTo(emp2));//-1
            Console.WriteLine(emp2.CompareTo(emp1));//1
            Console.WriteLine(emp1.CompareTo(emp3));//0
            Console.WriteLine("--------------Task2---Bubblesort----------------------------");
            EmployeeUpdata[] emp = new EmployeeUpdata[]
            {new EmployeeUpdata(25, 5000, "IT", new DateTime(2020, 5, 1)),//1
            new EmployeeUpdata(30, 7000, "HR", new DateTime(2023, 3, 1)),//2
            new EmployeeUpdata(28, 6000, "Sales", new DateTime(2020, 1, 1)),//0
             };
            Console.WriteLine("Employee Before Bubble sort: ");
            foreach(var E in emp) { Console.WriteLine(E.ToString()); }
            BubbleSort(emp);//
            Console.WriteLine();
            Console.WriteLine("Employee After Bubble sort: ");
            foreach (var E in emp) { Console.WriteLine(E.ToString()); }
            Console.WriteLine("--------------Task3---BinarySearch----------------------------");
            EmployeeUpdata empsearch = new EmployeeUpdata(30, 7000, "HR", new DateTime(2023, 3, 1));
            Console.WriteLine("BinarySeachIterative : "+ BinarySearchIterative(emp, empsearch));//2
            Console.WriteLine("BinarySeachRecursive : " + BinarySearchRecursive(emp, empsearch, 0, emp.Length - 1));//2
            Console.WriteLine("--------------Task4---UpdataLinkedlist----------------------------");
            DoubleLinkedlist list = new DoubleLinkedlist();

            EmployeeUpdata e1 = new EmployeeUpdata(25, 5000, "IT", new DateTime(2020, 5, 1));
            EmployeeUpdata e2 = new EmployeeUpdata(30, 7000, "HR", new DateTime(2023, 3, 1));
            EmployeeUpdata e3 = new EmployeeUpdata(28, 6000, "Sales", new DateTime(2020, 1, 1));

            list.AddSorted(e1);
            list.AddSorted(e2);
            list.AddSorted(e3);

            list.Display();







        }
    }
}
