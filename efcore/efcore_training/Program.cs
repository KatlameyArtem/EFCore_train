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




            var resultadd = AddProducts(6, "Bob`s Burfers", 500M, 72);
            if(resultadd.affected == 1)
            {
                WriteLine($"Add product successful with ID:{resultadd.productId}");
            }
            ListProducts(productIdsToHightlight: new[] { resultadd.productId });






            //var resultUpdate = IncreaseProductPrise("Bob", 20M);
            //if(resultUpdate.affected == 1)
            //{
            //    WriteLine($"Increase price success for ID: {resultUpdate.productId}");
            //}
            //ListProducts(productIdsToHightlight: new[] {resultUpdate.productId });




           //WriteLine("About to delete all products whose name starts with Bob.");
           //Write("Press enter to continue or any key to exit: ");
           //if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
           //{
           //    int deleted = DeleteProducts("Bob");
           //    WriteLine($"{deleted} product(s) were deleted");
           //}
           //else
           //{
           //    WriteLine("Delete was canceled");
           //}
           



            var resultUpdateBetter = IncreaseProductPricesBetter("Bob", 20M);
            if (resultUpdateBetter.affected > 0)
            {
                WriteLine("Increase product price successfull");
            }
            ListProducts(resultUpdateBetter.productsIds);

        }
    }
}
