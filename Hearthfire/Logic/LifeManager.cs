using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hearthfire.Logic;
using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Hvorostovsky.Strategy;
using Hearthfire.Life.Strategy;
using Hearthfire.Models;
using Hearthfire.ViewModels;
using System.Linq;
using Hearthfire.Life.Hvorostovsky;
using Hearthfire.Life.Zavrel;

namespace Hearthfire
{
    public class LifeManager : ILifeManager
    {
        private Dictionary<int, Resident> _people;
        private ConsoleViewModel _console;
        private DayStrategy _strategy;

        private object _locker = new object();
        private int _startHour = 0;
        private bool _wasFinished = false;
        private bool _timeWasStopped = true;

        private IFamilyFactory _familyFactory;
        private int _personWaiting = 50; //400
        private int _hourWaiting = 100; // 500

        public LifeManager(MainSavesData savesData)
        {
            _personWaiting = savesData.PersonWaiting;
            _hourWaiting = savesData.HourWaiting;

            if (savesData.Family == "Zavrel")
                _familyFactory = new ZavrelFactory();
            else
                _familyFactory = new HvorostovkyFactory();

            _people = _familyFactory.GenerateFamily();
            _console = Supervisor.Instance.Console;
        }

        private void SetLifeInit()
        {
            DayOfWeek day = Supervisor.Instance.Time.DayOfWeek;
            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                _strategy = new SaturdayStrategy(_people.Values);
            else
                _strategy = new WeekdayStrategy(_people.Values);

            _startHour = Supervisor.Instance.Time.Hour;
            _strategy.Restart(_people.Values);
        }

        public void Stop()
        {
            lock (_locker) { _timeWasStopped = true; }
        }

        public void ChangeSpeed(bool increase)
        {
            if (increase)
            {
                _hourWaiting -= 100;
                _personWaiting -= 50;

                if (_hourWaiting < 20)
                    _hourWaiting = 20;

                if (_personWaiting < 30)
                    _personWaiting = 20;
            }
            else
            {
                _hourWaiting += 100;
                _personWaiting += 20;
            }
        }

        public void Finish()
        {
            lock (_locker) 
            {
                if (_timeWasStopped)
                {
                    SavePeopleInfo();
                }
                else
                {
                    _timeWasStopped = true;
                    _wasFinished = true;
                }
            }
        }

        public void SavePeopleInfo()
        {
            int maxHours = 0;

            foreach (Resident p in _people.Values)
            {
                int hours = p.FinishAllDuties();

                if (hours > maxHours)
                    maxHours = hours;
            }

            Supervisor.Instance.Time.Increase(maxHours);
            //FileData.SaveTime(Supervisor.Instance.Time.Ticks);
        }

        public void Run()
        {
            if (!_timeWasStopped)
                return;

            _timeWasStopped = false;
            Task.Run(Update);
        }

        private void Update()
        {
            if (_startHour == 0)
            {
                _console.Log(Supervisor.Instance.Time.DayOfWeek.ToString() + " starts");
                CheckStrategy();
            }

            StartNewDay();
            _strategy.CalculateConsumptions();
        }

        private void CheckStrategy()
        {
            if (_strategy == null)
            {
                SetLifeInit();
                return;
            }
            switch (Supervisor.Instance.Time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    _strategy = new WeekdayStrategy(_people.Values);
                    break;
                case DayOfWeek.Saturday:
                    _strategy = new SaturdayStrategy(_people.Values);
                    break;
                case DayOfWeek.Sunday:
                    _strategy = new SundayStrategy(_people.Values);
                    break;
            }
            _strategy.Restart(_people.Values);
        }

        /// <summary>
        /// Represents logic of one day
        /// </summary>
        private void StartNewDay()
        {
            string day = Supervisor.Instance.Time.DayOfWeek.ToString();
            string date = Supervisor.Instance.Time.DateToString;

            for (int i = _startHour; i < LifeTime.ALL_TIME; i++)
            {
                foreach(Resident person in _people.Values)
                {
                    person.Update();
                    Thread.Sleep(_personWaiting);
                }
                Supervisor.Instance.Time.Increase();

                _familyFactory.GenerateRandomEvent(_people, i + 1);

                Supervisor.Instance.ItemsManager.CheckBrokenItems();

                Thread.Sleep(_hourWaiting);

                lock(_locker)
                {
                    if (_timeWasStopped)
                    {
                        if (_wasFinished)
                        {
                            SavePeopleInfo();
                            return;
                        }
                            
                        Supervisor.Instance.MainWindow.OptionView.StopModeWasActivated();
                        _startHour = i + 1;
                        return;
                    }
                }
            }
            _startHour = 0;

            _console.SaveLogs(date);
            _console.Log(day + " is over");

            Thread.Sleep(2000);
            Task.Run(Update);
        }

        public Resident GetPerson(int id)
        {
            return _people[id];
        }

        public bool IsPersonAvailable(int id)
        {
            return _people[id].AtHome;
        }

        public void UseItemByPerson(Resident person, RoomType roomType, ItemType itemType)
        {
            Room room = Supervisor.Instance.Database.GetRoomByType(roomType);
            ItemData itemData = Supervisor.Instance.Database.GetItemDataByType(itemType);

            if (room == null || itemData == null || !room.Content.ContainsKey(itemType))
            {
                person.NextAction();
                return;
            }

            Item item = room.Content[itemType];
            
            Supervisor.Instance.ItemsManager.TryToUseItem(item, itemData, person, room);
        }

        public IEnumerable<PersonModel> GetPersonViewModels()
        {
            return _people.Select(elem => new PersonModel(elem.Value));
        }
    }
}
