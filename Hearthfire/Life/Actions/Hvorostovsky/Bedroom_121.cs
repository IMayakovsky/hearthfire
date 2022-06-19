using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky.Bedroom_121
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_121;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Cradle_121 };
    }

    public class StudyWithBabyAction : AbstractAction
    {
        public StudyWithBabyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_121;

        public override string Description => "studing with Daniel";

        protected override List<ItemType> _usingItems => null;
    }

    public class TakeCareAboutBabyAction : AbstractAction
    {
        public TakeCareAboutBabyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_121;

        public override string Description => "taking care about Daniel";

        protected override List<ItemType> _usingItems => null;
    }

    public class FeedBabyAction : FeedBabyAbstractAction
    {
        public FeedBabyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_121;

        protected override List<ItemType> _usingItems => null;
    }

    public class ScreamAction : AbstractAction
    {
        public ScreamAction(IActionsContext context, byte period) : base(context, period)
        {
        }


        public override string Description => "screaming";

        public override RoomType Room => RoomType.Bedroom_121;

        protected override List<ItemType> _usingItems => null;
    }
}
