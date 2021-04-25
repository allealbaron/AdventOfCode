using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Test0101()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 3500);

        }

        [Test]
        public void Test0102()
        {

            string file = "TestInput2.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 2);

        }

        [Test]
        public void Test0103()
        {

            string file = "TestInput3.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 2);

        }

        [Test]
        public void Test0104()
        {

            string file = "TestInput4.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 2);

        }

        [Test]
        public void Test0105()
        {

            string file = "TestInput5.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 30);

        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 3895705);
        }

        [Test]
        public void Test0201()
        {

           // Assert.AreEqual(Task02.CalculateFuelSecondPart(14), 2);
        }

      
        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 6417);
        }


    }
}