using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Daniel : Resident
    {
        public Daniel() : base()
        {
        }

        public override void OnItemWasBroken(FullItem item) {}

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new Bedroom_121.SleepAction(this, period);
        }
    }
}
