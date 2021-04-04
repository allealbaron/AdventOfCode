using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask04
{
    public class Tests
    {
        [Test]
        public void TestGetHash1()
        {

            Assert.AreEqual(Task04.GetHash("abcdef609043").Substring(0,5), "00000");

        }

        [Test]
        public void TestGetHash2()
        {

            Assert.AreEqual(Task04.GetHash("pqrstuv1048970").Substring(0, 5), "00000");

        }

        [Test]
        public void HasFiveZeroes1()
        {

            Assert.AreEqual(Task04.HasFiveZeroes("abcdef609043"), true);

        }

        [Test]
        public void HasFiveZeroes2()
        {

            Assert.AreEqual(Task04.HasFiveZeroes("pqrstuv1048970"), true);

        }

        [Test]
        public void Part01()
        {

            Assert.AreEqual(Task04.FirstPart(Task04.INPUT), 282749);

        }

        [Test]
        public void Part02()
        {

            Assert.AreEqual(Task04.SecondPart(Task04.INPUT), 9962624);

        }
    }
}