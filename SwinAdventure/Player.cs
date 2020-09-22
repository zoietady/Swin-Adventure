using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        public Player(string name, string desc, Location location = null) : base (new string[] { "me", "inventory" }, name, desc)
        {
            Inventory = new Inventory();
            Location = location ?? new Location(new string[] { "the hallway" }, "Hallway", "A very well lit hallway");
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            else if (Inventory.HasItem(id))
                return Inventory.Fetch(id);

            else
                return Location.Locate(id);

        }

        public override string FullDescription
        {
            get
            {
                string idesc = string.Format("You are {0} the {1}\n", Name, base.FullDescription);
                idesc += "You are Carrying: \n";
                idesc += Inventory.ItemList;
                return idesc;
            }
        }

        public Inventory Inventory { get; private set; }

        public Location Location { get; set; }
    }
}
