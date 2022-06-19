using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    public class OrderFoodAction : AbstractAction
    {
        public OrderFoodAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "ordering food";

        public override RoomType Room => RoomType.Unknown;

        protected override List<ItemType> _usingItems => null;
    }
}
