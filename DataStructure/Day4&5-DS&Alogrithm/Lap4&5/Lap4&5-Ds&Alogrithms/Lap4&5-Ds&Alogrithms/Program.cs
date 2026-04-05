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
        //selection  -->o(n)2
        public static void SelectionSort(EmployeeUpdata[] emp)
        {
            int n = emp.Length;

            for (int i = 0; i < n - 1; i++)//
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (emp[j].CompareTo(emp[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                
                EmployeeUpdata temp = emp[i];
                emp[i] = emp[minIndex];
                emp[minIndex] = temp;
            }
        }
        //marge sort -----O(n log n)
        public static void MergeSort(EmployeeUpdata[] arr, int left, int right)
        {
            // base case
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);//- 3 0 6 5 4 2 1 9

            
            Merge(arr, left, mid, right);
        }
        public static void Merge(EmployeeUpdata[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            EmployeeUpdata[] L = new EmployeeUpdata[n1];
            EmployeeUpdata[] R = new EmployeeUpdata[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];

            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (L[iIndex].CompareTo(R[jIndex]) <= 0)
                {
                    arr[k++] = L[iIndex++];
                }
                else
                {
                    arr[k++] = R[jIndex++];
                }
            }

            while (iIndex < n1)
                arr[k++] = L[iIndex++];

            while (jIndex < n2)
                arr[k++] = R[jIndex++];
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
            Console.WriteLine("----------------------------Lap5-part1 :Selection Sort:---------------");
            EmployeeUpdata[] newEmp = new EmployeeUpdata[]
                   {
                    new EmployeeUpdata(22, 4000, "IT", new DateTime(2024, 1, 1)),
                    new EmployeeUpdata(35, 9000, "HR", new DateTime(2019, 6, 1)),
                    new EmployeeUpdata(28, 6000, "Sales", new DateTime(2021, 3, 1)),
                    new EmployeeUpdata(30, 7000, "Finance", new DateTime(2018, 8, 1))
                     };
            Console.WriteLine("Before Selection Sort:");
            foreach (var e in newEmp)
             Console.WriteLine(e);
            SelectionSort(newEmp);
            Console.WriteLine("\nAfter Selection Sort:");
            foreach (var e in newEmp)
             Console.WriteLine(e);
            Console.WriteLine("----------------------------Lap5-part2 :Marge Sort:---------------");
            EmployeeUpdata[] newEmp2 = new EmployeeUpdata[]
                  {
                    new EmployeeUpdata(22, 4000, "IT", new DateTime(2024, 1, 1)),
                    new EmployeeUpdata(35, 9000, "HR", new DateTime(2019, 6, 1)),
                    new EmployeeUpdata(28, 6000, "Sales", new DateTime(2021, 3, 1)),
                    new EmployeeUpdata(30, 7000, "Finance", new DateTime(2018, 8, 1))
                    };
            Console.WriteLine("Before Merge Sort:");
            foreach (var e in newEmp2)
                Console.WriteLine(e);

            MergeSort(newEmp2, 0, newEmp2.Length - 1);

            Console.WriteLine("\nAfter Merge Sort:");
            foreach (var e in newEmp2)
                Console.WriteLine(e);




      }
    }
}
