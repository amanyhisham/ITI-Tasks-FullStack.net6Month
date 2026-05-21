using L2O___D09;
using System.Linq;
using System.Numerics;
namespace LinqDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = ListGenerators.ProductList;
            var customers = ListGenerators.CustomerList;
            //LINQ - Restriction Operators
            //query1  
            Console.WriteLine("--------------------------------Query1--------------------------------");
            var query1 = products.Where(p => p.UnitsInStock == 0);

            foreach (var p in query1)
                Console.WriteLine(p.ProductName);
            //query2
            Console.WriteLine("--------------------------------Query2--------------------------------");
            var query2 = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            foreach (var p in query2)
                Console.WriteLine("ProductName: " + p.ProductName + " - Price: " + p.UnitPrice);
            //query3
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var query3 = Arr.Where((name, index) => name.Length < index);

            foreach (var name in query3)
                Console.WriteLine(name);
            //LINQ - Element Operators
            //query4
            Console.WriteLine("--------------------------------Query4--------------------------------");
            var query4 = products.First(p => p.UnitsInStock == 0);
            Console.WriteLine(query4.ProductName);
            //query5
            Console.WriteLine("--------------------------------Query5--------------------------------");
            var query5 = products.FirstOrDefault(p => p.UnitPrice > 1000);
            if (query5 == null)
                Console.WriteLine("No product found");
            else
                Console.WriteLine(query5.ProductName);
            //query6
            Console.WriteLine("--------------------------------Query6--------------------------------");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var query6 = Arr2.Where(p => p > 5).Skip(1).First();//Arr2.Where(n => n > 5).ElementAt(1);

            Console.WriteLine(string.Join(", ", query6));
            //query7
            Console.WriteLine("---------------------------------Query7--------------------------------");
            var query7 = products.Select(p => p.Category).Distinct();//select option to take part of product

            foreach (var c in query7)
                Console.WriteLine(c);
            //query8---.Union(...).Distinct()
            Console.WriteLine("---------------------------------Query8--------------------------------");
            var query8 = products.Select(p => p.ProductName[0]).Union(customers.Select(c => c.CompanyName[0])).OrderBy(c => c);
            foreach (var c in query8)
                Console.WriteLine(c);
            //query9
            Console.WriteLine("---------------------------------Query9--------------------------------");
            var query9 = products.Select(p => p.ProductName[0]).Intersect(customers.Select(c => c.CompanyName[0])).OrderBy(c => c);
            foreach (var c in query9)
                Console.WriteLine(c);
            //query10
            Console.WriteLine("---------------------------------Query10--------------------------------");
            var query10 = products.Select(p => p.ProductName[0]).Except(customers.Select(c => c.CompanyName[0])).OrderBy(c => c);
            foreach (var c in query10)
                Console.WriteLine(c);
            //query11
            Console.WriteLine("---------------------------------Query11--------------------------------");
            var query11 = products.Select(p => p.ProductName)
                .Concat(customers.Select(c => c.CompanyName))
                .Select(item => item.Substring(item.Length - 3));

            foreach (var item in query11)
            {
                Console.WriteLine(item);
            }
            //Aggregate Operators
            //query12
            Console.WriteLine("---------------------------------Query12--------------------------------");
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var query12 = Arr3.Count(n => n % 2 != 0);
            Console.WriteLine(query12);
            //query13
            Console.WriteLine("---------------------------------Query13--------------------------------");
            var query13 = customers.Select(c => new
            {
                c.CompanyName,
                OrderCount = c.Orders.Count()
            });

            foreach (var item in query13)
                Console.WriteLine($"{item.CompanyName} has {item.OrderCount} orders");
            //query14
            Console.WriteLine("---------------------------------Query14--------------------------------");
            var query14 = products.GroupBy(p => p.Category).Select(g => new
            {
                ProductName = g.Key,
                OrderCount = g.Count()
            });


            foreach (var item in query14)
                Console.WriteLine($"{item.ProductName} has {item.OrderCount} orders");
            //query15
            Console.WriteLine("---------------------------------Query15--------------------------------");

            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var query15 = Arr4.Sum();

            Console.WriteLine(query15);
            //query16
            Console.WriteLine("---------------------------------Query16--------------------------------");
            string[] words = File.ReadAllLines("dictionary_english.txt");
            var query16 = words.Sum(w => w.Length);
            Console.WriteLine(query16);
            //query17
            Console.WriteLine("---------------------------------Query17--------------------------------");
            var query17 = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                TotalUnits = g.Sum(p => p.UnitsInStock)
            });
            foreach (var item in query17)
                Console.WriteLine($"{item.Category}: {item.TotalUnits}");
            //query18
            Console.WriteLine("---------------------------------Query18--------------------------------");
            var query18 = words.Min(w => w.Length);
            Console.WriteLine(query18);
            //query19
            Console.WriteLine("---------------------------------Query19--------------------------------");
            var query19 = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                MinPrice = g.Min(p => p.UnitPrice)
            });
            foreach (var item in query19)
                Console.WriteLine($"{item.Category}: {item.MinPrice}");
            //query20
            Console.WriteLine("---------------------------------Query20--------------------------------");
            var query20 = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                CheapestProduct = g.Where(p => p.UnitPrice == g.Min(gp => gp.UnitPrice))
            });
            foreach (var item in query20)
            {
                Console.WriteLine(item.Category);
                foreach (var p in item.CheapestProduct)
                {
                    Console.WriteLine($"   {p.ProductName} - {p.UnitPrice}");
                }

                //query21
                Console.WriteLine("---------------------------------Query21--------------------------------");
                var query21 = words.OrderByDescending(w => w.Length).First();
                Console.WriteLine(query21);
                //query22
                Console.WriteLine("---------------------------------Query22--------------------------------");
                var query22 = products.GroupBy(p => p.Category).Select(g => new
                {
                    Category = g.Key,
                    MaxPrice = g.Max(gp => gp.UnitPrice)
                });
                foreach (var c in query22)
                {
                    Console.WriteLine($"{c.Category}: {c.MaxPrice}");
                }

                //query23
                Console.WriteLine("---------------------------------Query23--------------------------------");
                var query23 = products.GroupBy(p => p.Category).Select(g => new
                {
                    Category = g.Key,
                    MaxProduct = g.Where(p => p.UnitPrice == g.Max(gp => gp.UnitPrice))//select highest price product in each category
                });
                foreach (var P in query23)
                {
                    Console.WriteLine(P.Category);
                    foreach (var p in P.MaxProduct)
                    {
                        Console.WriteLine($"   {p.ProductName} - {p.UnitPrice}");
                    }
                }
                //query24
                Console.WriteLine("---------------------------------Query24--------------------------------");
                var query24 = products.GroupBy(p => p.Category).Select(g => new
                {
                    Category = g.Key,
                    Maxprice = g.Max(p => p.UnitPrice)
                });
                foreach (var p in query24)
                {
                    Console.WriteLine($"{p.Category}: {p.Maxprice}");
                }
                //query25
                Console.WriteLine("---------------------------------Query25--------------------------------");
                var query25 = words.Average(w => w.Length);
                Console.WriteLine(query25);
                //query26
                Console.WriteLine("---------------------------------Query26--------------------------------");
                var query26 = products.GroupBy(p => p.Category).Select(g => new
                {
                    Category = g.Key,
                    AveragePrice = g.Average(p => p.UnitPrice)
                });
                foreach (var p in query26)
                {
                    Console.WriteLine($"{p.Category}: {p.AveragePrice}");
                }
                //query27
                Console.WriteLine("---------------------------------Query27--------------------------------");
                var query27 = products.OrderBy(p => p.ProductName);
                 
                foreach (var p in query27)
                {
                    Console.WriteLine($"{p.ProductName}");
                }
                //query28
                Console.WriteLine("---------------------------------Query28--------------------------------");
                string[] Arr5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                var query28 = Arr5.OrderBy(n => n, StringComparer.OrdinalIgnoreCase);


                foreach (var p in query28)
                {
                    Console.WriteLine($"{p}");
                }
                //query29
                Console.WriteLine("---------------------------------Query29--------------------------------");
                 var query29 = products.OrderByDescending(p => p.UnitsInStock);

                foreach (var p in query29)
                {
                    Console.WriteLine($"{p.ProductName} => {p.UnitsInStock}");
                }
                //query30
                Console.WriteLine("---------------------------------Query30--------------------------------");
                string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                var query30 = Arr6.OrderBy(p => p.Length).ThenBy(p => p, StringComparer.OrdinalIgnoreCase);

                foreach (var p in query30)
                {
                    Console.WriteLine($"{p}");
                }
                //query31
                Console.WriteLine("---------------------------------Query31--------------------------------");
                string[] words2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                var query31 = words2.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

                foreach (var p in query31)
                {
                    Console.WriteLine($"{p}");
                }
                //query32
                Console.WriteLine("---------------------------------Query32--------------------------------");
                var query32 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

                foreach (var p in query32)
                {
                    Console.WriteLine($"{p.Category} => {p.UnitPrice}");
                }
                //query33
                Console.WriteLine("---------------------------------Query33--------------------------------");
                string[] Arr7 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                var query33 = Arr7.OrderBy(p => p.Length).ThenByDescending(p => p, StringComparer.OrdinalIgnoreCase);

                foreach (var p in query33)
                {
                    Console.WriteLine($"{p}");
                }
                //query34
                Console.WriteLine("---------------------------------Query34--------------------------------");
                string[] Arr8 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                var query34 = Arr8.Where(p => p[1] == 'i').Reverse();

                foreach (var p in query34)
                {
                    Console.WriteLine($"{p}");
                }
                //Partitioning Operators — Query 1
                //query35
                Console.WriteLine("---------------------------------Query35--------------------------------");
                 var query35 = customers.Where(c=>c.Region== "WA")
                     .SelectMany(c => c.Orders).Take(3);

                foreach (var p in query35)
                {
                    Console.WriteLine($"{p}");
                }
                //query36
                Console.WriteLine("---------------------------------Query36--------------------------------");
                var query36 = customers.Where(c => c.Region == "WA")
                    .SelectMany(c => c.Orders).Skip(2);

                foreach (var p in query36)
                {
                    Console.WriteLine($"{p}");
                }
                //query37
                Console.WriteLine("---------------------------------Query37--------------------------------");
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var query37 = numbers.TakeWhile((n, index) => n >= index);

                foreach (var p in query37)
                {
                    Console.WriteLine($"{p}");
                }
                //query38
                Console.WriteLine("---------------------------------Query38--------------------------------");
                var query38 = numbers.SkipWhile(n => n % 3 != 0);

                foreach (var p in query3)
                {
                    Console.WriteLine($"{p}");
                }
                //query39
                Console.WriteLine("---------------------------------Query39--------------------------------");
                var query39 = numbers.SkipWhile((n, index) => n >=index);

                foreach (var p in query39)
                {
                    Console.WriteLine($"{p}");
                }
                //query40
                Console.WriteLine("---------------------------------Query40--------------------------------");
                var query = products.Select(p => p.ProductName);

                foreach (var name in query)
                    Console.WriteLine(name);
                //query41
                Console.WriteLine("---------------------------------Query41--------------------------------");
                string[] words3 = { "aPPLE", "BlUeBeRrY", "cHeRry" };

                var query41 = words3.Select(w => new
                {
                    Upper = w.ToUpper(),
                    Lower = w.ToLower()
                });

                foreach (var o in query41)
                    Console.WriteLine($"Upper: {o.Upper}, Lower: {o.Lower}");
                //query42
                Console.WriteLine("---------------------------------Query42--------------------------------");
 
                var query42 = products.Select(p => new
                {
                    p.ProductName,
                    p.Category,
                    Price = p.UnitPrice
                });

                foreach (var o in query42)
                    Console.WriteLine($"{o.ProductName} - {o.Category} - {o.Price}");
                //query43
                Console.WriteLine("---------------------------------Query43--------------------------------");
                int[] Arr9 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var query43 = Arr9.Select((n, index)=> new
                {
                    Number = n,
                    Inplace = n == index,
                   
                }
                    );

                foreach (var o in query43)
                    Console.WriteLine($"{o.Number}: {o.Inplace}");
                //query43
                Console.WriteLine("---------------------------------Query44--------------------------------");
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };
                var query44 = numbersA.SelectMany(a => numbersB, (a, b) => new
                {
                    A = a,
                    B = b,
                }).Where(x => x.A < x.B); ;
                foreach (var o in query44)
                    Console.WriteLine($"{o.A} is less than {o.B}");
                //query45
                Console.WriteLine("---------------------------------Query45--------------------------------");
                var query45 = customers.SelectMany(c => c.Orders)
                     .Where(o => o.Total < 500);

                foreach (var o in query45)
                    Console.WriteLine(o);
                //query46
                Console.WriteLine("---------------------------------Query46--------------------------------");
                var query46 = customers.SelectMany(c => c.Orders)
                    .Where(o => o.OrderDate.Year >= 1998);

                foreach (var o in query46)
                    Console.WriteLine(o);
                //query47
                Console.WriteLine("---------------------------------Query47--------------------------------");
                var query47 =words.Any(w => w.Contains("ei"));
                    Console.WriteLine(query47);
                //query48
                Console.WriteLine("---------------------------------Query48--------------------------------");
                var query48 = products
                              .GroupBy(p => p.Category)
                              .Where(g => g.Any(p => p.UnitsInStock == 0))
                              .Select(g => g.Key);

                foreach (var c in query48)
                    Console.WriteLine(c);
                //query49
                Console.WriteLine("---------------------------------Query49--------------------------------");
                var query49 = products
                              .GroupBy(p => p.Category)
                              .Where(g => g.All(p => p.UnitsInStock > 0))
                              .Select(g => g.Key);

                foreach (var c in query49)
                    Console.WriteLine(c);
                //query50
                Console.WriteLine("---------------------------------Query50--------------------------------");
                var query50 = numbers.GroupBy(n => n % 5);

                foreach (var group in query50)
                {
                    Console.WriteLine($"Numbers with remainder {group.Key}:");

                    foreach (var n in group)
                        Console.WriteLine(n);
                }
                //query51
                Console.WriteLine("---------------------------------Query51--------------------------------");

                var query51 = words
                .GroupBy(w => w[0]);

                foreach (var group in query51)
                {
                    Console.WriteLine(group.Key);

                    foreach (var word in group)
                        Console.WriteLine(word);
                }
            }
        }
    }
}