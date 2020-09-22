using System;

namespace SwinAdventure
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name, desc;
            Player p;
            Item itm1, itm2, itm3;
            Bag bag;
            Location loc;

            string[] command = new string[] {""};
            string raw;
            LookCommand look = new LookCommand();

            
            Console.WriteLine("What's your name?");
            name = Console.ReadLine();
            Console.WriteLine("Describe yourself {0}?", name );
            desc = Console.ReadLine();

            loc = new Location(new string[] { "the hallway" }, "Hallway", "A very well lit hallway");
            p = new Player(name, desc, loc);
            itm1 = new Item(new string[] { "Item 1" }, "The First Item", "The very first item");
            itm2 = new Item(new string[] { "Item 2" }, "The Second Item", "The not first item");

            loc.Inventory.Put(itm1);
            p.Inventory.Put(itm2);

            bag = new Bag(new String[] { "Bag" }, "The Bag", "Just a Bag");

            p.Inventory.Put(bag);

            itm3 = new Item(new string[] { "Item 3" }, "The Third Item", "The not first and second item");

            bag.Inventory.Put(itm3);

            Console.WriteLine("Welcome to Swin Adventure!\nYou have arrived in the Hallway");

            while (command[0] != "quit" )
            {
                Console.Write("Command -> ");
                raw = Console.ReadLine();

                command = raw.Split(' ');
                
                Console.WriteLine(look.Execute(p, command));
            }
        }
    }
}
