using Hearthfire.Life.Actions;
using Hearthfire.Logic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Milan
    {
        public override int Id => 1;

        public override string Name => "Milan";

        public override string SecondName => "Zavrel";

        public override string Image => ResPath.Images + "man.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();
            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 15:00
            _routins.Add(() => new WorkAction(this, 9));
            // 15:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 15:00 - 17:00
            _routins.Add(() => new CleanAction(this, 2));
            // 17:00 - 19:00
            _routins.Add(() => new Garden.WorkAction(this, 2));
            // 19:00
            _routins.Add(() => new Garden.FeedDogsAction(this, 0));
            // 19:00 - 20:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 1));
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 15:00
            _routins.Add(() => new SportAction(this, 9));
            // 15:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 15:00 - 17:00
            _routins.Add(() => new CleanAction(this, 2));
            // 17:00 - 19:00
            _routins.Add(() => new Garden.WorkAction(this, 2));
            // 19:00
            _routins.Add(() => new Garden.FeedDogsAction(this, 0));
            // 19:00 - 20:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 1));
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 20:00
            _routins.Add(() => new TravelAction(this, 14));
            // 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 20:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 20:00
            _routins.Add(() => new Kitchen_010.TakeBearAction(this, 0));
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00
            _routins.Add(() => new Kitchen_010.TakeBearAction(this, 0));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
        }
    }
}
