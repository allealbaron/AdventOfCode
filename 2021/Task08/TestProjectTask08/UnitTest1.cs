using NUnit.Framework;
using AdventOfCode.Year2021;

namespace TestProjectTask08
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.FirstPart(), 26);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.FirstPart(), 318);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.SecondPart(), 61229);

        }

        [Test]
        public void Part02Test02()
        {

            SegmentInput si = new ("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
            
            Assert.AreEqual(si.GetValue(), 5353);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task08 t = new(file);

            Assert.AreEqual(t.SecondPart(), 996280);

        }

    }
}