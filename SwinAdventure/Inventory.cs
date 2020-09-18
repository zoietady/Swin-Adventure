using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _inventory;

        public Inventory()
        {
            _inventory = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item i in _inventory)
            {
                if (i.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _inventory.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _inventory)
            {
                if (i.AreYou(id))
                {
                    _inventory.Remove(i);
                    return i;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _inventory)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string ilist = ""; 
                foreach(Item i in _inventory)
                {
                    ilist += "\t" + i.ShortDescription + "\n";
                }
                return ilist;
            }
        }
    }
}
