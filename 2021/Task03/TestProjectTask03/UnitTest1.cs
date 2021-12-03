using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask03
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.FirstPart(), 198);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.FirstPart(), 3148794);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.SecondPart(), 230);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task03 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2795310);

        }

    }
}