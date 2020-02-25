using System;
using System.Text.RegularExpressions;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DecisionSignCheck()
        {
            var result = Program.DecisionSign(3.1, 4.3, "+");
            Assert.AreEqual(7.4, result);
        }
        [TestMethod]
        public void DeleteBracketsCheck()
        {
            Regex regex = new Regex(@"\(.*?\)");
            var s = "(aaaa)";
            var result = Program.DeleteBrackets(regex.Match(s));
            Assert.AreEqual("aaaa", result);
        }
        [TestMethod]
        public void FindBracketsCheck()
        {
            Regex regex = new Regex(@"\(.*\)");
            var s1 = "(3+2)";
            var s2 = "(4*(7+1))";
            var s3 = "((4+1)/(2+3))";
            Assert.AreEqual("5", Program.FindBrackets(s1, regex));
            Assert.AreEqual("32", Program.FindBrackets(s2, regex));
            Assert.AreEqual("1", Program.FindBrackets(s3, regex));
        }
        [TestMethod]
        public void DecisionBracketsCheck()
        {
            var s1 = "3+2";
            Assert.AreEqual(5, Program.DecisionBrackets(s1));
        }
        [TestMethod]
        public void ReplaceTheBracketCheck()
        {
            Regex regex = new Regex(@"\(.*?\)");
            var s = "(14+2)+3";
            var number = 16;

            Assert.AreEqual("16+3", Program.ReplaceTheBracket(number, s, regex.Match(s)));
        }
    }
}
