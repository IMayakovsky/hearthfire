using Hearthfire.Enities;
using Hearthfire.Enities.JsonEnities;
using Hearthfire.Enities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Models
{
    public class Room
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        public string Image { get; private set; }
        public int ElectricityConsumption { get; private set; }
        public Dictionary<ItemType, Item> Content { get; private set; } = new Dictionary<ItemType, Item>();

        public Room(RoomJson json)
        {
            Name = json.Name;
            Id = json.Id;
            Image = json.Image;
            ElectricityConsumption = json.ElectricityConsumption;

            foreach (ItemJson item in json.Items)
                Content[(ItemType)item.DataId] = new Item(item);
        }
      
    }
}
