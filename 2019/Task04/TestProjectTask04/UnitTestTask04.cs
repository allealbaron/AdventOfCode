using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask04
{
    public class Tests
    {
        [Test]
        public void TestTwoAdjacentTrue()
        {

            Assert.AreEqual(Task04.TwoAdjacent(111111), true);

        }

        [Test]
        public void TestTwoAdjacentFalse()
        {

            Assert.AreEqual(Task04.TwoAdjacent(123789), false);

        }

        [Test]
        public void TestIncreasingDigitsTrue()
        {

            Assert.AreEqual(Task04.IncreasingDigits(111111), true);

        }

        [Test]
        public void TestIncreasingDigitsFalse()
        {

            Assert.AreEqual(Task04.IncreasingDigits(223450), false);

        }

        [Test]
        public void Part01()
        {
            Task04 t = new();

            Assert.AreEqual(t.FirstPart(), 1650);

        }

        [Test]
        public void TestTwoAdjacentSecondPartTrue()
        {

            Assert.AreEqual(Task04.TwoAdjacentSecondPart(112233), true);

        }

        [Test]
        public void TwoAdjacentSecondPartFalse()
        {

            Assert.AreEqual(Task04.TwoAdjacentSecondPart(123444), false);

        }

        [Test]
        public void TestTwoAdjacentSecondPart2True()
        {

            Assert.AreEqual(Task04.TwoAdjacentSecondPart(111122), true);

        }

        [Test]
        public void Part02()
        {

            Task04 t = new();

            Assert.AreEqual(t.SecondPart(), 1129);

        }
    }
}