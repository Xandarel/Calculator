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
            string br = brackets.ToString().Substring(1, brackets.Length-2);//Возможно нужно выделить в отдельный метод
            int flag = 0;
            foreach (var t in br)
            {
                if (!Char.IsDigit(t) && t != '.')
                    break;
                flag++;
            }

        }
    }
}
