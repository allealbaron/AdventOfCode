using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask02
{
    public class Tests
    {
        [Test]
        public void Test1()
        {

            string fileName = "test01.txt";

            Task02 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 18);

        }

        [Test]
        public void Part01()
        {

            string fileName = "input.txt";

            Task02 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 39126);

        }

        [Test]
        public void Test2()
        {

            string fileName = "test02.txt";

            Task02 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 9);

        }

        [Test]
        public void Part02()
        {

            string fileName = "input.txt";

            Task02 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 258);

        }

    }
}