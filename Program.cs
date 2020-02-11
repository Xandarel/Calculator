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
        static double DecisionBrackets(string text)//TODO: не нравится переделать
        {
            Regex regex = new Regex(@"[+|-|*|/]");
            MatchCollection matchCollection = regex.Matches(text);
            var numbers =new List<string> (text.Split('+', '-', '*', '/'));
            var signs = new List<string>();
            int positionInArray = 0;
            foreach(var match in matchCollection)
                signs.Add(match.ToString());

            while (signs.Count != 0)
            {
                if (signs.Count == 1)
                    return DecisionSign(Convert.ToDouble(numbers[0]), Convert.ToDouble(numbers[1]), signs[0]);
                else
                    for (positionInArray = 0; positionInArray < signs.Count; positionInArray++)
                        try
                        {
                            if ((signs[positionInArray] == "+" || signs[positionInArray] == "-") &&
                                (signs[positionInArray + 1] != "*" || signs[positionInArray + 1] != "*"))
                            {
                                numbers.Insert(positionInArray, DecisionSign(Convert.ToDouble(numbers[positionInArray]),
                                                                            Convert.ToDouble(numbers[positionInArray + 1]),
                                                                            signs[positionInArray]).ToString());
                                numbers.RemoveAt(positionInArray + 1);
                                numbers.RemoveAt(positionInArray + 1);
                                signs.RemoveAt(positionInArray);
                            }
                            else if (signs[positionInArray] == "*" || signs[positionInArray] == "/")
                            {
                                numbers.Insert(positionInArray, DecisionSign(Convert.ToDouble(numbers[positionInArray]),
                                                                            Convert.ToDouble(numbers[positionInArray + 1]),
                                                                            signs[positionInArray]).ToString());
                                numbers.RemoveAt(positionInArray + 1);
                                numbers.RemoveAt(positionInArray + 1);
                                signs.RemoveAt(positionInArray);
                            }
                        }
                        catch { }
            }
            return 0;//Заглушка. Сечас я считаю, что сюда код не доберется никогда.
        }
        static void FindBrackets(string text,Regex regex)
        {
            Match matches = regex.Match(text);
            if (matches.Success)
            {
                string newText = DeleteBrackets(matches);
                FindBrackets(newText, regex);
            }
            var result=DecisionBrackets(text);//TODO: дописать замену выражения на новое
        }

        static string DeleteBrackets(Match match) => match.ToString().Substring(1, match.Length - 2);

        static double DecisionSign(double s1,double s2, string sign)
        {
            switch (sign)//TODO: сделать тдельной функцией
            {
                case "+":
                    return s1 + s2;
                case "-":
                    return s1 - s2;
                case "*":
                    return s1 * s2;
                case "/":
                    return s1 / s2;
                default:
                    return 0;
            }
        }
    }
}
