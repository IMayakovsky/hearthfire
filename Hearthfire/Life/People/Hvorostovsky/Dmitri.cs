using Hearthfire;
using Hearthfire.Enities;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System.Collections.Generic;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Dmitri : Resident
    {

        public Dmitri() : base()
        {
           
        }

        public override void OnItemWasBroken(FullItem fullItem)
        {
            if (fullItem.Data.RepairComplexity > 3)
                AddDuty(new OrderRepairmanAction(fullItem, this, 1));
            else
                AddDuty(new RepairAction(fullItem, this, 0));
        }
       

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new RelaxAction(this, period);
        }
    }
}



