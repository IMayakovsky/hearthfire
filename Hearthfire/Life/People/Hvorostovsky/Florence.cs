using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Florence : Resident
    {

        public Florence() : base()
        {
        }

        public override void OnItemWasBroken(FullItem item)
        {
            AddDuty(new OrderRepairmanAction(item, this, 1));
        }

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new Bedroom_020.SleepAction(this, period);
        }
    }
}
