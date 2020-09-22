using NUnit.Framework;
using SwinAdventure;

namespace LocationTest
{
    public class Tests
    {
        Location loc;
        Item gem;
        Player p;
        LookCommand look;

        [SetUp]
        public void Setup()
        {
            loc = new Location(new string[] { "hallway" }, "the hallway", "this is a very well lit hallway");
            gem = new Item(new string[] { "gem" }, "the gem", "the gem");
            p = new Player("test", "the location test", loc);
            look = new LookCommand();

            loc.Inventory.Put(gem);
        }

        [Test]
        public void LocateLocation()
        {
            Assert.AreEqual(loc.Locate("Hallway"), loc);
        }

        [Test]
        public void LocateItemInLocation()
        {
            Assert.AreEqual(gem, loc.Locate("gem"));
        }

        [Test]
        public void PlayerLocateItemInLocation()
        {
            loc.Inventory.Put(gem);
            Assert.AreEqual(gem, p.Locate("gem"));
        }

        [Test]
        public void PlayerLook()
        {
            Assert.AreEqual(loc.FullDescription, look.Execute(p, new string[] { "look" }));
        }


    }
}