using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Bara : Resident
    {
        public override int Id => 8;

        public override string Name => "Bara";

        public override string SecondName => "";

        public override string Image => ResPath.FamilyImages + "/Resident/bara.png";


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
            _routins.Clear();
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();
        }
    }
}
