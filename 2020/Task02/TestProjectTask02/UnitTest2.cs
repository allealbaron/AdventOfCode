using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 2);

        }

        [Test]
        public void Part01Test02()
        {

            PasswordPolicy pp = new() {  Character = 'a', MinValue = 1, MaxValue = 3,  PassWord= "abcde"};

            Assert.AreEqual(pp.IsValidFirstPart(), true);

        }

        [Test]
        public void Part01Test03()
        {

            PasswordPolicy pp = new() { Character = 'b', MinValue = 1, MaxValue = 3,  PassWord = "cdefg" };

            Assert.AreEqual(pp.IsValidFirstPart(), false);

        }

        [Test]
        public void Part01Test04()
        {

            PasswordPolicy pp = new() { Character = 'c', MinValue = 2,  MaxValue = 9, PassWord = "ccccccccc" };

            Assert.AreEqual(pp.IsValidFirstPart(), true);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 536);

        }

        [Test]
        public void Part02Test01()
        {

            string file = "TestInput.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 1);

        }

        [Test]
        public void Part02Test02()
        {

            PasswordPolicy pp = new() { Character = 'a', MinValue = 1, MaxValue = 3, PassWord = "abcde" };

            Assert.AreEqual(pp.IsValidSecondPart(), true);

        }

        [Test]
        public void Part02Test03()
        {

            PasswordPolicy pp = new() { Character = 'b', MinValue = 1, MaxValue = 3, PassWord = "cdefg" };

            Assert.AreEqual(pp.IsValidSecondPart(), false);

        }

        [Test]
        public void Part02Test04()
        {

            PasswordPolicy pp = new() { Character = 'c', MinValue = 2, MaxValue = 9, PassWord = "ccccccccc" };

            Assert.AreEqual(pp.IsValidSecondPart(), false);

        }

        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 558);

        }

    }
}