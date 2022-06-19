using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky.Bathroom_100
{
    public class TakeBathAction : TakeBathAbstractAction
    {
        public TakeBathAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bathroom_100;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bath_100, ItemType.Toilet_100, ItemType.Sink_100 };
    }
}
