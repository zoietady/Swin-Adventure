using System;
namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
	{
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
		{
			Inventory = new Inventory();
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			else
			{
				return Inventory.Fetch(id);
			}
		}

        public Inventory Inventory { get; }

        public override string FullDescription
		{
			get
			{
				string idesc = string.Format("You are in the {0}\n{1}", Name, base.FullDescription);
				return idesc;
			}
		}

	}
}
