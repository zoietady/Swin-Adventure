using NUnit.Framework;
using SwinAdventure;

namespace LookCommandTest
{
    public class Tests
    {
        Player plyr, plyr2;
        Item itm, itm1;
        LookCommand look;
        Bag b,b2;

        [SetUp]
        public void Setup()
        {
            plyr = new Player("Player", "Test Player");
            plyr2 = new Player("Player2", "Test Player");
            itm = new Item(new string[] { "sword", "long sword" }, "ss", "very nice sword");
            itm1 = new Item(new string[] { "gem", "cool gem" }, "gg", "nice gem");
            b = new Bag(new string[] { "bag", "nice bag" }, "small brown leather bag", "its nice");
            b2 = new Bag(new string[] { "bag", "cool bag" }, "small black leather bag", "its okay");

            b.Inventory.Put(itm1);

            plyr.Inventory.Put(b);
            plyr.Inventory.Put(itm);
            plyr.Inventory.Put(itm1);

            plyr2.Inventory.Put(b2);
            look = new LookCommand();
        }

        [Test]
        public void LookInventory()
        {
            Assert.AreEqual(plyr.FullDescription,look.Execute(plyr, new string[] { "look", "at", "inventory" }));
        }

        [Test]
        public void LookAtGem()
        {
            Assert.AreEqual(itm1.FullDescription, look.Execute(plyr, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void LookAtUnk()
        {

            Assert.AreEqual("I can't find the gem", look.Execute(plyr2, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void LookAtGemInMe()
        {
            Assert.AreEqual(itm1.FullDescription, look.Execute(plyr, new string[] { "look", "at", "gem", "in", "inventory"}));
        }

        [Test]
        public void LookAtGemInBag()
        {
            Assert.AreEqual(itm1.FullDescription, look.Execute(plyr, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void LookAtGemInNoBag()
        {
            plyr.Inventory.Take("bag");
            Assert.AreEqual("I can't find the bag", look.Execute(plyr, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void LookAtGemInNoGemInBag()
        {
            Assert.AreEqual("I can't find the gem", look.Execute(plyr2, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void InvalidCommand()
        {
            Assert.AreEqual("I don't know how to look like that", look.Execute(plyr, new string[] { "look", "around"}));
        }
    }
}