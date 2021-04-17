using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask02
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            ChristmasPackage c = new()
                            {   Height = 2, 
                                Length = 3, 
                                Width = 4 };
            

            Assert.AreEqual(c.GetWrapping(), 58);

        }

        [Test]
        public void Part01Test02()
        {

            ChristmasPackage c = new()
            {
                Height = 1,
                Length = 1,
                Width = 10
            };


            Assert.AreEqual(c.GetWrapping(), 43);

        }

        [Test]
        public void Part01()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.FirstPart(), 1586300);

        }

        [Test]
        public void Part02Test01()
        {

            ChristmasPackage c = new()
            {
                Height = 2,
                Length = 3,
                Width = 4
            };


            Assert.AreEqual(c.GetRibbonLength(), 34);

        }

        [Test]
        public void Part02Test02()
        {

            ChristmasPackage c = new()
            {
                Height = 1,
                Length = 1,
                Width = 10
            };


            Assert.AreEqual(c.GetRibbonLength(), 14);

        }
        [Test]
        public void Part02()
        {

            string file = "Input.txt";

            Task02 t = new(file);

            Assert.AreEqual(t.SecondPart(), 3737498);

        }

    }
}