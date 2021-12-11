using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask11
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.ExecuteSteps(10), 204);

        }

        [Test]
        public void Part01Test02()
        {

            string file = "TestInput.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1656);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1793);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.SecondPart(), 195);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.SecondPart(), 247);

        }

    }
}