using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        string FindBrackets(string text, Regex regex)
        {
            Match matches = regex.Match(text);
            if (matches.Success)
            {
                string newText = DeleteBrackets(matches);
                bool checkTrueFindOrNot = newText.IndexOf(')') < newText.IndexOf('(');
                Regex NewRegex = new Regex(@"\(.*?\)");
                if (checkTrueFindOrNot)
                {
                    MatchCollection matchCollection = NewRegex.Matches(text);
                    foreach (var m in matchCollection)
                    {
                        var output = FindBrackets(m.ToString(), regex);
                        if (checkTrueFindOrNot)
                            text = ReplaceTheBracket(Convert.ToDouble(output), text, NewRegex.Match(text));
                        else
                            text = ReplaceTheBracket(Convert.ToDouble(output), text, matches);
                    }
                    return text;
                }
                else
                {
                    var output = DecisionBrackets(FindBrackets(newText, regex));
                    if (checkTrueFindOrNot)
                        text = ReplaceTheBracket(Convert.ToDouble(output), text, NewRegex.Match(text));
                    else
                        text = ReplaceTheBracket(Convert.ToDouble(output), text, matches);
                    return text;
                }
            }
            var result = DecisionBrackets(text);
            return result.ToString();
        }

        string DeleteBrackets(Match match) => match.ToString().Substring(1, match.Length - 2);

        double DecisionSign(double s1, double s2, string sign)
        {
            switch (sign)
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

        string ReplaceTheBracket(double number, string text, Match match) => text.Replace(match.Value, number.ToString());

         double DecisionBrackets(string text)
        {
            Regex regex = new Regex(@"[+|\-|*|/]");
            MatchCollection matchCollection = regex.Matches(text);
            var numbers = new List<string>(text.Split('+', '-', '*', '/'));
            var signs = new List<string>();
            int positionInArray = 0;
            foreach (var match in matchCollection)
                signs.Add(match.ToString());

            while (signs.Count != 0)
            {
                if (signs.Count == 1)
                    return DecisionSign(Convert.ToDouble(numbers[0]), Convert.ToDouble(numbers[1]), signs[0]);
                else
                    try
                    {
                        for (positionInArray = 0; positionInArray < signs.Count; positionInArray++)
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
            return Convert.ToDouble(text);
        }
    }
}
