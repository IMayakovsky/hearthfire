using Hearthfire.Life.Strategy;
using System.Collections.Generic;

namespace Hearthfire.Life.Hvorostovsky.Strategy
{
    class SaturdayStrategy : DayStrategy
    {
        protected override byte _dailyElectricityConsumption => 20;

        public SaturdayStrategy(IEnumerable<Resident> people)
        {
            foreach (Resident person in people)
                person.SetSaturdayActionsChain();
        }
    }
}
