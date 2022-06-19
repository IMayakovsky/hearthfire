using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    public class TravelAction : AbstractAction
    {
        public TravelAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "traviling";

        public override RoomType Room => RoomType.Outside;

        protected override List<ItemType> _usingItems => null;
    }
}
