using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Models
{
    public class ItemContent
    {
        public string Name { get; set; }
        public byte Amount { get; set; }

        public ItemContent(string name, byte amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
