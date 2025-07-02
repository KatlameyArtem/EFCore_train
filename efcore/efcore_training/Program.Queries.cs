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
        }
    }
}
