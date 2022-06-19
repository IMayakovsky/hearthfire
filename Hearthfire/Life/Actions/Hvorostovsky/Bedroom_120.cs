using System.Collections.Generic;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;

namespace Hearthfire.Life.Hvorostovsky.Bedroom_120
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_120;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bed_120 };
    }


    public class SuddenlyWakeUpAction : SuddenlyWakeUpAbstractAction
    {
        public SuddenlyWakeUpAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_120;
    }


    public class SportAction : AbstractSportAction
    {
        public SportAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_120;

        protected override List<ItemType> _usingItems => null;
    }


    class WatchingTvAction : AbstractWatchingTvAction
    {
        public WatchingTvAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_120;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Tv_120 };
    }

    class StudyAction : AbstractStudyAction
    {
        public StudyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_120;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.WorkTable_120 };
    }
}
