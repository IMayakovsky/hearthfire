using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    class SportAction : AbstractAction
    {
        public SportAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "sporting";

        public override RoomType Room => RoomType.Unknown;

        protected override List<ItemType> _usingItems => null;

    }
}
