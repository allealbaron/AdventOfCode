using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask04
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.FirstPart(), 4512);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.FirstPart(), 49860);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1924);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 24628);

        }

    }
}