using Hearthfire.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Actions.States
{
    class StartState : State
    {
        public override string Description { get => " is starting "; }

        public StartState(IStateContext context, int action_period) : base(context)
        {
            _period = action_period;
        }

        public override void ToNextState()
        {
            _context.SetState(new FinishState(_context));
        }
    }
}
