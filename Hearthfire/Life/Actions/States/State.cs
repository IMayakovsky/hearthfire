using Hearthfire.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Life.Actions.States
{
    public abstract class State
    {
        public abstract string Description { get; }
        protected int _period = 1;
        protected IStateContext _context;

        public State(IStateContext context)
        {
            _context = context;
        }

        public abstract void ToNextState();

        public void Update()
        {
            _period--;

            if (_period <= 0)
                ToNextState();
        }

    }
}
