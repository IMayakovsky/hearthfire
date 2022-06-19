using System;
using System.Collections.Generic;

namespace Hearthfire.Enities.JsonEnities
{
    [Serializable]
    public class RoomJson
    {
        public string Name;

        public int Id;

        public string Image;

        public int ElectricityConsumption;

        public List<ItemJson> Items { get; set; } = new List<ItemJson>();
    }
}
