using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask07
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string fileName = "test01.txt";

            Task07 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), "tknk");

        }

        [Test]
        public void Part01()
        {
            string fileName = "input.txt";

            Task07 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), "vmpywg");

        }

        [Test]
        public void Test2()
        {
            string fileName = "test01.txt";

            Task07 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 60);

        }

        [Test]
        public void Part02()
        {
            string fileName = "input.txt";

            Task07 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 1674);

        }
    }
}