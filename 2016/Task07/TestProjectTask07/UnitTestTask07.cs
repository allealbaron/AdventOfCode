using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask07
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {

            IP ip = new("abba[mnop]qrst");

            Assert.AreEqual(ip.IsValidForABBA(), true);

        }

        [Test]
        public void Part01Test02()
        {

            IP ip = new("abcd[bddb]xyyx");

            Assert.AreEqual(ip.IsValidForABBA(), false);

        }


        [Test]
        public void Part01Test03()
        {

            IP ip = new("aaaa[qwer]tyui");

            Assert.AreEqual(ip.IsValidForABBA(), false);

        }

        [Test]
        public void Part01Test04()
        {

            IP ip = new("ioxxoj[asdfgh]zxcvbn");

            Assert.AreEqual(ip.IsValidForABBA(), true);

        }

         [Test]
        public void Part01()
        {
            Task07 t = new("input.txt");

            Assert.AreEqual(t.FirstPart(), 110);

        }

        [Test]
        public void Part02Test01()
        {

            IP ip = new("aba[bab]xyz");

            Assert.AreEqual(ip.IsValidForABA(), true);

        }

        [Test]
        public void Part02Test02()
        {

            IP ip = new("xyx[xyx]xyx");

            Assert.AreEqual(ip.IsValidForABA(), false);

        }

        [Test]
        public void Part02Test03()
        {

            IP ip = new("aa[kek]eke");

            Assert.AreEqual(ip.IsValidForABA(), true);

        }

        [Test]
        public void Part02Test04()
        {

            IP ip = new("zazbz[bzb]cdb");

            Assert.AreEqual(ip.IsValidForABA(), true);

        }


        [Test]
        public void Part02()
        {

            Task07 t = new("input.txt");

            Assert.AreEqual(t.SecondPart(), 242);

        }
    }
}