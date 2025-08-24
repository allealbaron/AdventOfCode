using Task02;

namespace TestProjectTask02;

    public class Tests
    {
        private const string TestFile = @"C:\Personal\AdventOfCode\2024\Input\Test.txt";
        private const string InputFile = @"C:\Personal\AdventOfCode\2024\Input\Input.txt";

    [Test]
        public void Test1Part1()
        {

            Program t = new(TestFile);

            Assert.That(t.Part01(), Is.EqualTo(2));
        
        }

        [Test]
        public void Test2Part1()
        {

            Program t = new(InputFile);

            Assert.That(t.Part01(), Is.EqualTo(242));

        }

        [Test]
        public void Test1Part2()
        {
            Program t = new(TestFile);

            Assert.That(t.Part02(), Is.EqualTo(4));

        }

        [Test]
        public void Test2Part2()
        {
            Program t = new(InputFile);

            Assert.That(t.Part02(), Is.EqualTo(311));

        }

}