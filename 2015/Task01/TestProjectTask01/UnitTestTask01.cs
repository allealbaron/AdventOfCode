using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask01
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            Assert.AreEqual(Task01.DecodeSymbol('('), 1);

        }

        [Test]
        public void Part01Test02()
        {

            Assert.AreEqual(Task01.DecodeSymbol(')'), -1);

        }

        [Test]
        public void Part01Test03()
        {

            string file = "TestInput.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 3);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 138);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput02.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 5);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1771);

        }

    }
}