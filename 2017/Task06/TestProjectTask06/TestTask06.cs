using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask06
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string fileName = "test01.txt";

            Task06 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 5);

        }

        [Test]
        public void Part01()
        {
            string fileName = "input.txt";

            Task06 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 4074);

        }

        [Test]
        public void Test2()
        {
            string fileName = "test01.txt";

            Task06 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 4);

        }

        [Test]
        public void Part02()
        {
            string fileName = "input.txt";

            Task06 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 2793);

        }
    }
}