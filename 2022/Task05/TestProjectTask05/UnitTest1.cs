using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask05
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.FirstPart(), "CMZ");

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.FirstPart(), "TLNGFGMFN");

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.SecondPart(), "MCD");

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.SecondPart(), "FGLQJCMBD");

        }

    }
}