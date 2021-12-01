using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask01
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 7);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1462);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 5);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1497);

        }

    }
}