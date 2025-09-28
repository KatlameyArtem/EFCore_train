using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore_training
{
     partial class Program
    {
        static void Main(string[] args)
        {
            //ConfigureConsole();
            //QueringCaregories();
            //Console.WriteLine( "Single/Frist LINQ");
            //GettinOneProduct();
            //QueryingWithLike();
            //GetRandomProduct();
            //var resultadd = AddProducts(6, "Bob`s Burfers", 500M, 72);
            //if(resultadd.affected == 1)
            //{
            //    WriteLine($"Add product successful with ID:{resultadd.productId}");
            //}
            //ListProducts(productIdsToHightlight: new[] { resultadd.productId });
            var resultUpdate = IncreaseProductPrise("Bob", 20M);
            if(resultUpdate.affected == 1)
            {
                WriteLine($"Increase price success for ID: {resultUpdate.productId}");
            }
            ListProducts(productIdsToHightlight: new[] {resultUpdate.productId });
        }
    }
}
