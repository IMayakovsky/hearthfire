using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;

namespace Hearthfire.Life.Zavrel
{
    public partial class Michaela : Resident
    {

        public Michaela() : base()
        {
        }

        public override void OnItemWasBroken(FullItem item)
        {
            ILifeManager lifeManager = Supervisor.Instance.LifeManager;
            if (lifeManager.IsPersonAvailable((int)ZavrelNames.Milan))
            {
                Supervisor.Instance.Console.Log("Michaela told Farther, that " + item.Data.Name + " was broken");
                Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Milan).OnItemWasBroken(item);
            }
            else
            {
                Supervisor.Instance.Console.Log("Michaela told Morther, that " + item.Data.Name + " was broken");
                Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Ivana).OnItemWasBroken(item);
            }
            
        }

        public override void SwitchToFavoriteAction(byte period)
        {
            ActiveAction = new LivingRoom_030.WatchingTvAction(this, period);
        }
    }
}
