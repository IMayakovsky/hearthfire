using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel
{
    public partial class Ivana : Resident
    {
        public Ivana() : base()
        {
        }

        public override void OnItemWasBroken(FullItem item)
        {
            ILifeManager lifeManager = Supervisor.Instance.LifeManager;
            if (lifeManager.IsPersonAvailable((int)ZavrelNames.Milan))
            {
                Supervisor.Instance.Console.Log("Ivana asked Milan to repair the " + item.Data.Name);
                lifeManager.GetPerson((int)ZavrelNames.Milan).OnItemWasBroken(item);
            }
            else
            {
                AddDuty(new OrderRepairmanAction(item, this, 0));
            }
        }

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new LivingRoom_030.WatchingTvAction(this, period);
        }
    }
}
