using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask07
{
    public class Tests
    {

        [Test]
        public void Test0101()
        {
            string file = "test01.txt";

            Task07 t = new(file, 0, 2);

            Assert.AreEqual(t.FirstPart(), "CABDFE");
        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task07 t = new (file, 60,5);

            Assert.AreEqual(t.FirstPart(), "BCEFLDMQTXHZGKIASVJYORPUWN");
        }

        [Test]
        public void Test0201()
        {
            string file = "test01.txt";

            Task07 t = new(file, 0, 2);

            Assert.AreEqual(t.SecondPart(), 15);
        }


        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task07 t = new(file, 60, 5);

            Assert.AreEqual(t.SecondPart(), 987);
        }


    }
}