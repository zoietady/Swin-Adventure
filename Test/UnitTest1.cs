using NUnit.Framework;
using SwinAdventure;

namespace Test
{
    [TestFixture()]
    public class Tests
    {
        [Test()]
        public void TestAreYouTrue()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(id.AreYou("fred"), true);
        }

        [Test()]
        public void TestAreYouFalse()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(id.AreYou("boby"), false);
        }

        [Test()]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(id.AreYou("BOb"), true);
        }

        [Test()]
        public void TestFirstId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(id.FirstId, "fred");
        }

        [Test()]
        public void TestAddId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddIdentifier("wilma");
            Assert.AreEqual(id.AreYou("wilma") && id.AreYou("bob") && id.AreYou("fred"), true);
        }
    }
}