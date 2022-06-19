using System;

namespace Hearthfire.Enities.JsonEnities
{
    [Serializable]
    public class ItemJson
    {
        public int DataId;
        public byte Pos;
        public double Status;

        public ItemJson() { }

        public ItemJson(Item item)
        {
            DataId = item.DataId;
            Pos = item.Pos;
            Status = item.Status;
        }
    }
}
