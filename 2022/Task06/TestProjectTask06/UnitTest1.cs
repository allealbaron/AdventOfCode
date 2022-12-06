using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask06
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 7);

        }

        [Test]
        public void Part01Test02()
        {

            string file = "TestInput02.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 5);

        }

        [Test]
        public void Part01Test03()
        {

            string file = "TestInput03.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 6);

        }

        [Test]
        public void Part01Test04()
        {

            string file = "TestInput04.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 10);

        }

        [Test]
        public void Part01Test05()
        {

            string file = "TestInput05.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 11);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1912);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 19);

        }

        [Test]
        public void Part02Test02()
        {

            string file = "TestInput02.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 23);

        }

        [Test]
        public void Part02Test03()
        {

            string file = "TestInput03.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 23);

        }

        [Test]
        public void Part02Test04()
        {

            string file = "TestInput04.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 29);

        }

        [Test]
        public void Part02Test05()
        {

            string file = "TestInput05.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 26);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2122);

        }

    }
}