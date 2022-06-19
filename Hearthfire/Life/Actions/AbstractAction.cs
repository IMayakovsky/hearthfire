using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions.States;
using Hearthfire.Logic;
using Hearthfire.Models;
using System.Collections.Generic;

namespace Hearthfire.Life.Actions
{
    public abstract class AbstractAction : IStateContext
    {
        private State _state;

        protected IActionsContext _context;

        protected int _usingItemIdx = 0;
        protected int _speed = 1;

        public byte Period { get; set; }

        public abstract string Description { get; }

        public abstract RoomType Room { get; }

        protected abstract List<ItemType> _usingItems { get; }

        public string Status { get => _state?.Description + Description; }

        public AbstractAction(IActionsContext context, byte period)
        {
            _context = context;
            Period = period;

            if (period != 0)
            {
                int itemsAmount = _usingItems?.Count ?? 0;
                _speed = itemsAmount / period + itemsAmount % period;
            }
            else
                _speed = _usingItems?.Count ?? 0;
        }

        public void Init()
        {
            if (Period >= 1)
                SetState(new StartState(this, Period));
            else
                _context.StatusWasChanged?.Invoke(" is " + Description);
            DoActionAtFirst();
        }

        public void Update()
        {
            _state?.Update();

            if (_state == null)
                ToNextAction();
            else if (Period > 0)
                DoAction();
        }

        private void ToNextAction()
        {
            _context.NextAction();
        }

        public bool IsPossible()
        {
            Database db = Supervisor.Instance.Database;

            if (Room != RoomType.Unknown && Room != RoomType.Outside && !db.DoesRoomExist(Room))
                return false;

            if (_usingItems == null)
                return true;

            Room room = db.GetRoomByType(Room);

            foreach (ItemType itemType in _usingItems)
            {
                if (!room.Content.ContainsKey(itemType) || room.Content[itemType].IsBroken)
                    return false;
            }

            return true;
        }

        public virtual void SetState(State state)
        {
            _state = state;

            if (state != null)
                _context.StatusWasChanged?.Invoke(Status);
        }

        protected virtual void DoAction()
        {
            int lastIdx = _speed + _usingItemIdx;

            for (int i = _usingItemIdx; i < lastIdx && i < _usingItems.Count; i++)
                _context.UseItem(Room, _usingItems[i]);

            _usingItemIdx = lastIdx;
            Period--;
        }

        protected virtual void DoActionAtFirst()
        {
            DoAction();
            if (Period > 0)
                _speed = (_usingItems?.Count ?? 0) / (Period + 1);
        }
    }
}
