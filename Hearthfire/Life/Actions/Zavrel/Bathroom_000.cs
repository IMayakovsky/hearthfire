using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Bathroom_000
{
    public class TakeBathAction : TakeBathAbstractAction
    {
        public TakeBathAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bathroom_000;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bath_000, ItemType.Sink_000 };
    }


    public class WashAction : WashAbstractAction
    {
        public WashAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bathroom_000;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Toilet_000, ItemType.Sink_000 };
    }
}
