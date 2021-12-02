using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 150);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 2036120);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 900);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2015547716);

        }

    }
}