using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Keisy : Resident
    {
        public override int Id => 10;

        public override string Name => "Keisy";

        public override string SecondName => "";

        public override string Image => ResPath.FamilyImages + "/Resident/keisy.png";


        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            // 00:00 - 9:00
            _routins.Add(() => new Garden.SleepAction(this, 9));
            // 9:00 - 11:00
            _routins.Add(() => new Garden.PlayGardenAction(this, 2));
            // 11:00 - 13:00
            _routins.Add(() => new Garden.SleepAction(this, 2));
            // 13:00 - 20:00
            _routins.Add(() => new Garden.PlayGardenAction(this, 7));
            // 20:00 - 00:00
            _routins.Add(() => new Garden.SleepAction(this, 9));
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
