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
    public partial class Dominik : Resident
    {
        public Dominik() : base()
        {
        }

        public override void OnItemWasBroken(FullItem item) 
        {
            Supervisor.Instance.Console.Log("Dominik told Morther, that " + item.Data.Name + " was broken");
            Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Ivana).OnItemWasBroken(item);
        }

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new Bedroom_122.PlayAction(this, period);
        }
    }
}
