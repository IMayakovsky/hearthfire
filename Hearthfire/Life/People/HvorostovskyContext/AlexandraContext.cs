using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Alexandra : Resident
    {
        public override int Id => 103;

        public override string Name => "Alexandra";

        public override string SecondName => "Hvorostovsky";

        public override string Image => ResPath.FamilyImages + "/Resident/Alexandra.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();
            // 00:00 - 07:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 7));
            // 07:00 - 08:00
            _routins.Add(() => new Bedroom_120.SportAction(this, 1));
            // 08:00 - 15:00
            _routins.Add(() => new WorkAction(this, 1));
            // 15:00 - 16:00
            _routins.Add(() => new Kitchen_010.LunchAnction(this, 7));
            // 16:00 - 17:00
            _routins.Add(() => new CleanAction(this, 1));
            // 17:00 - 18:00
            _routins.Add(() => new Bedroom_121.FeedBabyAction(this, 1));
            // 18:00 - 19:00
            _routins.Add(() => new Bedroom_120.StudyAction(this, 1));
            // 19:00 - 23:00
            _routins.Add(() => new Bedroom_120.WatchingTvAction(this, 4));
            // 23:00 - 00:00
            _routins.Add(() => new Bedroom_120.SleepAction(this, 5));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();
            
            _routins.Add(() => new Bedroom_120.SleepAction(this, 25));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            _routins.Add(() => new Bedroom_120.SleepAction(this, 25));
        }
    }
}
