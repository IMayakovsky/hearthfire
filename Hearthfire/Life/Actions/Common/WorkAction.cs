using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    class WorkAction : AbstractAction
    {
        public WorkAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => " working ";

        public override RoomType Room => RoomType.Outside;

        protected override List<ItemType> _usingItems => null;

    }
}
