using Hearthfire.Enities;
using Hearthfire.Life.Actions;

namespace Hearthfire.Life.Zavrel
{
    public partial class Manny : Resident
    {

        public override void OnItemWasBroken(FullItem item)
        {
            
        }


        public override void SwitchToFavoriteAction(byte period)
        {
            if (Supervisor.Instance.Time.Hour < 21)
                ActiveAction = new RelaxAction(this, (byte)(period - 3));
            else
                ActiveAction = new Garden.SleepAction(this, (byte)(period + 1));
        }
    }
}
