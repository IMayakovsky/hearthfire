using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Actions
{
    class CleanAction : AbstractAction
    {
        public CleanAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "cleaning up";

        public override RoomType Room => RoomType.Unknown;

        protected override List<ItemType> _usingItems => null;
    }
}
