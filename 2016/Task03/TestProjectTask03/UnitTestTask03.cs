using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask03
{
    public class Tests
    {

        [Test]
        public void TriangleFalse()
        {
            Triangle t = new() { Sides = { 5,10,25} };

            Assert.AreEqual(t.Validate(), false);

        }

        [Test]
        public void Part01()
        {
            Task03 t = new("input.txt",1);

            Assert.AreEqual(t.FirstPart(), 1050);

        }

        [Test]
        public void TestPart02()
        {
            Task03 t = new("test02.txt", 2);

            Assert.AreEqual(t.SecondPart(), 6);

        }


        [Test]
        public void Part02()
        {

            Task03 t = new("input.txt",2);

            Assert.AreEqual(t.SecondPart(), 1921);

        }
    }
}