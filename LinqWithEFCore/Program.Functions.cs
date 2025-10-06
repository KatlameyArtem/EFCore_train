using LinqWithObjects.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWithEFCore
{
    partial class Program
    {
        private static void FilterAndSort()
        {
            SectionTitle("Filter and Sort");

            using NorthwindDb db = new();
            DbSet<Product> allProducts = db.Products;

            IQueryable<Product> filteredProducts =
                allProducts.Where(products => products.UnitPrice < 10M);
            IOrderedQueryable<Product> sortedAndFilteredProducts = 
                filteredProducts.OrderByDescending(products => products.UnitPrice);
            
            ///Projecting sequence into a new type
            var projectedProducts = sortedAndFilteredProducts
               .Select(product => new //Anonymus type
               {
                   product.ProductId,
                   product.ProductName,
                   product.UnitPrice
               });

            WriteLine("Products tha cost less than 10M: ");
            
            
            
            WriteLine(projectedProducts.ToQueryString());


            foreach(var p in projectedProducts)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}",
                    p.ProductId, p.ProductName, p.UnitPrice);
            }
            WriteLine();
        }
        private static void JoinCategoriesAndProducts()
        {
            SectionTitle("Join categories and products");
            using NorthwindDb db = new();

            //Join every product to its category to return 77 matches
            var queryJoin = db.Categories.Join(
                inner: db.Products,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.CategoryId,
                resultSelector: (c, p) =>
                    new { c.CategoryName, p.ProductName, p.ProductId })
                .OrderBy(cp => cp.CategoryName);

            WriteLine(queryJoin.ToQueryString());
            foreach(var p in queryJoin)
            {
                WriteLine($"{p.ProductId}: {p.ProductName} in {p.CategoryName}");
            }
        }
        private static void GroupJoinCategoriesAndProducts()
        {
            SectionTitle("Group join categories and products");

            using NorthwindDb db = new();

            //Group all products by their categories to return 8 matches
            var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                inner: db.Products,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.CategoryId,
                resultSelector: (c,matchingProducts) => new
                {
                    c.CategoryName,
                    Products = matchingProducts.OrderBy(p => p.ProductName)
                });

            foreach(var c in queryGroup)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count()} products");

                foreach(var product in c.Products)
                {
                    WriteLine($"   {product.ProductName}");
                }
            }
        }
        private static void ProductsForLookups()
        {
            SectionTitle("Products lookup");

            using NorthwindDb db = new();

            //Join all products to their category to return 77 matches
            var productQeury = db.Categories.Join(
                inner: db.Products,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.CategoryId,
                resultSelector: (c, p) => new { c.CategoryName, Product = p }
                );

            ILookup<string, Product> productLookup = productQeury.ToLookup(
                keySelector: cp => cp.CategoryName,
                elementSelector: cp => cp.Product
                );
            foreach(IGrouping<string, Product> group in productLookup)
            {
                //Key is Beverages, Condiments, and so on.
                WriteLine($"{group.Key} has {group.Count()} products");

                foreach(Product product in group)
                {
                    WriteLine($" {product.ProductName}");
                }
            }
            //We can look up the products by a category name.
            Write("Enter a category name: ");
            string categoryName = ReadLine();
            WriteLine();
            WriteLine($"Products in {categoryName}");
            IEnumerable<Product> productsInCategory = productLookup[categoryName];
            foreach(Product product in productsInCategory)
            {
                WriteLine($"   {product.ProductName}");
            }
        }
    }
}
