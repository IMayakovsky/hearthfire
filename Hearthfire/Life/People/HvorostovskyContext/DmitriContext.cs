using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Dmitri
    {
        public override int Id => 100;

        public override string Name => "Dmitri";

        public override string SecondName => "Hvorostovsky";

        public override string Image => ResPath.Images + "man.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();
            // 00:00 - 06:00
            _routins.Add(() => new Bedroom_020.SleepAction(this, 6));
            // 06:00 - 06:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 06:00 - 07:00
            _routins.Add(() => new Bedroom_020.SportAction(this, 1));
            // 07:00 - 08:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 08:00 - 14:00
            _routins.Add(() => new WorkAction(this, 6));
            // 14:00 - 15:00
            _routins.Add(() => new Kitchen_010.LunchAnction(this, 1));
            // 15:00 - 17:00
            _routins.Add(() => new LivingRoom_030.PlayWithBabyAction(this, 2));
            // 17:00 - 18:00
            _routins.Add(() => new OrderFoodAction(this, 1));
            // 18:00 - 19:00
            _routins.Add(() => new Kitchen_010.DinnerAction(this, 1));
            // 19:00 - 22:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 3));
            // 22:00 - 06:00
            _routins.Add(() => new Bedroom_020.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            _routins.Add(() => new Bedroom_020.SleepAction(this, 25));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            _routins.Add(() => new Bedroom_020.SleepAction(this, 25));
        }
    }
}
