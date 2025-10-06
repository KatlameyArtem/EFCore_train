using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace LinqWithEFCore
{
    partial class Program
    {
        private static void ConfigureConsole(string culture = "en-ES", bool useComputerCulture = false)
        {
            //To enable UNICODE characters like Euro symbol in the console
            OutputEncoding = Encoding.UTF8;

            if(!useComputerCulture)
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            }
            WriteLine($"Current culture : {CultureInfo.CurrentCulture.DisplayName}");
        }
        private static void SectionTitle(string title)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"*** {title} ***");
            ForegroundColor = previousColor;
        }
    }
}
