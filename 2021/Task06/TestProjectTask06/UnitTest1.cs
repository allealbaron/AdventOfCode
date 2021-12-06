using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask06
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SimulateDays(18), 26);

        }

        [Test]
        public void Part01Test02()
        {

            string file = "TestInput.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 5934);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 390011);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 26984457539);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1746710169834);

        }

    }
}