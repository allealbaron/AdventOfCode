using NUnit.Framework;
using AdventOfCode.Year2022;

namespace TestProjectTask07
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.GetSizeSubFolder("/a/e"), 584);

        }

        [Test]
        public void Part01Test02()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.GetSizeSubFolder("/a"), 94853);

        }

        [Test]
        public void Part01Test03()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.GetSizeSubFolder("/d"), 24933642);

        }

        [Test]
        public void Part01Test04()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.GetSizeSubFolder("/"), 48381165);

        }

        [Test]
        public void Part01Test05()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.FirstPart(), 95437);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1543140);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.SecondPart(), 24933642);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task07 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1117448);

        }

    }
}