using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Zavrel.Kitchen_010
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
                Supervisor.Instance.ItemsManager.AddContent(id, "Omelette", 6);
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
            if (!Supervisor.Instance.ItemsManager.TakeContent(id, "Rohlic") || 
                !Supervisor.Instance.ItemsManager.TakeContent(id, "Sunka"))
            {
                _context.AddDuty(new MakeFastFoodAction(_context, 0));
            }

            base.DoActionAtFirst();
        }
    }


    public class MakeFastFoodAction : AbstractAction
    {
        public MakeFastFoodAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "making fast food";

        public override RoomType Room => RoomType.Kitchen_010;

        protected override List<ItemType> _usingItems => new List<ItemType> { ItemType.Microwave_010 };
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
                Supervisor.Instance.ItemsManager.AddContent(id, "Meat", 6);
                Supervisor.Instance.ItemsManager.AddContent(id, "Soup", 6);
            }
        }
    }


    public class EatAction : AbstractAction
    {
        public EatAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "eating";

        protected override List<ItemType> _usingItems => null;

        protected override void DoActionAtFirst()
        {
            string id = ((int)RoomType.Kitchen_010).ToString() + ((int)ItemType.Fridge_010).ToString();
            if (!Supervisor.Instance.ItemsManager.TakeContent(id, "Meat") ||
                !Supervisor.Instance.ItemsManager.TakeContent(id, "Soup"))
            {
                _context.AddDuty(new MakeFastFoodAction(_context, 0));
            }

            base.DoActionAtFirst();
        }
    }


    public class TakeBearAction : AbstractAction
    {
        public TakeBearAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "taking bear";

        public override RoomType Room => RoomType.Kitchen_010;

        protected override List<ItemType> _usingItems => null;

        protected override void DoActionAtFirst()
        {
            string id = ((int)RoomType.Kitchen_010).ToString() + ((int)ItemType.Fridge_010).ToString();
            Supervisor.Instance.ItemsManager.TakeContent(id, "Beer");

            base.DoActionAtFirst();
        }
    }


    public class StudyWithDominikAction : AbstractAction
    {
        public StudyWithDominikAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "studing with Dominik";

        protected override List<ItemType> _usingItems => null;
    }


    public class StudyDominikAction : AbstractAction
    {
        public StudyDominikAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override RoomType Room => RoomType.Kitchen_010;

        public override string Description => "studing with morther";

        protected override List<ItemType> _usingItems => null;
    }

    public class LookThroughWindowAction : AbstractAction
    {
        public LookThroughWindowAction(IActionsContext context, byte period) : base(context, period)
        {
        }

        public override string Description => "looking through the window";

        public override RoomType Room => RoomType.Kitchen_010;

        protected override List<ItemType> _usingItems => null;
    }
}
