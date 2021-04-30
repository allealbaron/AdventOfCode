using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask06
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            Task06 t = new ("test01.txt");

            Assert.AreEqual(t.FirstPart(), "easter");

        }


        [Test]
        public void Part01()
        {
            Task06 t = new("input.txt");

            Assert.AreEqual(t.FirstPart(), "agmwzecr");

        }

        [Test]
        public void Part02Test01()
        {

            Task06 t = new("test01.txt");

            Assert.AreEqual(t.SecondPart(), "advent");

        }


        [Test]
        public void Part02()
        {

            Task06 t = new("input.txt");

            Assert.AreEqual(t.SecondPart(), "owlaxqvq");

        }
    }
}