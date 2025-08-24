using Task01;

namespace TestProjectTask01;

    public class Tests
    {
        private const string TestFile = @"C:\Personal\AdventOfCode\2024\Input\Test.txt";
        private const string InputFile = @"C:\Personal\AdventOfCode\2024\Input\Input.txt";

    [Test]
        public void Test1Part1()
        {

            Program t = new(TestFile);

            Assert.That(t.CalculateTotalDistance(), Is.EqualTo(11));
        
        }

        [Test]
        public void Test2Part1()
        {

            Program t = new(InputFile);

            Assert.That(t.CalculateTotalDistance(), Is.EqualTo(2430334));

        }

        [Test]
        public void Test1Part2()
        {
            Program t = new(TestFile);

            Assert.That(t.CalculateSimilarity(), Is.EqualTo(31));

        }

        [Test]
        public void Test2Part2()
        {
            Program t = new(InputFile);

            Assert.That(t.CalculateSimilarity(), Is.EqualTo(28786472));

        }

}