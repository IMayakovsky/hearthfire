
using Hearthfire.Enities.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Hearthfire.Enities
{
    [Serializable]
    public class ItemData
    {
        public int Id;

        public string Name;

        public string Image;

        public MeterType MeterType;

        public int Consumption;

        public byte RepairComplexity;
    }
}
