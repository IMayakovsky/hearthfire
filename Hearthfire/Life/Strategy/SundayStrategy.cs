using System.Collections.Generic;

namespace Hearthfire.Life.Strategy
{
    public class SundayStrategy : DayStrategy
    {
        protected override byte _dailyElectricityConsumption => 5;

        public SundayStrategy(IEnumerable<Resident> people)
        {
            foreach (Resident person in people)
                person.SetSundayActionsChain();
        }

        

    }
}
