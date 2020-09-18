using NUnit.Framework;
using SwinAdventure;

namespace PlayerTest
{
    public class Tests
    {
        Player plyr;
        Item itm, itm1, itm2;

        [SetUp]
        public void Setup()
        {
            plyr = new Player("test", "just another test");
            itm = new Item(new string[] { "sword", "long sword" }, "ss", "very nice sword");
            plyr.Inventory.Put(itm);
            itm1 = new Item(new string[] { "bag", "big bag" }, "bb", "very nice bag");
            plyr.Inventory.Put(itm1);
            itm2 = new Item(new string[] { "pants", "short pants" }, "pp", "very nice pants");
            plyr.Inventory.Put(itm2);
        }

        [Test]
        public void IdentifiableByMe()
        {
            Assert.AreEqual(plyr.AreYou("Me"), true);
        }

        [Test]
        public void IdentifiableByInventory()
        {
            Assert.AreEqual(plyr.AreYou("Inventory"), true);
        }

        [Test]
        public void LoacteItem()
        {
            Assert.AreEqual(plyr.Locate("sword"), itm);
        }

        [Test]
        public void LocateMe()
        {
            Assert.AreEqual(plyr.Locate("me"), plyr);
        }

        [Test]
        public void LocateNull()
        {
            Assert.AreEqual(plyr.Locate("h"), null);
        }

        [Test]
        public void FullDesc()
        {
            string ilist = "You are test the just another test\nYou are Carrying: \n\ta ss (sword)\n\ta bb (bag)\n\ta pp (pants)\n";
            Assert.AreEqual(plyr.FullDescription, ilist);
        }
    }
}