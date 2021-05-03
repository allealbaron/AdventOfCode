using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask01
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 514579);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 786811);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 241861950);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 199068980);

        }

    }
}