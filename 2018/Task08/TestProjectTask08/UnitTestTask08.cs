using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask08
{
    public class Tests
    {

        [Test]
        public void Test0101()
        {
            string file = "test01.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.FirstPart(), 138);
        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task08 t = new (file);

            Assert.AreEqual(t.FirstPart(), 49426);
        }

        [Test]
        public void Test0201()
        {
            string file = "test01.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.GetNodeValue(2), 33);
        }

        [Test]
        public void Test0202()
        {
            string file = "test01.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.GetNodeValue(4), 99);
        }

        [Test]
        public void Test0203()
        {
            string file = "test01.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.GetNodeValue(3), 0);
        }

        [Test]
        public void Test0204()
        {
            string file = "test01.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.GetNodeValue(1), 66);
        }

        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.SecondPart(), 40688);
        }


    }
}