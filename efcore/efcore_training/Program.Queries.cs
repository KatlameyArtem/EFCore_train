using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore_training
{
    partial class Program
    {
        private static void QueringCaregories()
        {
              using NorthwindDb db = new NorthwindDb();
            SectionTitle("Categories and how many products they have");
            //A query to get all categories and their related products.
            IQueryable<Category>? categories = db.Categories?
                .Include(c => c.Products);
            if (categories is null || !categories.Any())
            {
                Fail("No categories found.");
            }
            //Execute query and enumerate results.
            foreach(Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products");
            }
            //List<Category> categ = categories.ToList();
            //foreach (Category c in categ)
            //{
            //    WriteLine($"inside {c.Products}");
            //}
        }
        private static void GettinOneProduct()
        {
            using NorthwindDb db = new NorthwindDb();
            SectionTitle("Getting a single product");
            string? input;
            int id;
            do
            {
                Write("enter a product ID:");
                input = ReadLine();
            }while(int.TryParse(input, out id));
            Product? product = db.Products?
                .First(product => product.ProductId == id);
            Info($"First {product?.ProductName}");
            if (product is null) { Fail("no product found using First"); }
            product = db.Products?
                .Single(product => product.ProductId == id);
            Info($"Single : {product?.ProductName}");
            if(product is null) { Fail("no product found usinf Single"); }
        } 
    }
}
