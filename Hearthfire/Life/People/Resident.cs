using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Actions;
using Hearthfire.Logic;
using System;
using System.Collections.Generic;
using static Hearthfire.Interfaces.ILifeManager;

namespace Hearthfire
{
    public abstract class Resident : IActionsContext
    {
        public AbstractAction ActiveAction;

        private AbstractAction _waitingAction;

        protected List<NextAction> _routins = new List<NextAction>();

        public Queue<AbstractAction> Duties { get; private set; }

        public byte ActionIndex { get; private set; }

        protected bool _isNecessaryActionChecking = false;
        protected int _stoppedHour = 0;

        public Action<string> StatusWasChanged { get; set; }

        public string Status { get => ActiveAction?.Status ?? "None"; }

        public bool AtHome { get => (ActiveAction?.Room ?? RoomType.Outside) != RoomType.Outside; }

        public abstract int Id { get; }
        public abstract string Name { get; }
        public abstract string SecondName { get; }
        public abstract string Image { get; }

        public Resident()
        {
            Duties = new Queue<AbstractAction>();
            StatusWasChanged += (e) => { Supervisor.Instance.Console.Log(Name + e); };
        }

        public void Update()
        {
            ActiveAction?.Update();
        }

        public void Init(byte index, byte period)
        {
            ActionIndex = index;
            ActiveAction = _routins[ActionIndex].Invoke();

            if (period != 0)
                ActiveAction.Period = period;

            ActiveAction.Init();
        }

        public void Restart()
        {
            ActionIndex = 0;

            if (_routins.Count < 1)
                return;

            ActiveAction = _routins[ActionIndex].Invoke();
            ActiveAction.Init();
        }

        public void NextAction()
        {
            if (Duties.Count != 0)
            {
                _waitingAction = ActiveAction;
                ActiveAction = Duties.Dequeue();
            }
            else if (_waitingAction != null)
            {
                ActiveAction = _waitingAction;
                _waitingAction = null;
                return;
            }
            else if (ActionIndex + 1 >= _routins.Count)
            {
                byte period = (byte)(LifeTime.ALL_TIME - Supervisor.Instance.Time.Hour);
                if (period > 0)
                    SwitchToFavoriteAction(period);
            }
            else
                ActiveAction = _routins[++ActionIndex].Invoke();

            if (!ActiveAction.IsPossible())
            {
                Supervisor.Instance.Console.Log(ActiveAction.Description + " is not possible for " + Name);
                SwitchToFavoriteAction(ActiveAction.Period);
            }

            ActiveAction.Init();
            ActiveAction.Update();
        }


        public void UseItem(RoomType room, ItemType item)
        {
            Supervisor.Instance.LifeManager.UseItemByPerson(this, room, item);
        }

        public void AddDuty(AbstractAction duty)
        {
            Duties.Enqueue(duty);
            NextAction();
        }
        
        public int FinishAllDuties()
        {
            if (Duties.Count == 0)
                return 0;

            int hours = ActiveAction.Period;

            /*foreach (Duty duty in Duties)
            {
                hours += duty.Period;
                duty.Finish();
            }*/

            return hours;
        }

        public abstract void SetWeekdayActionsChain();

        public abstract void SetSaturdayActionsChain();

        public abstract void SetSundayActionsChain();

        public abstract void SwitchToFavoriteAction(byte period);

        public abstract void OnItemWasBroken(FullItem item);

    }
}
