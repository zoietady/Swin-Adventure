using NUnit.Framework;
using SwinAdventure;

namespace BagTest
{
    public class Tests
    {
        Bag b, b1, b2;
        Item itm, itm1;

       [SetUp]
        public void Setup()
        {
            b = new Bag(new string[] { "bag", "nice bag" }, "small brown leather bag", "its nice");
            b1 = new Bag(new string[] { "bag1", "nice bag" }, "small brown leather bag", "its nice");
            b2 = new Bag(new string[] { "bag2", "nicer bag" }, "small blue leather bag", "its nicer");

            itm = new Item(new string[] { "sword", "long sword" }, "ss", "very nice sword");
            itm1 = new Item(new string[] { "pants", "short pants" }, "pp", "very nice pants");

            b.Inventory.Put(itm);
            b1.Inventory.Put(itm);
            b1.Inventory.Put(b2);
            b2.Inventory.Put(itm1);
        }

        [Test]
        public void LocateItem()
        {
            Assert.AreEqual(itm, b.Locate("sword"));
        }

        [Test]
        public void LocateSelf()
        {
            Assert.AreEqual(b, b.Locate("bag"));
        }

        [Test]
        public void LocateNothing()
        {
            Assert.AreEqual(null, b.Locate("nop"));
        }

        [Test]
        public void FullDesc()
        {
            Assert.AreEqual("In the small brown leather bag you can see:\n\ta ss (sword)\n", b.FullDescription);
        }

        [Test]
        public void BagInBag()
        {
            Assert.AreEqual(b2, b1.Locate("bag2"));
        }

        [Test]
        public void ItemBagInBag()
        {
            Assert.AreEqual(itm, b1.Locate("sword"));
        }

        [Test]
        public void NotBagInBag()
        {
            Assert.Pass(null,b1.Locate("pants"));
        }
    }
}