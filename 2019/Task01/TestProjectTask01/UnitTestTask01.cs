using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask01
{
    public class Tests
    {

        [Test]
        public void Test0101()
        {

            Assert.AreEqual(Task01.CalculateFuelFirstPart(12), 2);
        }

        [Test]
        public void Test0102()
        {

            Assert.AreEqual(Task01.CalculateFuelFirstPart(14), 2);
        }

        [Test]
        public void Test0103()
        {

            Assert.AreEqual(Task01.CalculateFuelFirstPart(1969), 654);
        }

        [Test]
        public void Test0104()
        {

            Assert.AreEqual(Task01.CalculateFuelFirstPart(100756), 33583);
        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.FirstPart(), 3317100);
        }

        [Test]
        public void Test0201()
        {

            Assert.AreEqual(Task01.CalculateFuelSecondPart(14), 2);
        }

        [Test]
        public void Test0202()
        {

            Assert.AreEqual(Task01.CalculateFuelSecondPart(1969), 966);
        }

        [Test]
        public void Test0203()
        {

            Assert.AreEqual(Task01.CalculateFuelSecondPart(100756), 50346);
        }


        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task01 t = new(file);

            Assert.AreEqual(t.SecondPart(), 4972784);
        }


    }
}