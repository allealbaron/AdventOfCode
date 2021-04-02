using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask05
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string fileName = "test01.txt";

            Task05 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 5);

        }

        [Test]
        public void Part01()
        {
            string fileName = "input.txt";

            Task05 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 381680);

        }

        [Test]
        public void Test2()
        {
            string fileName = "test01.txt";

            Task05 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 10);

        }

        [Test]
        public void Part02()
        {
            string fileName = "input.txt";

            Task05 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 29717847);

        }
    }
}