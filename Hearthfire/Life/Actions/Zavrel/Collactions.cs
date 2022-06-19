using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Collactions
{
    class ShopAction : AbstractAction
    {
        public ShopAction(IActionsContext context, byte period) : base(context, period)
        {
            string id = ((int)RoomType.Kitchen_010).ToString() + ((int)ItemType.Fridge_010).ToString();
            Supervisor.Instance.ItemsManager.AddContent(id, "Rohlic", 7);
            Supervisor.Instance.ItemsManager.AddContent(id, "Maso", 5);
            Supervisor.Instance.ItemsManager.AddContent(id, "Sunka", 7);
            Supervisor.Instance.ItemsManager.AddContent(id, "Beer", 2);
        }

        public override string Description => "shoping";

        public override RoomType Room => RoomType.Unknown;

        protected override List<ItemType> _usingItems => null;
    }

    class OpenDoorAction : AbstractAction
    {
        public OpenDoorAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "opening the door";

        public override RoomType Room => RoomType.Unknown;

        protected override List<ItemType> _usingItems => null;
    }
}
