using Hearthfire.Enities.Enums;
using Hearthfire.Logic;
using MvvmCross.ViewModels;
using System;

namespace Hearthfire.ViewModels
{
    public class PersonViewModel : MvxViewModel
    {
        private Resident _person;

        public string Name 
        { 
            get => _person.Name;
        }

        public string FullName
        {
            get => _person.Name + " " + _person.SecondName;
        }

        private string _status;

        public string Status 
        {
            get =>  _status;
            set => SetProperty(ref _status, value);
        }

        private RoomType _room;
        private string _location;

        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        public string Image { get => _person.Image; }

        private Action<string> _handlerStatusWasChanged;

        public PersonViewModel(Resident person)
        {
            _person = person;
            Status = person.ActiveAction?.Description ?? "Unknown";
            _room = _person.ActiveAction?.Room ?? RoomType.Unknown;
            Location = Supervisor.Instance.Database.GetRoomByType(_room)?.Name ?? "Unknown";

            _handlerStatusWasChanged = (e) => OnStatusWasChanged(person.ActiveAction?.Description ?? "Unknown", 
                person.ActiveAction?.Room ?? RoomType.Unknown);
            _person.StatusWasChanged += _handlerStatusWasChanged;
        }

        private void OnStatusWasChanged(string status, RoomType roomType)
        {
            if (_status != status)
                Status = status;
           
            if (_room != roomType)
            {
                _room = roomType;

                if (_room == RoomType.Outside || _room == RoomType.Unknown)
                    Location = _room.ToString();
                else
                    Location = Supervisor.Instance.Database.GetRoomByType(_room)?.Name ?? "Unknown";
            }
        }

        public override void ViewDisappearing()
        {
            _person.StatusWasChanged -= _handlerStatusWasChanged;
        }
    }
}
