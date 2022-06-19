using System;

namespace Hearthfire.Enities.JsonEnities
{
    [Serializable]
    public class MetersDataJson
    {
        public int Water { get; set; }
        public int Electricity { get; set; }
        public int Gas { get; set; }
    }
}
