using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Regex regex = new Regex(@"\(\d*[+|-|*|/]\d*\)");
            MatchCollection matches = regex.Matches(expression);
            Console.ReadKey();
        }
    }
}
