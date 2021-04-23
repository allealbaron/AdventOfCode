using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask04
{
    public class Tests
    {

        [Test]
        public void Test01()
        {

            string file = "test01.txt";

            Task04 t = new (file);

            Assert.AreEqual(t.FirstPart(), 24 *10 );
        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task04 t = new (file);

            Assert.AreEqual(t.FirstPart(), 101262);
        }

        [Test]
        public void Test02()
        {

            string file = "test01.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 99 * 45);
        }

        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task04 t = new(file);

            Assert.AreEqual(t.SecondPart(), 71976);
        }


    }
}