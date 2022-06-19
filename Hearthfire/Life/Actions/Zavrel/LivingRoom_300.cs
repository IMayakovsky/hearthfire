using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.LivingRoom_030
{
    class WatchingTvAction : AbstractWatchingTvAction
    {
        public WatchingTvAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.LivingRoom_030;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Tv_030 };
    }

    public class MannyFearAction : AbstractAction
    {
        public MannyFearAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "fearing";

        public override RoomType Room => RoomType.LivingRoom_030;

        protected override List<ItemType> _usingItems => null;
    }
}
