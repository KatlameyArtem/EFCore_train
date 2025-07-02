using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore_training
{
    partial class Program
    {
        private static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
        {
            //enablw Unicode characters like Euro symbol in the console.
            OutputEncoding = System.Text.Encoding.UTF8;
            if (!useComputerCulture)
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            }
            WriteLine($"Current culture : {CultureInfo.CurrentCulture.DisplayName}");
        }
        private static void WriteLineInColor(string text, ConsoleColor color)
        {
            ConsoleColor previousColoe = ForegroundColor;
            ForegroundColor = color;
            WriteLine(text);
            ForegroundColor = previousColoe;
        }
        private static void SectionTitle(string title)
        {
            WriteLineInColor($"**** {title} ****", ConsoleColor.DarkYellow);
        }
        private static void Fail(string message)
        {
            WriteLineInColor($"Fail > {message}",ConsoleColor.Red);
        }
        private static void Info(string massage)
        {
            WriteLineInColor($"Info > {massage}",ConsoleColor.Cyan);
        } 
    }
}
