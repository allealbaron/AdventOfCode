using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask07
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.FirstPart(), 37);

        }

        [Test]
        public void Part01Test02()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.CalculateFuel(2), 37);

        }

        [Test]
        public void Part01Test03()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.CalculateFuel(1), 41);

        }

        [Test]
        public void Part01Test04()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.CalculateFuel(3), 39);

        }

        [Test]
        public void Part01Test05()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.CalculateFuel(10), 71);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.FirstPart(), 333755);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.SecondPart(), 168);

        }

        [Test]
        public void Part02Test02()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.CalculateFuelCrabMethod(5), 168);

        }

        [Test]
        public void Part02Test03()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.CalculateFuelCrabMethod(2), 206);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.SecondPart(), 94017638);

        }

    }
}