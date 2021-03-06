﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new MyCollection<Product>();
            products.Add(new Product { Id = 12, Name = "Pen", Cost = 10, Units = 21, Category = 1});
            products.Add(new Product { Id = 18, Name = "Zen", Cost = 20, Units = 17, Category = 1 });
            products.Add(new Product { Id = 13, Name = "Ken", Cost = 19, Units = 10, Category = 2 });
            products.Add(new Product { Id = 20, Name = "Ten", Cost = 56, Units = 11, Category = 1 });
            products.Add(new Product { Id = 45, Name = "Den", Cost = 34, Units = 31, Category = 1 });
            products.Add(new Product { Id = 13, Name = "Hen", Cost = 22, Units = 15, Category = 2 });

            PrintProducts("Initial List", products);
            var categoryOneProducts = products.Search(new ProductSearchCriteriaByCategory(1));
            PrintProducts("Category - 1 Products",categoryOneProducts);
            //var categoryTwoProducts = products.Search(new ProductCriteriaDelegate(IsProductBelongToCategoryTwo));
            //var categoryTwoProducts = products.Search(IsProductBelongToCategoryTwo);
            /*var categoryTwoProducts = products.Search(delegate(Product product)
                {
                    return product.Category == 2;
                });
            */
            /*var categoryTwoProducts = products.Search((product) =>
                {
                    return product.Category == 2;
                });*/
            var categoryTwoProducts = products.Search(product => product.Category == 2);
            PrintProducts("Category - 2 Products", categoryTwoProducts);
            Console.WriteLine("Minimum Id");
            Console.WriteLine("=================================");
            Console.WriteLine(products.Min(p => p.Id));
            Console.WriteLine("Minimum Cost");
            Console.WriteLine("=================================");
            Console.WriteLine(products.Min(p => p.Cost));
            Console.WriteLine();

            var productsByCategory = products.GroupBy(p => p.Category);
            Console.WriteLine("Products By Category");
            Console.WriteLine("=================================");
            foreach (var productCategory in productsByCategory)
            {
                Console.WriteLine("Category = {0}", productCategory.Key);
                foreach (var product in productCategory.Value)
                {
                    Console.WriteLine("\t{0}", product.Format("\t"));
                }
            }
            Console.WriteLine();
            // Join //
            var categories = new MyCollection<Category>
                {
                    new Category() {Id = 1, Name = "Stationary"},
                    new Category() {Id = 2, Name = "Electronics"}
                };

            var productWithCategory = products.Join(categories, p => p.Category, c => c.Id,
                                                    (p, c) => new ProductCategory()
                                                        {
                                                            Id = p.Id,
                                                            Name = p.Name,
                                                            Cost = p.Cost,
                                                            Units = p.Units,
                                                            CategoryName = c.Name
                                                        });
            Console.WriteLine("Products joined with Categories");
            Console.WriteLine("===========================================");
            foreach (var productCategory in productWithCategory)
            {
                Console.WriteLine(productCategory.Format("\t"));
            }
            Console.ReadLine();
            var employee = new Employee {Id = 100, FirstName = "Magesh", LastName = "K", Salary = 10000};
            Console.WriteLine(MyUtilities.Format(employee,"\t"));
            Console.WriteLine();
            var evenNumbers = MyUtils.GetEvenNumbers(100);
            var counter = 0;
            var evenNumbersEnumerator = evenNumbers.GetEnumerator();
            while (evenNumbersEnumerator.MoveNext())
            {
                Console.WriteLine(evenNumbersEnumerator.Current);
                counter++;
                if (counter >= 10)
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Lazy");
            var evenNumbersLazy = MyUtils.GetEvenNumbersLazy(100);
            var counterLazy = 0;
            var evenNumbersEnumeratorLazy = evenNumbersLazy.GetEnumerator();
            while (evenNumbersEnumeratorLazy.MoveNext())
            {
                Console.WriteLine(evenNumbersEnumeratorLazy.Current);
                counterLazy++;
                if (counterLazy >= 10)
                    break;
            }
            
            Console.ReadLine();

        }

        public static bool IsProductBelongToCategoryTwo(Product product)
        {
            return product.Category == 2;
        }

        private static void PrintProducts(string title, IEnumerable<Product> products)
        {
            Console.WriteLine(title);
            Console.WriteLine("===========================================");
            /*for(var i=0;i<products.Count;i++)
                Console.WriteLine(products[i]);*/
            foreach (var product in products)
            {
                Console.WriteLine(MyUtilities.Format(product,"\t"));
            }
            Console.WriteLine();
        }
    }
}
