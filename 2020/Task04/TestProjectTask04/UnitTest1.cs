using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask03
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {
            string file = "TestInput.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.FirstPart(), 2);

        }


        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.FirstPart(), 228);

        }

        [Test]
        public void Part02Test01()
        {
            string file = "TestInput.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2);

        }

        [Test]
        public void Part02Test02()
        {
            string file = "ValidPassports.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 4);

        }

        [Test]
        public void Part02Test03()
        {
            string file = "InvalidPassports.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 0);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 175);

        }

    }
}