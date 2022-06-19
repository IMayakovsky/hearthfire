using Hearthfire.Enities;
using Hearthfire.Enities.JsonEnities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hearthfire.Logic
{
    public class MetersManager : IMetersManager
    {
        private Dictionary<MeterType, int> _meters = new Dictionary<MeterType, int>();

        public EventHandler<MetersData> MetersDataWasChanged { get; set; }

        public MetersManager()
        {
            string json = new StreamReader(ResPath.FamilyHouse +  "/meters.json").ReadToEnd();
            MetersDataJson dataJson = JsonConvert.DeserializeObject<MetersDataJson>(json);
            _meters[MeterType.Water] = dataJson.Water;
            _meters[MeterType.Electricity] = dataJson.Electricity;
            _meters[MeterType.Gas] = dataJson.Gas;
        }

        public void Increase(MeterType type, int value)
        {
            if (type == MeterType.None)
                return;

            _meters[type] += value;
            MetersDataWasChanged?.Invoke(this, new MetersData { Type = type, Value = _meters[type] });
        }

        public int GetMeterValueByType(MeterType type)
        {
            return _meters[type];
        }
    }
}
