using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base (new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
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
                string idesc = string.Format("You are {0} the {1}\n", this.Name, base.FullDescription);
                idesc += "You are Carrying: \n";
                idesc += this.Inventory.ItemList;
                return idesc;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location { get; set; }
    }
}
