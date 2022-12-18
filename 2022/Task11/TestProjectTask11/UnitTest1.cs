using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask11
{
    public class Tests
    {

       [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.FirstPart(), 10605);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.FirstPart(), 67830);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2713310158);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task11 t = new(file);

            Assert.AreEqual(t.SecondPart(), 15305381442);

        }

    }
}