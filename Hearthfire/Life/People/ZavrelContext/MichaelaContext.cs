using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Michaela : Resident
    {
        public override int Id => 4;

        public override string Name => "Michaela";

        public override string SecondName => "Zavrelova";

        public override string Image => ResPath.Images + "woman.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 07:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 7));
            // 07:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 07:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 0));
            // 07:00
            _routins.Add(() => new Garden.FeedParrotsAction(this, 0));
            // 07:00 - 08:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 08:00 - 14:00
            _routins.Add(() => new WorkAction(this, 6));
            // 14:00
            _routins.Add(() => new Garden.FeedParrotsAction(this, 0));
            // 14:00 - 15:00
            _routins.Add(() => new CleanAction(this, 1));
            // 15:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 15:00 - 17:00
            _routins.Add(() => new WorkAction(this, 2));
            // 17:00 - 18:00
            _routins.Add(() => new Garden.PlayWithDogsAction(this, 1));
            // 18:00
            _routins.Add(() => new Garden.FeedMannyAction(this, 0));
            // 18:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 0));
            // 18:00 - 19:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 1));
            // 19:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 2));
            // 21:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 21:00 - 22:00
            _routins.Add(() => new Bedroom_220.ReadAction(this, 1));
            // 22:00 - 00:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 09:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 9));
            // 09:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 09:00
            _routins.Add(() => new Garden.FeedParrotsAction(this, 0));
            // 09:00 - 10:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 10:00 - 18:00
            _routins.Add(() => new SportAction(this, 8));
            // 18:00 - 21:00
            _routins.Add(() => new Bedroom_220.StudyAction(this, 3));
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
            _routins.Add(() => new Bedroom_220.ReadAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_220.SleepAction(this, 5));
        }
    }
}
