using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask04
{
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            string fileName = "test01.txt";

            Task04 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 2);

        }

        [Test]
        public void Part01()
        {
            string fileName = "input.txt";

            Task04 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 455);

        }

        [Test]
        public void Test2()
        {
            string fileName = "test02.txt";

            Task04 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 3);

        }

        [Test]
        public void Part02()
        {
            string fileName = "input.txt";

            Task04 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 186);

        }

    }
}