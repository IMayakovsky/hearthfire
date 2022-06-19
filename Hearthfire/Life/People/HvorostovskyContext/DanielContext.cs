using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Daniel
    {
        public override string Name => "Daniel";

        public override string SecondName => "Hvorostovsky";

        public override string Image => ResPath.FamilyImages + "/Resident/Daniel.png";

        public override int Id => 102;

        public override void SetWeekdayActionsChain()
        {
            _routins.Clear();

            _routins.Add(() => new Bedroom_121.SleepAction(this, 10));
            _routins.Add(() => new Bedroom_121.ScreamAction(this, 2));
            _routins.Add(() => new RelaxAction(this, 3));
            _routins.Add(() => new Bedroom_121.SleepAction(this, 4));
            _routins.Add(() => new RelaxAction(this, 2));
            _routins.Add(() => new Bedroom_121.SleepAction(this, 10));
        }

        public override void SetSaturdayActionsChain()
        {
            _routins.Clear();

            _routins.Add(() => new Bedroom_121.SleepAction(this, 25));
        }

        public override void SetSundayActionsChain()
        {
            _routins.Clear();

            _routins.Add(() => new Bedroom_121.SleepAction(this, 25));
        }
    }
}
