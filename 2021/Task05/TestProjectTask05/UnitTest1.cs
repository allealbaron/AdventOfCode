using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask05
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.FirstPart(), 5);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.FirstPart(), 4826);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.SecondPart(), 12);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.SecondPart(), 16793);

        }

    }
}