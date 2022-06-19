using System;
using System.Collections.Generic;
using System.Text;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;

namespace Hearthfire.Life.Zavrel.Bedroom_120
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_120;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bed_120 };
    }
}
