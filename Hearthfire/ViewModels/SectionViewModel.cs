using Hearthfire.Enities;
using Hearthfire.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Hearthfire.ViewModels
{
    class SectionViewModel : MvxViewModel
    {
        public IMvxCommand ContentItemClickCommand { get; private set; }

        private ObservableCollection<Room> _rooms;

        public ObservableCollection<Room> Content
        {
            get => _rooms;
            set
            {
                SetProperty(ref _rooms, value);
            }
        }

        private int _id;

        public SectionViewModel(Section section)
        {
            _id = section.Id;
            _rooms = new ObservableCollection<Room>(section.Content.Values);
            ContentItemClickCommand = new MvxCommand<Room>(room => ContentItemOnClick(room));
        }

        private void ContentItemOnClick(Room room)
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new RoomViewModel(room.Content.Values, room.Id));
        }
    }
}
