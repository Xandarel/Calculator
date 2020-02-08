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
            //Regex regex = new Regex(@"\(\d*\.?\d*[+|-|*|/]\d*\.?\d*\)");
            Regex regex = new Regex(@"\(.*\)");
            MatchCollection matches;
            do
            {
                matches = regex.Matches(expression);
                foreach (Match match in matches)
                    DecisionBrackets(expression, match);

            } while (matches.Count > 0);
            Console.ReadKey();
        }
        static void DecisionBrackets(string text, Match brackets)
        {
            //Убираем скобки. Оставляем тупо выражение
            string br = brackets.ToString().Substring(1, brackets.Length-2);//Возможно нужно выделить в отдельный метод
            Regex regex = new Regex(@"[+|-|*|/]");
            MatchCollection matches = regex.Matches(br);
        }
    }
}
