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
            IOrderedEnumerable<string> query = names //var
                .Where(names => names.Length > 4)
                .OrderBy(names => names.Length)
                .ThenBy(names => names);

            //var query = names.OrderBy(name => name);
            //var query = names.Order();



            foreach (string item in query)
            {
                WriteLine(item);
            }
        }
        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

    static void FilteringByType()
        {
            SectionTitle("Filtering by type");

            List<Exception> exepctions = new()
            {
                new ArgumentException(),new SystemException(),
                new IndexOutOfRangeException(),new InvalidOperationException(),
                new NullReferenceException(),new InvalidCastException(),
                new OverflowException(), new DivideByZeroException(),
                new ApplicationException()
            };

            IEnumerable<ArithmeticException> arithmeticExceptionsQuery =
                exepctions.OfType<ArithmeticException>();


            foreach(ArithmeticException exeptioin in arithmeticExceptionsQuery)
            {
                WriteLine(exeptioin);
            }
        }
        static void Output(IEnumerable<string> cohort, string description = "")
        {
            if (!string.IsNullOrEmpty(description))
            {
                Write(description);
            }
            WriteLine(string.Join(",", cohort.ToArray()));
        }
        static void WorkingWithSets()
        {
            string[] cohort1 =
                {"Rachel","Gareth","Jonathan","George"};
            string[] cohort2 =
                {"Jack","Stephen","Daniel","Jack","Jared"};
            string[] cohort3 =
                {"Declan","Jack","Jack","Jasmine","Conor"};
            SectionTitle("The cohorts");


            Output(cohort1);
            Output(cohort2);
            Output(cohort3);


            SectionTitle("Set operations");
            
            
            Output(cohort2.Distinct(), "cohort2.Distinct()");
            Output(cohort2.DistinctBy(name =>  name.Substring(0,2)), "name =>  name.Substring(0,2)");
            Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
            Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3)");
            Output(cohort2.Intersect(cohort3), "cohort2.Intersect(cohort3)");
            Output(cohort2.Except(cohort3), "cohort2.Except(cohort3)");
            Output(cohort1.Zip(cohort2, (c1, c2) => $"{c1} matched with {c2}"), "cohort1.Zip(cohort2)");
        }
    }


}
