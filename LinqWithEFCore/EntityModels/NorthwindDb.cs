using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace LinqWithObjects.EntityModels
{
    public class NorthwindDb: DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = @"DESKTOP-SKKL9UD\SQLEXPRESS";
            builder.InitialCatalog = "Northwind";
            builder.IntegratedSecurity = true;
            builder.Encrypt = true;
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            string connection = builder.ConnectionString;

            optionsBuilder.UseSqlServer(connection);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    if (Database.ProviderName.Contains("Sqlite") && Database.ProviderName is not null)
        //    {
        //        modelBuilder.Entity<Product>()
        //            .Property(product => product.UnitPrice)
        //            .HasConversion<double>();
        //    }
        //}
    }
}
