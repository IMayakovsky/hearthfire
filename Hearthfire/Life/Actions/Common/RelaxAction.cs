using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    class RelaxAction : AbstractAction
    {
        public RelaxAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "relaxing";

        public override RoomType Room => RoomType.Unknown;

        protected override List<ItemType> _usingItems => null;
    }
}
