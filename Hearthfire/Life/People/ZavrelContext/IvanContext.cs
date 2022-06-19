using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Ivan : Resident
    {
        public override int Id => 6;

        public override string Name => "Ivan";

        public override string SecondName => "Mayakovsky";

        public override string Image => ResPath.Images + "man.png";


        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 09:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 8));
            // 09:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 09:00 - 10:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 10:00 - 18:00
            _routins.Add(() => new SportAction(this, 8));
            // 18:00 - 21:00
            _routins.Add(() => new Bedroom_220.StudyAction(this, 3));
            // 21:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 3));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 5));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 20:00
            _routins.Add(() => new TravelAction(this, 14));
            // 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 20:00 - 21:00
            _routins.Add(() => new RelaxAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 5));
        }
    }
}
