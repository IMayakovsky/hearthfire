using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    public class OrderRepairmanAction : AbstractAction
    {
        public override string Description => "ordering repairman for " + _item.Data.Name;

        protected override List<ItemType> _usingItems => null;

        public override RoomType Room => RoomType.Unknown;

        private FullItem _item;

        public OrderRepairmanAction(FullItem item, IActionsContext context, byte period) : base(context, period)
        {
            _item = item;
            Supervisor.Instance.ItemsManager.AddBrokenItem(_item.Main);
        }
    }
}
