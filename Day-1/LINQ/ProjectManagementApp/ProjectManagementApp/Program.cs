using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductsCollection();
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
            
            Console.ReadLine();

        }

        public static bool IsProductBelongToCategoryTwo(Product product)
        {
            return product.Category == 2;
        }

        private static void PrintProducts(string title, ProductsCollection products)
        {
            Console.WriteLine(title);
            Console.WriteLine("===========================================");
            /*for(var i=0;i<products.Count;i++)
                Console.WriteLine(products[i]);*/
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }
    }

    public class ProductSearchCriteriaByCategory : IProductSearchCriteria
    {
        private readonly int _category;

        public ProductSearchCriteriaByCategory(int category)
        {
            _category = category;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Category == _category;
        }
    }

    public delegate bool ProductCriteriaDelegate(Product product);
}
