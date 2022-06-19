using Hearthfire.Interfaces;
namespace Hearthfire.Life.Actions.States
{
    class FinishState : State
    {
        public override string Description => " is finishing ";
        
        public FinishState(IStateContext context) : base(context)
        {
        }

        public override void ToNextState()
        {
            _context.SetState(null);
        }
    }
}
