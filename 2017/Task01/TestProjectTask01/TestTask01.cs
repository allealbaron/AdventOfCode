using NUnit.Framework;
using AdventOfCode;
 

namespace TestProjectTask01
{
    public class Tests
    {

        [Test]
        public void Test1()
        {

            string fileName = "test01.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 3);

        }

        [Test]
        public void Test2()
        {

            string fileName = "test02.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 4);

        }

        [Test]
        public void Test3()
        {

            string fileName = "test03.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 0);

        }

        [Test]
        public void Test4()
        {

            string fileName = "test04.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 9);

        }

        [Test]
        public void Part01()
        {

            string fileName = "input.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.FirstPart(), 1182);

        }

        [Test]
        public void Test5()
        {

            string fileName = "test05.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 6);

        }

        [Test]
        public void Test6()
        {

            string fileName = "test06.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 0);

        }

        [Test]
        public void Test7()
        {

            string fileName = "test07.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 4);

        }

        [Test]
        public void Test8()
        {

            string fileName = "test08.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 12);

        }

        [Test]
        public void Test9()
        {

            string fileName = "test09.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 4);

        }

        [Test]
        public void Part02()
        {

            string fileName = "input.txt";

            Task01 t = new(fileName);

            Assert.AreEqual(t.SecondPart(), 1152);

        }


    }
}