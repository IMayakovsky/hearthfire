using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel
{
    public partial class Dominik
    {
        public override int Id => 4;

        public override string Name => "Dominik";

        public override string SecondName => "Zavrel";

        public override string Image => ResPath.Images + "man.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 08:00
            _routins.Add(() => new Bedroom_122.SleepAction(this, 8));
            // 08:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 08:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 0));
            // 08:00 - 16:00
            _routins.Add(() => new WorkAction(this, 8));
            // 16:00 - 17:00
            _routins.Add(() => new RelaxAction(this, 1));
            // 17:00 - 19:00
            _routins.Add(() => new Kitchen_010.StudyDominikAction(this, 2));
            // 19:00 - 21:00
            _routins.Add(() => new Bedroom_121.WatchingTvAction(this, 2));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_122.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_122.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 20:00
            _routins.Add(() => new TravelAction(this, 14));
            // 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 20:00 - 21:00
            _routins.Add(() => new Bedroom_122.PlayAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_122.SleepAction(this, 5));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 05:00
            _routins.Add(() => new Bedroom_122.SleepAction(this, 5));
            // 05:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 05:00 - 06:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 06:00 - 20:00
            _routins.Add(() => new TravelAction(this, 14));
            // 20:00
            _routins.Add(() => new Bathroom_000.WashAction(this, 0));
            // 20:00 - 21:00
            _routins.Add(() => new LivingRoom_030.WatchingTvAction(this, 1));
            // 21:00 - 00:00
            _routins.Add(() => new Bedroom_122.SleepAction(this, 5));
        }
    }
}
