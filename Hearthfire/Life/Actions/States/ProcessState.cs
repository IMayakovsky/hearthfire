using Hearthfire.Interfaces;

namespace Hearthfire.Life.Actions.States
{
    class ProcessState : State
    {
        public ProcessState(IStateContext context, int period) : base(context)
        {
            _period = period;
        }

        public override string Description => " is ";

        public override void ToNextState()
        {
            _context.SetState(new FinishState(_context));
        }
    }
}
