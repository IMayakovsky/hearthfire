using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Bedroom_122
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_122;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bed_122 };
    }


    public class SuddenlyWakeUpAction : SuddenlyWakeUpAbstractAction
    {
        public SuddenlyWakeUpAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_122;
    }


    class PlayAction : AbstractSportAction
    {
        public PlayAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_122;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Game_122 };
    }
}