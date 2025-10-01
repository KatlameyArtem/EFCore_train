using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWithObjects
{
    partial class Program
    {
        private static void SectionTitle(string title)
        {
            ConsoleColor previuosColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"*** {title} ***");
            ForegroundColor = previuosColor;
        }

    }
}
