using NUnit.Framework;
using AdventOfCode;

namespace TestProjectTask04
{
    public class Tests
    {

        [Test]
        public void Part01Test01()
        {
            Room r = new("aaaaa-bbb-z-y-x-123[abxyz]");

            Assert.AreEqual(r.IsValid(), true);

        }

        [Test]
        public void Part01Test02()
        {
            Room r = new("a-b-c-d-e-f-g-h-987[abcde]");

            Assert.AreEqual(r.IsValid(), true);

        }

        [Test]
        public void Part01Test03()
        {
            Room r = new("not-a-real-room-404[oarel]");

            Assert.AreEqual(r.IsValid(), true);

        }

        [Test]
        public void Part01Test04()
        {
            Room r = new("totally-real-room-200[decoy]");

            Assert.AreEqual(r.IsValid(), false);

        }

        [Test]
        public void Part01Test05()
        {

            Task04 t = new ("test01.txt");

            Assert.AreEqual(t.FirstPart(), 1514);

        }


        [Test]
        public void Part01()
        {
            Task04 t = new("input.txt");

            Assert.AreEqual(t.FirstPart(), 158835);

        }

        [Test]
        public void Part02Test01()
        {
            Room r = new("qzmt-zixmtkozy-ivhz-343[abcde]");

            Assert.AreEqual(r.DecryptName(), "very encrypted name");

        }


        [Test]
        public void Part02()
        {

            Task04 t = new("input.txt");

            Assert.AreEqual(t.SecondPart(), 993);

        }
    }
}