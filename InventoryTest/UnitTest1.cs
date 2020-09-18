using NUnit.Framework;
using SwinAdventure;

namespace InventoryTest
{
    public class Tests
    {
        Inventory inv;
        Item itm, itm1, itm2;

        [SetUp]
        public void Setup()
        {
            inv = new Inventory();
            itm = new Item(new string[] { "sword", "long sword" }, "ss", "very nice sword");
            inv.Put(itm);
            itm1 = new Item(new string[] { "bag", "big bag" }, "bb", "very nice bag");
            inv.Put(itm1);
            itm2 = new Item(new string[] { "pants", "short pants" }, "pp", "very nice pants");
            inv.Put(itm2);
        }

        [Test]
        public void HasItem()
        {
            Assert.AreEqual(inv.HasItem("sword"), true);
        }

        [Test]
        public void NoItem()
        {
            Assert.AreEqual(inv.HasItem("spord"), false);
        }

        [Test]
        public void TakeItem()
        {
            inv.Take("sword");

            Assert.AreEqual(inv.HasItem("sword"), false);
        }

        [Test]
        public void ItemList()
        {
            inv.Take("sword");
            string ilist = "\ta bb (bag)\n\ta pp (pants)\n";

            Assert.AreEqual(inv.ItemList, ilist);
        }
    }
}