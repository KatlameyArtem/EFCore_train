using Microsoft.EntityFrameworkCore;

namespace learn_practice.efcore
{
    public class NorthwindDb: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //FRO SQLITE
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
