using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Bedroom_220
{
    public class SleepAction : SleepAbstractAction
    {
        public SleepAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_220;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Bed_220 };
    }


    public class ReadAction : AbstractAction
    {
        public ReadAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "reading book";

        public override RoomType Room => RoomType.Bedroom_220;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.WorkTable_220 };
    }

    class StudyAction : AbstractStudyAction
    {
        public StudyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Bedroom_220;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.WorkTable_220 };
    }
}
