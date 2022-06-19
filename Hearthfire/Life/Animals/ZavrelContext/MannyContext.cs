using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Manny : Resident
    {
        public override int Id => 9;

        public override string Name => "Manny";

        public override string SecondName => "";

        public override string Image => ResPath.FamilyImages + "/Resident/manny.png";


        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 07:00
            _routins.Add(() => new Garden.SleepAction(this, 6));
        }

        public override void SetSaturdayActionsChain()
        {
            SetWeekdayActionsChain();
        }

        public override void SetSundayActionsChain()
        {
            SetWeekdayActionsChain();
        }
    }
}
