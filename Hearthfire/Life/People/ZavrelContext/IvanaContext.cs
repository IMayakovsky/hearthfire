using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Life.Zavrel.Collactions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel
{
    public partial class Ivana
    {
        public override int Id => 2;

        public override string Name => "Ivana";

        public override string SecondName => "Zavrelova";

        public override string Image => ResPath.Images + "woman.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();
            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 14:00
            _routins.Add(() => new WorkAction(this, 8));
            // 14:00
            _routins.Add(() => new ShopAction(this, 0));
            // 14:00 - 15:00
            _routins.Add(() => new Kitchen_010.MakeLunchAction(this, 1));
            // 15:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 15:00 - 17:00
            _routins.Add(() => new CleanAction(this, 2));
            // 17:00 - 19:00
            _routins.Add(() => new Kitchen_010.StudyWithDominikAction(this, 2));
            // 19:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 19:00 - 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 1));
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 08:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 8));
            // 08:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 08:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 0));
            // 08:00
            _routins.Add(() => new Kitchen_010.MakeBreakfastAction(this, 0));
            // 08:00 - 09:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 09:00 - 11:00
            _routins.Add(() => new CleanAction(this, 2));
            // 11:00
            _routins.Add(() => new ShopAction(this, 0));
            // 11:00 - 12:00
            _routins.Add(() => new Kitchen_010.MakeLunchAction(this, 1));
            // 12:00
            _routins.Add(() => new Kitchen_010.EatAction(this, 0));
            // 12:00 - 13:00
            _routins.Add(() => new RelaxAction(this, 1));
            // 13:00 - 15:00
            _routins.Add(() => new Garden.WorkAction(this, 2));
            // 15:00 - 18:00
            _routins.Add(() => new SportAction(this, 3));
            // 18:00
            _routins.Add(() => new Garden.FeedMannyAction(this, 0));
            // 18:00
            _routins.Add(() => new Garden.WalkMannyAction(this, 0));
            // 18:00 - 21:00
            _routins.Add(() => new RelaxAction(this, 3));
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
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
        }
    }
}
