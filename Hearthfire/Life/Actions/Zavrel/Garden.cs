using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Garden
{

    public abstract class GardenAction : AbstractAction
    {
        public GardenAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Garden;

        protected override List<ItemType> _usingItems => null;
    }


    public class WalkMannyAction : GardenAction
    {
        public WalkMannyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "walking Manny";

        protected override void DoAction()
        {
            Resident p = Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Manny);
            p.AddDuty(new GardenWalkAction(p, 0));
        }
    }

    public class GardenWalkAction : GardenAction
    {
        public GardenWalkAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "walking in the garden";
    }


    public class FeedMannyAction : GardenAction
    {
        public FeedMannyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "feeding Manny";

        protected override void DoAction()
        {
            Resident p = Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Manny);
            p.AddDuty(new EatAction(p, 0));
        }
    }


    public class FeedParrotsAction : GardenAction
    {
        public FeedParrotsAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "feeding Bruno and Bara";

        protected override void DoActionAtFirst()
        {
            Resident bara = Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Bara);
            Resident bruno = Supervisor.Instance.LifeManager.GetPerson((int)ZavrelNames.Bruno);
            bara.AddDuty(new EatAction(bara, 0));
            bruno.AddDuty(new EatAction(bruno, 0));
        }
    }

    public class EatAction : GardenAction
    {
        public EatAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "eating";
    }


    public class FeedDogsAction : GardenAction
    {
        public FeedDogsAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "feeding Dar and Keisy";
    }


    public class PlayWithDogsAction : GardenAction
    {
        public PlayWithDogsAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "plaing with Dar and Keisy";
    }


    public class PlayGardenAction : GardenAction
    {
        public PlayGardenAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "playing";
    }


    public class YellAction : GardenAction
    {
        public YellAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "yelling";
    }


    public class SleepAction : GardenAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "sleeping";
    }


    public class BaraUnnerveAction : GardenAction
    {
        public BaraUnnerveAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "unnerving Bruno";
    }

    public class WorkAction : GardenAction
    {
        public WorkAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "working in the garden";
    }
}
