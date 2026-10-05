using ASSLINQ;
using System.Collections;

namespace Session13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Element Operators

            #region question1

            // 1. Get the first product out if stock

            // Fluent syntax
            //var result = ListGenerators.ProductList.First(p => p.UnitsInStock == 0);

            // Query syntax
            //var result = (from p in ListGenerators.ProductList where p.UnitsInStock == 0 select p).First();

            #endregion

            #region question2

            // 2. Return the first product whose Price > 1000,
            //    unless there is no match, in which case null is returned.

            // Fluent syntax
            //var result = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1_000);

            // Query syntax
            //var result = (from p in ListGenerators.ProductList
            //              where p.UnitPrice > 1000
            //              select p).FirstOrDefault();

            #endregion

            #region question3

            // 3.  Retrieve the second number greater than 5  
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Fluent syntax
            //var result = Arr.Where(p => p > 5)
            //              .ElementAt(1);


            // Query syntax
            //var result = (from p in Arr
            //              where p > 5
            //              select p).ElementAt(1);


            #endregion

            #endregion

            #region Aggregrate Operations

            #region question1

            // 1. Uses Count to get the number of odd numbers in the array
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Fluent syntax
            //var result = Arr.Count(p => p % 2 != 0);

            // Query Syntax
            //var result = (from p in Arr
            //              where p % 2 != 0
            //              select p).Count();

            #endregion

            #region question2

            // 2. Return a list of customers and how many orders each has.

            //Fluent syntax
            //var result = ListGenerators.CustomerList
            //                                    .Select(c => new
            //                                    {
            //                                         CustomerName = c.CustomerName,
            //                                        OrderCount = c.Orders?.Count() ?? 0
            //                                    });


            // Query syntax
            //var result = from c in ListGenerators.CustomerList
            //             select new
            //             {
            //                 CunstomerName = c.CustomerName,
            //                 OrderCount = c.Orders?.Count() ?? 0
            //             };

            #endregion

            // From here -------------------------

            #region question3

            // 3. Return a list of categories and how many products each has 

            // Fluent syntax
            //var result = ListGenerators.ProductList.GroupBy(p => p.Category)
            //                                       .Select(g => new
            //                                       {
            //                                           Category = g.Key,
            //                                           ProductCount = g.Count()
            //                                       });


            // Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             select new 
            //                 {
            //                  Category = g.Key,
            //                  ProductCount = g.Count()
            //                 };

            #endregion

            #region question4

            // 4. Get the total of the numbers in an array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Fluent syntax
            //var result = Arr.Sum();

            // Query syntax
            //var result = (from n in Arr 
            //              select n).Sum();
            #endregion

            #region question5

            // 5. Get the total number of characters of all words in dictionary_english.txt
            // (Read dictionary_english.txt into an array of String First). 

            //string[] Words = File.ReadAllLines("dictionary_english.txt");

            //Fluent syntax
            //var TotaNumberOfCharactersInFile = Words.Sum(w => w.Length);

            //Query syntax
            //var result = (from w in Words
            //              select w.Length).Sum();
            #endregion

            #region question6

            // 6. Get the length of the shortest word in dictionary_english.txt
            //    (Read dictionary_english.txt into an array of Strings first).

            //string[] Words = File.ReadAllLines("dictionary_english.txt");

            //Fluent syntax
            //var result = Words.Min(w => w.Length);

            //Query syntax
            //var result = (from w in Words
            //              select w.Length).Min();

            #endregion

            #region question7

            // 7. Get the length of the longest word in dictionary_english.txt

            //string[] Words = File.ReadAllLines("dictionary_english.txt");

            //Fluent syntax
            //var result = Words.Max(w => w.Length);

            //Query syntax
            //var result = (from w in Words 
            //              select w.Length).Max();
            #endregion

            #region question8

            // 8. Get the average length of the words in dictionary_english.txt

            //string[] Words = File.ReadAllLines("dictionary_english.txt");

            //Fluent syntax
            //var result = Words.Average(w => w.Length);

            //Query syntax
            //var result = (from w in Words
            //              select w.Length).Average();
            #endregion

            #region question9

            // 9. Get the total units in stock for each product category. 

            //Fluent syntax
            //var result = ListGenerators.ProductList.GroupBy(p => p.Category)
            //              .Select(g => new 
            //                        {
            //                            Category = g.Key,
            //                            TotalUnits = g.Sum(p => p.UnitsInStock) 
            //                        });


            //Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             select new 
            //             {
            //                 Category = g.Key,
            //                 TotalUnits = g.Sum(p => p.UnitsInStock)
            //             };

            #endregion

            #region question10 

            // Get the cheapest price among each category's products

            //Fluent syntax
            //var result = ListGenerators.ProductList.GroupBy(p => p.Category)
            //                                       .Select(g => new
            //                                       {
            //                                           Category = g.Key,
            //                                           Cheapest = g.Min(p => p.UnitPrice)
            //                                       });


            //Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             select new 
            //             { 
            //                 Category = g.Key,
            //                 Cheapest = g.Min(p => p.UnitPrice) 
            //             };

            #endregion

            #region question11

            // 11. Get the products with the lowest price in each category (Use LET)

            //Fluent syntax 
            //var result = ListGenerators.ProductList
            //               .GroupBy(p => p.Category)
            //               .Select(g => new
            //               {
            //                   Category = g.Key,
            //                   Products = g.Where(p => p.UnitPrice == g.Min(x => x.UnitPrice))
            //               });


            //Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             let minPrice = g.Min(p => p.UnitPrice)
            //             select new 
            //             { 
            //                 Category = g.Key, 
            //                 Products = g.Where(p => p.UnitPrice == minPrice)
            //             };

            #endregion

            #region question12

            // 12. Highest price in each category

            //fluent syntax
            //var result = ListGenerators.ProductList
            //                   .GroupBy(p => p.Category)
            //                   .Select(g => new 
            //                   { 
            //                       Category = g.Key,
            //                       Highest = g.Max(p => p.UnitPrice)
            //                   });


            //Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //            select new 
            //            { 
            //                Category = g.Key,
            //                Highest = g.Max(p => p.UnitPrice) 
            //            };

            #endregion

            #region question13

            // 13. Products with the highest price in each category

            //fluent syntax
            //var result = ListGenerators.ProductList
            //                   .GroupBy(p => p.Category)
            //                   .Select(g => new
            //                   {
            //                       Category = g.Key,
            //                       Products = g.Where(p => p.UnitPrice == g.Max(x => x.UnitPrice))
            //                   });


            //query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             let maxPrice = g.Max(p => p.UnitPrice)
            //             select new 
            //             { 
            //                 Category = g.Key,
            //                 Products = g.Where(p => p.UnitPrice == maxPrice) 
            //             };
            #endregion

            #region question14

            // 14. Average price of each category's products

            //Fluent syntax
            //var result = ListGenerators.ProductList
            //                   .GroupBy(p => p.Category)
            //                   .Select(g => new 
            //                   { 
            //                       Category = g.Key,
            //                       AvgPrice = g.Average(p => p.UnitPrice) 
            //                   });


            //Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             select new 
            //             { 
            //                 Category = g.Key,
            //                 AvgPrice = g.Average(p => p.UnitPrice) 
            //             };

            #endregion

            #endregion

            #region Set Operators 

            #region question1

            // 1. Unique category names

            //fluent syntax
            //var result = ListGenerators.ProductList.Select(p => p.Category).Distinct();

            //Query syntax 
            //var result = (from p in ListGenerators.ProductList
            //              select p.Category).Distinct();

            #endregion

            #region question2

            // 2. Unique first letters from both product and customer names

            //fluent syntax
            //var result = ListGenerators.ProductList
            //                                        .Select(p => p.ProductName[0])
            //                                        .Union(ListGenerators.CustomerList.Select(c => c.CustomerName[0]));

            //var result = (from p in ListGenerators.ProductList
            //              select p.ProductName[0])
            //              .Union(from c in ListGenerators.CustomerList select c.CustomerName[0]);

            #endregion

            #region question3

            // 3. Common first letters (product AND customer names)


            //Fluent syntax 
            //var result = ListGenerators.ProductList
            //                                    .Select(p => p.ProductName[0])
            //                                    .Intersect(ListGenerators.CustomerList.Select(c => c.CustomerName[0]));


            //Query syntax
            //var result = (from p in ListGenerators.ProductList
            //              select p.ProductName[0])
            //                                      .Intersect(from c in ListGenerators.CustomerList
            //                                                 select c.CustomerName[0]);

            #endregion

            #region question4

            // 4. First letters of product names that are NOT first letters of customer names

            //fluent syntax
            //var result = ListGenerators.ProductList
            //                  .Select(p => p.ProductName[0])
            //                  .Except(ListGenerators.CustomerList
            //                          .Select(c => c.CustomerName[0]));


            //Query syntax
            //var result = (from p in ListGenerators.ProductList
            //              select p.ProductName[0])
            //                                      .Except(from c in ListGenerators.CustomerList
            //                                              select c.CustomerName[0]);

            #endregion

            #region question5

            // 5. Last three characters of every customer and product name (keep duplicates)

            //fluent syntax
            //var result = ListGenerators.CustomerList.Select(c => c.CustomerName)
            //                                        .Concat(ListGenerators.ProductList
            //                                                .Select(p => p.ProductName))
            //                                        .Select(n => n.Substring(Math.Max(0, n.Length - 3)));


            //query syntax
            //var result = from n in (from c in ListGenerators.CustomerList
            //                        select c.CustomerName)
            //                        .Concat(from p in ListGenerators.ProductList
            //                                select p.ProductName)
            //             select n.Substring(Math.Max(0, n.Length - 3));

            #endregion

            #endregion

            #region Partitioning Operators

            #region question1

            // 1. Get the first 3 orders from customers in Washington 

            //Fluent syntax
            //var result = ListGenerators.CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Take(3);


            //query syntax
            //var result = (from c in ListGenerators.CustomerList
            //               where c.Region == "WA"
            //               from o in c.Orders
            //               select o).Take(3);

            #endregion

            #region question2
            // 2. All but the first 2 orders from customers in Washington

            //fluent syntax
            //var result = ListGenerators.CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Skip(2);

            //query syntax
            //var result = (from c in ListGenerators.CustomerList
            //           where c.Region == "WA"
            //           from o in c.Orders
            //           select o).Skip(2);

            #endregion

            #region question3

            // 3. Take from the start until a number is less than its position
            //    (the index overload exists only in method form, so the query version wraps it)

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //fluent syntax
            //var result = numbers.TakeWhile((n, i) => n >= i);


            //query sntax
            //var result = (from n in numbers
            //              select n).TakeWhile((n, i) => n >= i);
            #endregion

            #region question4

            // 4.Get the elements of the array starting from the first element divisible by 3. 

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //fluent syntax
            //var result = numbers.SkipWhile(n => n % 3 != 0);

            //var result = (from n in numbers 
            //           select n).SkipWhile(n => n % 3 != 0);

            #endregion


            #region question5

            // 5. Elements starting from the first element less than its position

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //flunet syntax
            //var result = numbers.SkipWhile((n, i) => n >= i);

            //query syntax
            //var result = (from n in numbers 
            //              select n).SkipWhile((n, i) => n >= i);


            #endregion
            #endregion

            #region Quantifiers Operators

            #region question1

            // 1. Determine if any of the words in dictionary_english.txt
            // (Read dictionary_english.txt into an array of strings first) contain the substring 'ei'. 

            //string[] Words = File.ReadAllLines("dictionary_english.txt");

            //Fluent syntax
            //var result = Words.Any(w => w.Contains("ei"));


            //query syntax
            //var result = (from w in Words
            //              select w).Any(w => w.Contains("ei"));
            #endregion

            #region question2

            // 2. Grouped products only for categories with at least one product out of stock

            //fluent syntax
            //var result = ListGenerators.ProductList
            //                            .GroupBy(p => p.Category)
            //                            .Where(g => g.Any(p => p.UnitsInStock == 0));


            //query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             where g.Any(p => p.UnitsInStock == 0)
            //             select g;

            #endregion

            #region question3

            // 3. Grouped products only for categories where ALL products are in stock

            //fluent syntax
            //var result = ListGenerators.ProductList
            //                           .GroupBy(p => p.Category)
            //                           .Where(g => g.All(p => p.UnitsInStock > 0));


            //Query syntax
            //var result = from p in ListGenerators.ProductList
            //             group p by p.Category into g
            //             where g.All(p => p.UnitsInStock > 0)
            //             select g;
            #endregion

            #endregion

            #region Grouping Operators

            #region question1

            // 1. Partition numbers by remainder when divided by 5

            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //fluent syntax
            //var result = numbers.GroupBy(n => n % 5);

            //query syntax
            //var result = from n in numbers group n by n % 5;

            #endregion

            #region question2

            // 2. Partition words by first letter (dictionary_english.txt)

            //string[] Words = File.ReadAllLines("dictionary_english.txt");

            //fluent syntax
            //var result = Words.Where(w => w.Length > 0).GroupBy(w => w[0]);

            //query syntax
            //var result = from w in Words
            //             where w.Length > 0
            //             group w by w[0];
            #endregion

            #region question3

            // 3. Group anagrams together using a custom comparer
            //string[] anagramWords = { "from", "salt", "earn", " last", "near", "form" };

            //fluent syntax
            //var result = anagramWords.GroupBy(w => w, new AnagramEqualityComparer());

            //query syntax
            //var result = from g in anagramWords
            //             .GroupBy(w => w, new AnagramEqualityComparer())
            //             select g;
            #endregion

            #endregion
        }

        //used in Grouping Operators - question3
        class AnagramEqualityComparer : IEqualityComparer<string>
        {
            static string Normalize(string s) =>
                new string(s.Trim().ToCharArray().OrderBy(c => c).ToArray());

            public bool Equals(string x, string y) => Normalize(x) == Normalize(y);
            public int GetHashCode(string obj) => Normalize(obj).GetHashCode();
        }
    }
}
