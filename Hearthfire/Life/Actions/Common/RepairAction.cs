using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions.States;
using Hearthfire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Actions
{
    public class RepairAction : AbstractAction
    {
        public override string Description { get; }

        protected override List<ItemType> _usingItems => null;

        public override RoomType Room => (RoomType)_item.RoomId;

        private FullItem _item;


        public RepairAction(FullItem item, IActionsContext context, byte period) 
            : base(context, period)
        {
            _item = item;
            Description = "repair " + item.Data.Name;
        }

        public override void SetState(State state) 
        {
            base.SetState(state);

            if (state == null)
                _item.Main.Repair();
        }

    }
}
