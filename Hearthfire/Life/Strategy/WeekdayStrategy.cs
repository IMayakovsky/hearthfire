using Hearthfire.Life.Strategy;
using System.Collections.Generic;

namespace Hearthfire.Life.Hvorostovsky.Strategy
{
    class WeekdayStrategy : DayStrategy
    {
        protected override byte _dailyElectricityConsumption => 15;

        public WeekdayStrategy(IEnumerable<Resident> people)
        {
            foreach (Resident person in people)
                person.SetWeekdayActionsChain();
        }

        
    }
}
