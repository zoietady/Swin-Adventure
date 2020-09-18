using NUnit.Framework;
using SwinAdventure;

namespace ItemTest
{
    [TestFixture()]
    public class Tests
    {
        Item itm;

        [SetUp]
        public void Init()
        {
            itm = new Item(new string[] { "sword", "long sword" }, "ss", "very nice sword");
        }

        [Test()]
        public void IdTest()
        {
            Assert.AreEqual(itm.AreYou("sword"), true);
        }

        [Test()]
        public void ShortDesc()
        {
            Assert.AreEqual(itm.ShortDescription, "a ss (sword)");
        }

        [Test()]
        public void FullDesc()
        {
            Assert.AreEqual(itm.FullDescription, "very nice sword");
        }
    }
}