using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask08
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string fileName = "test01.txt";

            Task08 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 1);

        }

        [Test]
        public void Part01()
        {
            string fileName = "input.txt";

            Task08 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 5102);

        }

        [Test]
        public void Test2()
        {
            string fileName = "test01.txt";

            Task08 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 10);

        }

        [Test]
        public void Part02()
        {
            string fileName = "input.txt";

            Task08 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 6056);

        }
    }
}