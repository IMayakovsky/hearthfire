using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Interfaces
{
    public interface IMetersManager
    {
        public EventHandler<MetersData> MetersDataWasChanged { get; set; }

        void Increase(MeterType type, int value);

        int GetMeterValueByType(MeterType type);
    }
}
