using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Patrik : Resident
    {
        public override int Id => 3;

        public override string Name => "Patrik";

        public override string SecondName => "Zavrel";

        public override string Image => ResPath.Images + "man.png";


        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_121.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 0));
            // 05:00 - 14:00
            _routins.Add(() => new WorkAction(this, 9));
            // 14:00 - 16:00
            _routins.Add(() => new RelaxAction(this, 10));
            // 16:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 16:00 - 20:00
            _routins.Add(() => new SportAction(this, 4));
            // 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_121.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_121.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 20:00
            _routins.Add(() => new TravelAction(this, 14));
            // 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 20:00 - 21:00
            _routins.Add(() => new Bedroom_121.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_121.SleepAction(this, 5));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 08:00
            _routins.Add(() => new Bedroom_121.SleepAction(this, 8));
            // 08:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 08:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 0));
            // 08:00
            _routins.Add(() => new Garden.FeedParrotsAction(this, 0));
            // 08:00 - 09:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 09:00 - 12:00
            _routins.Add(() => new Garden.WorkAction(this, 3));
            // 12:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 12:00 - 17:00
            _routins.Add(() => new SportAction(this, 5));
            // 17:00 - 18:00
            _routins.Add(() => new Garden.PlayWithDogsAction(this, 1));
            // 18:00
            _routins.Add(() => new Garden.FeedMannyAction(this, 0));
            // 18:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 0));
            // 18:00
            _routins.Add(() => new Garden.FeedDogsAction(this, 0));
            // 18:00 - 19:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 1));
            // 19:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 2));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_121.SleepAction(this, 5));
        }
    }
}
