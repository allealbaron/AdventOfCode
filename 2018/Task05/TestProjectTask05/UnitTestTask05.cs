using NUnit.Framework;
using AdventOfCode;
using System;

namespace TestProjectTask05
{
    public class Tests
    {

        [Test]
        public void Test0101()
        {

            Assert.AreEqual(Task05.ReduceString("aA"), String.Empty );
        }

        [Test]
        public void Test0102()
        {

            Assert.AreEqual(Task05.ReduceString("abBA"), String.Empty);
        }

        [Test]
        public void Test0103()
        {

            Assert.AreEqual(Task05.ReduceString("abAB"), "abAB");
        }

        [Test]
        public void Test0104()
        {

            Assert.AreEqual(Task05.ReduceString("aabAAB"), "aabAAB");
        }

        [Test]
        public void Test0105()
        {

            Assert.AreEqual(Task05.ReduceString("dabAcCaCBAcCcaDA"), "dabCBAcaDA");
        }

        [Test]
        public void Part01()
        {

            string file = "input.txt";

            Task05 t = new (file);

            Assert.AreEqual(t.FirstPart(), 10368);
        }

        [Test]
        public void Test0201()
        {

            Assert.AreEqual(Task05.GetMinimumReduce("dabAcCaCBAcCcaDA"), 4);
        }

        [Test]
        public void Part02()
        {

            string file = "input.txt";

            Task05 t = new(file);

            Assert.AreEqual(t.SecondPart(), 4122);
        }


    }
}