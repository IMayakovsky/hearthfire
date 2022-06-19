using System.Collections.Generic;

namespace Hearthfire.Life.Strategy
{
    public abstract class DayStrategy
    {
        protected abstract byte _dailyElectricityConsumption { get; }

        public void Restart(IEnumerable<Resident> people)
        {
            foreach (Resident p in people)
                p.Restart();
        }

        public void CalculateConsumptions()
        {
            Supervisor.Instance.Meters.Increase(Enities.Enums.MeterType.Electricity, _dailyElectricityConsumption);
        }
    }
}
