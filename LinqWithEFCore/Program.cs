using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWithEFCore
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ConfigureConsole();//Sets US English by default
            //FilterAndSort();
            //JoinCategoriesAndProducts();
            //GroupJoinCategoriesAndProducts();
            //ProductsForLookups();
            AggregateProducts();
        }
    }
}
