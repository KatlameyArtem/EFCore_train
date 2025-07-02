using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace learn_practice.efcore
{
    public class NorthwindDb : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API Example instead of attributes
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()//not null
                .HasMaxLength(15);
//            "Эй, EF Core! Когда будешь создавать таблицу Categories, учти, что поле CategoryName должно быть:

//            NOT NULL(обязательно, нельзя пустое)

//            NVARCHAR(15) — то есть максимум 15 символов текста"


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //FOR SQLITE
            //string databaseFile = "Northwind.db";
            //string path = Path.Combine(Environment.CurrentDirectory,databaseFile);
            //string connectionString = $"Data Source = {path}";
            //WriteLine($"Connection : {connectionString}");

            

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;";
            Console.WriteLine($"Connection string: {connectionString}");
            optionsBuilder.UseSqlServer(connectionString);

            //Server = (localdb)\MSSQLLocalDB;      Локальный сервер SQL (устанавливается с Visual Studio)
            //Database = Northwind;                Имя базы данных (ты уже импортировал файл .sql)
            //Trusted_Connection = True;          Использует Windows аутентификацию
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
