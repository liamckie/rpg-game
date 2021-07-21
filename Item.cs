using System;
using System.Collections.Generic;
using System.Text;

namespace rpg
{
    class Item
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        
        public Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
