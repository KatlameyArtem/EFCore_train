using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efcore_training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace efcore_training
{
    partial class Program
    {
        private static void ListProducts(int[]? productIdsToHightlight)
        {
            using NorthwindDb db = new NorthwindDb();
            if(db.Products is null || !db.Products.Any())
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}", "Id","Product Name","Cost","Stock","Disc.");
            foreach(Product p in db.Products)
            {
                ConsoleColor previousColor = ForegroundColor;
                if(productIdsToHightlight is not null  && productIdsToHightlight.Contains(p.ProductId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4}", p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
                ForegroundColor = previousColor;
            }
        }
        private static (int affected, int productId) AddProducts(int categoryId,string productName,decimal? price, short? stock)
        {
            using NorthwindDb db = new NorthwindDb();
            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = stock
            };


            //Set products as added in change tracking
            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State: {entity.State},ProductId {p.ProductId}");


            //Save tracked change to database
            int affected =  db.SaveChanges();
            WriteLine($"State: {entity.State},ProductId {p.ProductId}");
            return (affected, p.ProductId);
        }
        private static (int affected,int productId) IncreaseProductPrise(string productNameStartsWith,decimal amount)
        {
            using NorthwindDb db = new();
            if (db.Products is null) return (0,0);

            //get the first product whose name starts with the parameter value
            Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(productNameStartsWith));

            updateProduct.Cost += amount;

            int affected = db.SaveChanges();
            return (affected, updateProduct.ProductId);
        }
        private static int DeleteProducts(string productNameStartsWith)
        {
            using NorthwindDb db = new();
            IQueryable<Product>? products = db.Products?.Where(p => p.ProductName.StartsWith(productNameStartsWith));

            if (products is null || !products.Any())
            {
                WriteLine("No products found to delete");
                return 0;
            }
            else
            {
                if(db.Products is null) return 0;
                db.Products.RemoveRange(products);
            }
            int affected = db.SaveChanges();
            return affected;
        }
        private static (int affected, int[]? productsIds) IncreaseProductPricesBetter(string productNameStartsWith,decimal amount)
        {
            using NorthwindDb db = new();

            if (db.Products is null) return (0, null);


            //get products whose name starts with parameters value.
            IQueryable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(productNameStartsWith));

            int affected = products.ExecuteUpdate(s => s.SetProperty(p => p.Cost, p => p.Cost + amount));

            int[] productsIds = products.Select(p => p.ProductId).ToArray();

            return (affected, productsIds);
        }
    }
}
