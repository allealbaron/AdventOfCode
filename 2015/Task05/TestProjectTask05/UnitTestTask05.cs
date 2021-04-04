using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask05
{
    public class Tests
    {

        [Test]
        public void ContainsAtLeastThreeVowels1()
        {

            Assert.AreEqual(Task05.ContainsAtLeastThreeVowels("xazegov"), true);

        }
        
        [Test]
        public void ContainsAtLeastThreeVowels2()
        {

            Assert.AreEqual(Task05.ContainsAtLeastThreeVowels("aeiouaeiouaeiou"), true);

        }

        [Test]
        public void ContainsAtLeastThreeVowels3()
        {

            Assert.AreEqual(Task05.ContainsAtLeastThreeVowels("z"), false);

        }

        [Test]
        public void ContainsRepeatedChar1()
        {

            Assert.AreEqual(Task05.ContainsRepeatedChar("xx"), true);

        }

        [Test]
        public void ContainsRepeatedChar2()
        {

            Assert.AreEqual(Task05.ContainsRepeatedChar("abcdde"), true);

        }

        [Test]
        public void ContainsRepeatedChar3()
        {

            Assert.AreEqual(Task05.ContainsRepeatedChar("aabbccdd"), true);

        }

        [Test]
        public void ContainsRepeatedChar4()
        {

            Assert.AreEqual(Task05.ContainsRepeatedChar("abcdefghi"), false);

        }

        [Test]
        public void ContainsForbiddenStrings1()
        {

            Assert.AreEqual(Task05.ContainsForbiddenStrings("abcdefghi"), true);

        }


        [Test]
        public void ContainsForbiddenStrings2()
        {

            Assert.AreEqual(Task05.ContainsForbiddenStrings("xbcxefghi"), false);

        }

        [Test]
        public void IsNice1()
        {

            Assert.AreEqual(Task05.IsNice("ugknbfddgicrmopn"), true);

        }

        [Test]
        public void IsNice2()
        {

            Assert.AreEqual(Task05.IsNice("jchzalrnumimnmhp"), false);

        }

        [Test]
        public void IsNice3()
        {

            Assert.AreEqual(Task05.IsNice("haegwjzuvuyypxyu"), false);

        }

        [Test]
        public void IsNice4()
        {

            Assert.AreEqual(Task05.IsNice("dvszwmarrgswjxmb"), false);

        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task05 t = new (file);

            Assert.AreEqual(t.FirstPart(), 255);

        }

        [Test]
        public void ContainsRepeatedCharWithMiddle1()
        {

            Assert.AreEqual(Task05.ContainsRepeatedCharWithMiddle("xyx"), true);

        }

        [Test]
        public void ContainsRepeatedCharWithMiddle2()
        {

            Assert.AreEqual(Task05.ContainsRepeatedCharWithMiddle("aaa"), true);

        }

        [Test]
        public void ContainsRepeatedCharWithMiddle3()
        {

            Assert.AreEqual(Task05.ContainsRepeatedCharWithMiddle("abc"), false);

        }

        [Test]
        public void ContainsRepeatedPair1()
        {

            Assert.AreEqual(Task05.ContainsRepeatedPair("xyxy"), true);

        }

        [Test]
        public void ContainsRepeatedPair2()
        {

            Assert.AreEqual(Task05.ContainsRepeatedPair("aabcdefgaa"), true);

        }

        [Test]
        public void ContainsRepeatedPair3()
        {

            Assert.AreEqual(Task05.ContainsRepeatedPair("aaa"), false);

        }

        [Test]
        public void IsNiceSecondPart1()
        {

            Assert.AreEqual(Task05.IsNiceSecondPart("qjhvhtzxzqqjkmpb"), true);

        }

        [Test]
        public void IsNiceSecondPart2()
        {

            Assert.AreEqual(Task05.IsNiceSecondPart("xxyxx"), true);

        }

        [Test]
        public void IsNiceSecondPart3()
        {

            Assert.AreEqual(Task05.IsNiceSecondPart("uurcxstgmygtbstg"), false);

        }

        [Test]
        public void IsNiceSecondPart4()
        {

            Assert.AreEqual(Task05.IsNiceSecondPart("ieodomkazucvgmuy"), false);

        }

        [Test]
        public void Part02()
        {
            string file = "input.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.SecondPart(), 55);

        }
    }
}