using Hearthfire.Enities;

namespace Hearthfire.Life.Zavrel
{
    public partial class Bruno : Resident
    {

        public override void OnItemWasBroken(FullItem item)
        {
            
        }


        public override void SwitchToFavoriteAction(byte period)
        {
            if (Supervisor.Instance.Time.Hour < 19)
                ActiveAction = new Garden.YellAction(this, (byte)(period - 5));
            else
                ActiveAction = new Garden.SleepAction(this, (byte)(period + 1));
        }
    }
}
