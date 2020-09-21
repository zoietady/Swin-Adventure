using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Location _location;

        public Player(string name, string desc, Location location) : base (new string[] { "me", "inventory" }, name, desc)
        {
            Inventory = new Inventory();
            Location = location;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            else if (Inventory.HasItem(id))
                return Inventory.Fetch(id);

            else
                return _location.Locate(id);

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
