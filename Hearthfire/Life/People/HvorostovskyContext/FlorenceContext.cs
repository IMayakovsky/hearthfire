using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Florence
    {
        public override int Id => 101;

        public override string Name => "Florence";

        public override string SecondName => "Hvorostovsky";

        public override string Image => ResPath.FamilyImages + "/Resident/Florence.png";

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();
            // 00:00 - 06:00
            _routins.Add(() => new Bedroom_020.SleepAction(this, 6));
            // 06:00 - 07:00
            _routins.Add(() => new Kitchen_010.MakeBreakfastAction(this, 1));
            // 07:00 - 08:00
            _routins.Add(() => new Kitchen_010.BreakfastAction(this, 1));
            // 08:00 - 09:00
            _routins.Add(() => new Kitchen_010.FedBabyAction(this, 1));
            // 09:00 - 11:00
            _routins.Add(() => new Bedroom_121.StudyWithBabyAction( this, 2));
            // 11:00 - 13:00
            _routins.Add(() => new Kitchen_010.MakeLunchAction(this, 2));
            // 13:00 - 14:00
            _routins.Add(() => new Kitchen_010.FedBabyAction(this, 1));
            // 14:00 - 15:00
            _routins.Add(() => new Kitchen_010.LunchAnction(this, 1));
            // 15:00 - 16:00
            _routins.Add(() => new CleanAction(this, 1));
            // 16:00 - 18:00
            _routins.Add(() => new WorkAction(this, 2));
            // 18:00 - 19:00
            _routins.Add(() => new Kitchen_010.DinnerAction(this, 1));
            // 19:00 - 21:00
            _routins.Add(() => new LivingRoom_030.PlayWithBabyAction(this, 2));
            // 21:00 - 00:00
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
