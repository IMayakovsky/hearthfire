using Hearthfire.Enities;

namespace Hearthfire.Life.Zavrel
{
    public partial class Keisy : Resident
    {

        public override void OnItemWasBroken(FullItem item)
        {
            
        }


        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new Garden.PlayGardenAction(this, period);
        }
    }
}
