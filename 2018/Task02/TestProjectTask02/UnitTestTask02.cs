using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Testabcdef()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("abcdef", 2), false);
        }

        [Test]
        public void Testbababc()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("bababc", 2), true);
        }

        [Test]
        public void Testabbcde()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("abbcde", 2), true);
        }

        [Test]
        public void Testabcccd()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("abcccd", 2), false);
        }

        [Test]
        public void Testaabcdd()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("aabcdd", 2), true);
        }

        [Test]
        public void Testabcdee()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("abcdee", 2), true);
        }

        [Test]
        public void Testababab()
        {

            Assert.AreEqual(Task02.ContainRepeatedChars("ababab", 2), false);
        }

        [Test]
        public void Test01()
        {

            string file = "test01.txt";

            Task02 t = new (file);

            Assert.AreEqual(t.FirstPart(), 12);
        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task02 t = new (file);

            Assert.AreEqual(t.FirstPart(), 7134);
        }

        [Test]
        public void Test0201()
        {

            Assert.AreEqual(Task02.GetNumberDifferentCharacters("abcde", "axcye"), 2);
        }

        [Test]
        public void Test0202()
        {

            Assert.AreEqual(Task02.GetNumberDifferentCharacters("fghij", "fguij"), 1);
        }

        [Test]
        public void Test02()
        {

            string file = "test02.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), "fgij");
        }

        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), "kbqwtcvzhmhpoelrnaxydifyb");
        }


    }
}