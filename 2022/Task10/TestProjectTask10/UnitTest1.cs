using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask10
{
    public class Tests
    {

       [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task10 t = new(file);

            Assert.AreEqual(t.FirstPart(), 13140);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task10 t = new(file);

            Assert.AreEqual(t.FirstPart(), 13520);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task10 t = new(file);

            Assert.AreEqual(t.SecondPart(), 0);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task10 t = new(file);

            Assert.AreEqual(t.SecondPart(), 0);

        }

    }
}