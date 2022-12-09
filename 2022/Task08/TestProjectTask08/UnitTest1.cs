using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask08
{
    public class Tests
    {

       [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.FirstPart(), 21);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1859);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.SecondPart(), 8);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.SecondPart(), 332640);

        }

    }
}