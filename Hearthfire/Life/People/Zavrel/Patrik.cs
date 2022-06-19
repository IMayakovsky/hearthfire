using Hearthfire.Enities;
using Hearthfire.Life.Actions;

namespace Hearthfire.Life.Zavrel
{
    public partial class Patrik : Resident
    {

        public override void OnItemWasBroken(FullItem item)
        {
            AddDuty(new OrderRepairmanAction(item, this, 0));
        }


        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new SportAction(this, period);
        }
    }
}
