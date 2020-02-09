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
            int bracketsPosition;
            Regex regex = new Regex(@"\(.*\)");
            do {
                FindBrackets(expression, regex);
            } while ((bracketsPosition = expression.Count(c => c == '(')) != 0);
            Console.ReadKey();
        }
        static void DecisionBrackets(string text)//TODO: не нравится переделать
        {
            Regex regex = new Regex(@"[+|-|*|/]");
            MatchCollection matchCollection = regex.Matches(text);
            var numbers = text.Split('+','-','*','/');
            var signs = new string[matchCollection.Count];
            int positionInArray = 0;
            foreach(var match in matchCollection)
            {
                signs[positionInArray] = match.ToString();
                positionInArray++;
            }
        }
        static void FindBrackets(string text,Regex regex)
        {
            Match matches = regex.Match(text);
            if (matches.Success)
            {
                string newText = DeleteBrackets(matches);
                FindBrackets(newText, regex);
            }
            DecisionBrackets(text);
        }

        static string DeleteBrackets(Match match) => match.ToString().Substring(1, match.Length - 2);
    }
}
