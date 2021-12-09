using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask09
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task09 t = new(file);

            Assert.AreEqual(t.FirstPart(), 15);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task09 t = new(file);

            Assert.AreEqual(t.FirstPart(), 575);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task09 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1134);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task09 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1019700);

        }

    }
}