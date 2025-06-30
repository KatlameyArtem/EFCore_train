using Microsoft.EntityFrameworkCore;

namespace learn_practice.efcore
{
    public class NorthwindDb: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFile = "Northwind.db";
            string path = Path.Combine(Environment.CurrentDirectory,databaseFile);
            string connectionString = $"Data Source = {path}";
            WriteLine($"Connection : {connectionString}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
