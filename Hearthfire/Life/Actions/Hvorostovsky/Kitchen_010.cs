using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Hvorostovsky.Kitchen_010
{
    public class MakeBreakfastAction : AbstractAction
    {
        public MakeBreakfastAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "making Breakfast";

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Kettle_010, ItemType.Oven_010, ItemType.Fridge_010 };

        protected override void DoAction()
        {
            base.DoAction();

            if (_usingItemIdx == _usingItems.Count)
            {
                string id = ((int)RoomType.Kitchen_010).ToString() + ((int)ItemType.Fridge_010).ToString();
                Supervisor.Instance.ItemsManager.AddContent(id, "Burger", 3);
                Supervisor.Instance.ItemsManager.AddContent(id, "Omelette", 3);
            }
        }
    }


    public class BreakfastAction : AbstractAction
    {
        public BreakfastAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "eating (Breakfast)";

        protected override List<ItemType> _usingItems => null;

        protected override void DoActionAtFirst()
        {
            string id = ((int)RoomType.Kitchen_010).ToString() + ((int)ItemType.Fridge_010).ToString();
            Supervisor.Instance.ItemsManager.TakeContent(id, "Burger");
            Supervisor.Instance.ItemsManager.TakeContent(id, "Omelette");

            base.DoActionAtFirst();
        }
    }


    public class MakeLunchAction : AbstractAction
    {
        public MakeLunchAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "making lunch";

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Fridge_010, ItemType.Microwave_010, ItemType.Oven_010 };

        protected override void DoAction()
        {
            base.DoAction();

            if (_usingItemIdx == _usingItems.Count)
            {
                string id = ((int)RoomType.Kitchen_010).ToString() + ((int)ItemType.Fridge_010).ToString();
                Supervisor.Instance.ItemsManager.AddContent(id, "Meat", 3);
                Supervisor.Instance.ItemsManager.AddContent(id, "Soup", 3);
            }
        }
    }


    public class LunchAnction : AbstractAction
    {
        public LunchAnction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "eating lunch";

        protected override List<ItemType> _usingItems => null;
    }


    public class DinnerAction : AbstractAction
    {
        public DinnerAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "eating dinner";

        protected override List<ItemType> _usingItems => null;
    }


    public class FedBabyAction : FeedBabyAbstractAction
    {
        public FedBabyAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        protected override List<ItemType> _usingItems => null;
    }
}
