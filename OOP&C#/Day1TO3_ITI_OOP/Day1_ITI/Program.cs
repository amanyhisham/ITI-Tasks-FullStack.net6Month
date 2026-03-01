namespace Day1_ITI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day1
            /*Console.WriteLine("Please Enter your year birthday: ");
            int year= int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter your month birthday: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter your day birthday : ");
            int day = int.Parse(Console.ReadLine());
            int currentday = DateTime.Now.Day;
            int currentmonth = DateTime.Now.Month;
            int currentyear = DateTime.Now.Year;
               int current = (currentday) + (currentmonth * 30) + (currentyear * 365);
               int birthTotalDays = day + (month * 30) + (year * 365);//your
               int ageInDays = current - birthTotalDays;
               int age = ageInDays / 365;
               Console.WriteLine("Your age is : " + age + " years");*/
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>//

            //Day2
            //assiment1:
            /////1- array of 10 intergers and get min and max value   |5|4|2|-1|-33|55|66|77|88|100|
            int[] arr = new int[10];
             for (int i = 0; i < arr.Length; i++)
             {
                 Console.WriteLine(" Enter value of index array  " + i);
                 arr[i] = int.Parse(Console.ReadLine());
             }
             int min = arr[0];
             int max = arr[0];
             for (int i = 0; i < arr.Length; i++)
             {
                 if (min > arr[i])
                 {
                     min = arr[i];
                 }
                 if ((max < arr[i]))
                 {
                     max = arr[i];
                 }
             }
             Console.WriteLine("the max number : " + max + " and the min num is : " + min);
             //Console.WriteLine();
             //////2- array of 10 integers and sort it ascending without any built in function
            int temp;
            for (int i = 0; i < (arr.Length) - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

            }
            Console.WriteLine("sorted array is : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            //////3- array of 10 integers and search number and get index
            char c;
            do
            {
                Console.WriteLine("Please Enter Search Number");
                int numsearch = int.Parse(Console.ReadLine());
                bool flag = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (numsearch == arr[i])
                    {
                        Console.WriteLine("found at index: " + i);
                        flag = true;
                        break;

                    }

                }
                if (flag != true)
                {


                    Console.WriteLine("Not Found");

                }
                do
                {
                    Console.WriteLine("Do you want search again y/n?");
                    c = char.Parse(Console.ReadLine());
                } while (!"yYnN".Contains(c));
            } while (c == 'Y' || c == 'y');
            Console.WriteLine("you stop search  .. ");
            ////4- array of 3 rows,4 cols read and write  
            int[,] arrs = new int[3, 4];
            for (int i = 0; i < arrs.GetLength(0); i++)
            {
                for (int g = 0; g < arrs.GetLength(1); g++)
                {
                    Console.Write($"Enter value for arrs[{i},{g}]: ");
                    arrs[i, g] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < arrs.GetLength(0); i++)
            {
                for (int g = 0; g < arrs.GetLength(1); g++)
                {
                    Console.Write(arrs[i, g] + " ");
                }
                Console.WriteLine();
            }
            // 5 - calculate your birth date + validation

            int yearbirht, monthbirth, daybirth;
            do
            {
                Console.WriteLine("Please Enter your year birthday: ");
                yearbirht = int.Parse(Console.ReadLine());
            } while (!(yearbirht >= 1980 && yearbirht <= 2025));
            do
            {
                Console.WriteLine("Please Enter your month birthday: ");
                monthbirth = int.Parse(Console.ReadLine());
            } while (!(monthbirth >= 1 && monthbirth <= 12));
            int maxDay;

            if (monthbirth == 1 || monthbirth == 3 || monthbirth == 5 ||
                monthbirth == 7 || monthbirth == 8 || monthbirth == 10 || monthbirth == 12)
            {
                maxDay = 31;
            }
            else if (monthbirth == 4 || monthbirth == 6 || monthbirth == 9 || monthbirth == 11)
            {
                maxDay = 30;
            }
            else // monthbirth == 2
            {
                 //leapyear
                if ((yearbirht % 4 == 0 && yearbirht % 100 != 0) || yearbirht % 400 == 0)
                    maxDay = 29;
                else
                    maxDay = 28;
            }

            do
            {
                Console.WriteLine("Please Enter your day birthday: ");
                daybirth = int.Parse(Console.ReadLine());
            } while (daybirth < 1 || daybirth > maxDay);
            int currentday = DateTime.Now.Day;
            int currentmonth = DateTime.Now.Month;
            int currentyear = DateTime.Now.Year;
            int realday, realmonth, realyear;
            realyear = currentyear - yearbirht;
            realmonth = currentmonth - monthbirth;
            realday = currentday - daybirth;
            if (realmonth < 0)
            {
                realyear--;
                realmonth += 12;
            }
            if (realday < 0)
            {
                realmonth--;
                switch (currentmonth)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        realday += 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        realday += 30;
                        break;
                    case 2:
                        if (yearbirht % 4 == 0) realday += 29;
                        else realday += 28;
                        break;
                }
            }
            Console.WriteLine($"Your birthda is {realyear} year and {realmonth} months {realday} days");
            ////6-simple calculator
            int num1;
            int num2;
            char operat;
            char ch;
            do
            {
                Console.Write("Please Enter Num1 : ");
                num1 = int.Parse(Console.ReadLine());
                Console.Write("Please Enter Num2 : ");
                num2 = int.Parse(Console.ReadLine());
                Console.Write("Please Enter operator (+, -, *, /, %): ");
                operat = char.Parse(Console.ReadLine());
                switch (operat)
                {
                    case '+':
                        Console.WriteLine($"{num1}{operat}{num2} = {num1 + num2}");
                        break;
                    case '-':
                        Console.WriteLine($"{num1}{operat}{num2} = {num1 - num2}");
                        break;
                    case '*':
                        Console.WriteLine($"{num1}{operat}{num2}={num1 * num2}");
                        break;
                    case '/':
                        if (num2 != 0)
                            Console.WriteLine($"{num1}{operat}{num2} = {num1 / num2}");
                        else
                            Console.WriteLine("Cannot divide by zero");
                        break;

                    case '%':
                        Console.WriteLine($"{num1}{operat}{num2} = {num1 % num2}");
                        break;
                    default:
                        Console.WriteLine("Invalid operator");
                        break;


                }
                do
                {
                    Console.WriteLine("Do You want continue..? Y/N");
                    ch = char.Parse(Console.ReadLine());
                } while (!"yYnN".Contains(ch));
            }
            while (ch == 'y' || ch == 'Y');
            Console.WriteLine("You Exist from calculator ");
            //7 Employees [struct] & choose index  & overwrite
            int index; char Ch;
            Console.WriteLine("Pls enter number of length array : ");
            int numemployees = int.Parse(Console.ReadLine());
            Employee[] employees = new Employee[numemployees];
            int cou = 0;
            do
            {

                //enter index
                do
                {
                    Console.WriteLine("pls enter index you want add in array data :");
                    index = int.Parse(Console.ReadLine());
                } while (index < 0 && index > numemployees);
                //free
                if (employees[index].name == null)
                {
                    Console.WriteLine("Pls enter name of employee : ");
                    employees[index].name = Console.ReadLine();

                    Console.WriteLine("Pls enter salary of employee : ");
                    employees[index].salary = int.Parse(Console.ReadLine());

                    Console.WriteLine("Pls enter ID of employee : ");
                    employees[index].id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Pls enter age of employee : ");
                    employees[index].age = int.Parse(Console.ReadLine());
                }
                //overWrite
                else
                {
                    do
                    {
                        Console.WriteLine("Do You Want To Over write y/n..?");
                        c = char.Parse(Console.ReadLine());
                    } while (!"yYnN".Contains(c));

                    if (c == 'y' || c == 'Y')
                    {
                        employees[index] = new Employee();
                        Console.WriteLine("Pls enter name of employee : ");
                        employees[index].name = Console.ReadLine();

                        Console.WriteLine("Pls enter salary of employee : ");
                        employees[index].salary = int.Parse(Console.ReadLine());

                        Console.WriteLine("Pls enter ID of employee : ");
                        employees[index].id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Pls enter age of employee : ");
                        employees[index].age = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Choose another index...");
                        Ch = 'y';
                        continue;
                    }

                }

                do
                {
                    Console.WriteLine("Do You want continue..? Y/N");
                    Ch = char.Parse(Console.ReadLine());
                    cou++;

                } while (!"yYnN".Contains(Ch));
            } while ((Ch == 'y' || Ch == 'Y') && cou != numemployees);

            Console.WriteLine("I will show data employee");
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"the employee data of {i} : Name {employees[i].name} and Salary {employees[i].salary} and ID {employees[i].id} and Age is {employees[i].age}");
            }
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>//
            ///day3 oop encapusaltion
            /////1-class Complex
            //real,img ,ss,gg,print,Add
            Complex c1 = new Complex();
            Complex c2 = new Complex();
            Complex c3 = new Complex();
            Console.WriteLine("please enter num real : ");
            c1.SettReal(int.Parse(Console.ReadLine()));
            Console.WriteLine("please enter num img : ");
            c1.Settimaginary(int.Parse(Console.ReadLine()));
            Console.WriteLine(c1.Print());
            c2.SettReal(3);
            c2.Settimaginary(4);
            c3 = c1.add(c1, c2);
            Console.WriteLine($"sum of 2 complex   {c1.Print()} and {c2.Print()} is ");
            Console.WriteLine(c3.Print());

            /////2-class Employee
            ///////->one employee  read then write 
            Employee_ emp = new Employee_();
            Console.WriteLine("pls enter name : ");
            emp.setname(Console.ReadLine());

            Console.WriteLine("pls enter id : ");
            emp.setId(int.Parse(Console.ReadLine()));

            Console.WriteLine("pls enter salary : ");
            emp.setsalary(int.Parse(Console.ReadLine()));

            Console.WriteLine("pls enter age : ");
            emp.setage(int.Parse(Console.ReadLine()));
            Console.WriteLine(emp.print());
            ///////->3 employee  read then write
            Employee_[] emps = new Employee_[3];//?????
            for (int i = 0; i < emps.Length; i++)
            {
                emps[i] = new Employee_();
                Console.WriteLine("pls enter name : ");
                emps[i].setname(Console.ReadLine());

                Console.WriteLine("pls enter id : ");
                emps[i].setId(int.Parse(Console.ReadLine()));

                Console.WriteLine("pls enter salary : ");
                emps[i].setsalary(int.Parse(Console.ReadLine()));

                Console.WriteLine("pls enter age : ");
                emps[i].setage(int.Parse(Console.ReadLine()));
                Console.WriteLine(emps[i].print());

            }









        }


    }
    
}
