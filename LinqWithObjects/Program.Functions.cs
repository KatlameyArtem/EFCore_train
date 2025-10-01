using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWithObjects
{
    partial class Program
    {
        private static void DefferedExecution(string[] names)
        {
            SectionTitle("Defferes execution");

            //Question: Which names end with an M?
            //(using a LINQ extension method)
            var query1 = names.Where(name => name.EndsWith("m"));


            //Question: Which names end with M?
            //(using LINQ query comprehesion syntax)
            var query2 = from name in names
                         where name.EndsWith("m")
                         select name;

            string[] result = query1.ToArray();
            List<string> result2 = query2.ToList();

            foreach (var name in query1)
            {
                WriteLine(name);//Outputs Pam
                names[2] = "Jimmy";//Change Jim to Jimmy
                //On a second iteration Jimmy does not
                //end with an "m" so it does not get output
            }
            
        }
        private static void FilteringUsingWhere(string[] names)
        {
            SectionTitle("Filtering entities using where");


            //Explicitly creating the required delegate
            //var query = names.Where(new Func<string, bool >(NameLongerThanFour) );



            //The compiler creates the delegate automatically
            //var query = names.Where(NameLongerThanFour);



            //Using a lambda expression instead of a named method
            var query = names
                .Where(names => names.Length > 4)
                .OrderBy(names => names.Length)
                .ThenBy(names => names);
                

            //var query = names.OrderBy(name => name);
            //var query = names.Order();



            foreach(string item in query)
            {
                WriteLine(item);
            }
        }
        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }
    }
}
