using Hearthfire;
using Hearthfire.Enities;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public partial class Milan : Resident
    {

        public Milan() : base()
        {
           
        }

        public override void OnItemWasBroken(FullItem fullItem)
        {
            AddDuty(new OrderRepairmanAction(fullItem, this, 0));
        }
       

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new RelaxAction(this, period);
        }
    }
}



