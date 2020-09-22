using System;
namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;

        public GameObject(string[] ids, string name, string desc) : base (ids)
        {
            _description = desc;
            Name = name;
        }

        public string Name { get; private set; }
        public string ShortDescription
        {
            get
            {
                return string.Format("a {0} ({1})", Name, this.FirstId);
            }
        }
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}
