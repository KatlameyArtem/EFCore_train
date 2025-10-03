using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWithObjects
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // A string array is a sequence that implements IEnumerable<string>
            string[] names = { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

            //DefferedExecution(names);
            //FilteringByType();
            //FilteringUsingWhere(names);
            WorkingWithSets();
        }
    }
}
