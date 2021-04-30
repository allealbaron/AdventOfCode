using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask05
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            Assert.AreEqual(Task05.HasFiveZeroes("abc3231929") , true);

        }

        [Test]
        public void Part01Test02()
        {

            Task05 t = new("abc");

            Assert.AreEqual(t.FirstPart(), "18f47a30");

        }


        [Test]
        public void Part01()
        {

            Task05 t = new("ugkcyxxp");

            Assert.AreEqual(t.FirstPart(), "d4cd2ee1");

        }

        [Test]
        public void Part02Test01()
        {

            Task05 t = new("abc");

            Assert.AreEqual(t.SecondPart(), "05ace8e3");

        }


        [Test]
        public void Part02()
        {

            Task05 t = new("ugkcyxxp");

            Assert.AreEqual(t.SecondPart(), "f2c730e5");

        }
    }
}