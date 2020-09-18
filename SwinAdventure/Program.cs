using System;

namespace SwinAdventure
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IdentifiableObject id = new IdentifiableObject(new string[] {});
            Console.WriteLine(id.AreYou("fred"));
        }
    }
}
