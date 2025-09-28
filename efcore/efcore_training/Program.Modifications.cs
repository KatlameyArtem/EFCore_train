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
        private static void (int affected, int productId) AddProducts(int categoryId,string productName,decimal? price, short? stock)
        {
            using NorthwindDb db = new NorthwindDb();

        }
        
    }
}
