using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky.Bedroom_020
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_020;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bed_020 };
    }


    public class SuddenlyWakeUpAction : SuddenlyWakeUpAbstractAction
    {
        public SuddenlyWakeUpAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_020;
    }


    class SportAction : AbstractSportAction
    {
        public SportAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_020;

        protected override List<ItemType> _usingItems => null;
    }
}