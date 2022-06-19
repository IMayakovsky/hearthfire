using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Actions
{
    public class WalkAction : AbstractAction
    {
        public WalkAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "walking";

        public override RoomType Room => RoomType.Outside;

        protected override List<ItemType> _usingItems => null;
    }
}
