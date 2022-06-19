using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Bedroom_121
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_121;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bed_121 };
    }

    class WatchingTvAction : AbstractWatchingTvAction
    {
        public WatchingTvAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_121;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Tv_121 };
    }
}
