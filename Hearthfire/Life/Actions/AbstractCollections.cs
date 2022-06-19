using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System.Collections.Generic;

namespace Hearthfire.Life
{
    public abstract class SleepAbstractAction : AbstractAction
    {
        protected SleepAbstractAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "sleeping";
    }


    public abstract class SuddenlyWakeUpAbstractAction : AbstractAction
    {
        protected SuddenlyWakeUpAbstractAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "suddenly woken up";
        protected override List<ItemType> _usingItems => null;
    }

    public abstract class AbstractSportAction : AbstractAction
    {
        protected AbstractSportAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "sporting";
    }

    public abstract class AbstractWatchingTvAction : AbstractAction
    {
        protected AbstractWatchingTvAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "wathing TV";
    }

    public abstract class AbstractPlayWithBabyAction : AbstractAction
    {
        protected AbstractPlayWithBabyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "playing with Daniel";
    }


    public abstract class AbstractStudyAction : AbstractAction
    {
        protected AbstractStudyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "studing";
    }

    public abstract class FeedBabyAbstractAction : AbstractAction
    {
        protected FeedBabyAbstractAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "feeding Daniel";
    }


    public abstract class TakeBathAbstractAction : AbstractAction
    {
        protected TakeBathAbstractAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "taking bath";
    }

    public abstract class WashAbstractAction : AbstractAction
    {
        protected WashAbstractAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "washing";
    }

}
