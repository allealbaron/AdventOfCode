using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {
            string file = "TestInput.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.FirstPart(), 7);

        }


        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.FirstPart(), 247);

        }

        [Test]
        public void Part02Test01()
        {
            string file = "TestInput.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.SecondPart(), 336);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2983070376);

        }

    }
}