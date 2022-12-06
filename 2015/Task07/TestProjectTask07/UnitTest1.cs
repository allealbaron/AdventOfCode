using NUnit.Framework;
using AdventOfCode.Year2015;

namespace TestProjectTask07
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            
            Task07 t = new(file);

            Assert.AreEqual(t.FirstPart(), 0);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.FirstPart(), 3176);
            
        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.SecondPart(0), 0);
            
        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.SecondPart(3176), 14710);
            
        }

    }
}