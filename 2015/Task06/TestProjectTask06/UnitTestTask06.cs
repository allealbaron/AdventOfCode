using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask06
{
    public class Tests
    {
        [Test]
        public void TestPart0101()
        {

            string file = "test01.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), Task06.ROW_SIDE * Task06.ROW_SIDE);

        }

        [Test]
        public void TestPart0102()
        {

            string file = "test02.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), (Task06.ROW_SIDE * Task06.ROW_SIDE) - 1000);

        }

        [Test]
        public void TestPart0103()
        {

            string file = "test03.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.FirstPart(), (Task06.ROW_SIDE * Task06.ROW_SIDE) - 4);

        }


        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task06 t = new (file);

            Assert.AreEqual(t.FirstPart(), 569999);

        }

        [Test]
        public void TestPart0201()
        {

            string file = "test01.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), (Task06.ROW_SIDE * Task06.ROW_SIDE));

        }

        [Test]
        public void TestPart0202()
        {

            string file = "test04.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1);

        }

        [Test]
        public void TestPart0203()
        {

            string file = "test05.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 2000000);

        }       

        [Test]
        public void Part02()
        {
            string file = "input.txt";

            Task06 t = new(file);

            Assert.AreEqual(t.SecondPart(), 17836115);

        }
    }
}