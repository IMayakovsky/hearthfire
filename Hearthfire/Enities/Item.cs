using Hearthfire.Enities.JsonEnities;
using System;

namespace Hearthfire.Enities
{
   
    public class Item
    {
        public readonly int DataId;

        public byte Pos { get; set; }

        public bool IsBroken { get => Status <= 0; }

        public Action<bool> StatusWasChanged;

        private double _status;

        public double Status 
        { 
            get => _status; 
            private set
            {
                bool wasBroken = IsBroken;
                _status = value;
                if (wasBroken != IsBroken)
                    StatusWasChanged?.Invoke(IsBroken);
            }
        }

        public Item(ItemJson json)
        {
            DataId = json.DataId;
            Pos = json.Pos;
            Status = json.Status;
        }

        /// <summary>
        /// Uses current item in work
        /// </summary>
        /// <returns>false if Item is broken after using true otherwise</returns>
        public bool Use()
        {
            if (!IsBroken)
                Status -= 0.3;

            return !IsBroken;
        }

        public void Repair()
        {
            Status = 100;
        }
    }
}
