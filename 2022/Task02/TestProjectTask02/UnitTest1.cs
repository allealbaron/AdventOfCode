using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 15);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 8392);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 12);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 10116);

        }

    }
}