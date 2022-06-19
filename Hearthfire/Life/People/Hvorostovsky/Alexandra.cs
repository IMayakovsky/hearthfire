using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky
{
    public partial class Alexandra : Resident
    {

        public Alexandra() : base()
        {
        }

        public override void OnItemWasBroken(FullItem item)
        {
            ILifeManager lifeManager = Supervisor.Instance.LifeManager;
            if (lifeManager.IsPersonAvailable((int)HvorostovskyNames.Dmitri))
            {
                Supervisor.Instance.Console.Log("Alexandra asked Farther to repair the " + item.Data.Name);
                lifeManager.GetPerson((int)HvorostovskyNames.Dmitri).OnItemWasBroken(item);
            }
            else if (lifeManager.IsPersonAvailable((int)HvorostovskyNames.Florence))
            {
                Supervisor.Instance.Console.Log("Alexandra said Morther, that " + item.Data.Name + " has been broken");
                lifeManager.GetPerson((int)HvorostovskyNames.Florence).OnItemWasBroken(item);
            }
            else
            {
                AddDuty(new OrderRepairmanAction(item, this, 1));
            }
        }

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new WalkAction(this, period);
        }
    }
}
