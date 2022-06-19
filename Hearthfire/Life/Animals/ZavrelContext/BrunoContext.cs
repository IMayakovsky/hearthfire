using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Bruno : Resident
    {
        public override int Id => 7;

        public override string Name => "Bruno";

        public override string SecondName => "";

        public override string Image => ResPath.FamilyImages + "/Resident/bruno.png";


        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 06:00
            _routins.Add(() => new Garden.SleepAction(this, 6));
            // 06:00 - 07:00
            _routins.Add(() => new Garden.YellAction(this, 1));
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
