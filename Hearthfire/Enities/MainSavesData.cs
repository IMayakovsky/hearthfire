using System;

namespace Hearthfire.Enities
{
    [Serializable]
    public class MainSavesData
    {
        public int PersonWaiting { get; set; }
        public int HourWaiting { get; set; }
        public string Family { get; set; }
        public long Time { get; set; }
    }
}
