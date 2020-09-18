using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            for (int i=0; i< idents.Length; i++)
            {
                idents[i] = idents[i].ToLower();
            }
            _identifiers = new List<string>(idents);
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public String FirstId
        {
            get
            {
                if (_identifiers[0] == "" || _identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers[0];
                }
            }
        }

        public void AddIdentifier(String id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
