using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Hearthfire.ViewModels
{
    class MenuViewModel : MvxViewModel
    {
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
            }
        }

        public IMvxCommand GaugeClickCommand { get; private set; }
        public IMvxCommand ConsoleClickCommand { get; private set; }
        public IMvxCommand HouseClickCommand { get; private set; }
        public IMvxCommand SettingsClickCommand { get; private set; }
        public IMvxCommand PeopleClickCommand { get; private set; }

        public MenuViewModel()
        {
            GaugeClickCommand = new MvxCommand(OpenMetersView);
            ConsoleClickCommand = new MvxCommand(OpenConsoleView);
            HouseClickCommand = new MvxCommand(OpenHouseView);
            PeopleClickCommand = new MvxCommand(OpenPeopleView);
            SettingsClickCommand = new MvxCommand(OpenSettingsView);
        }

        public void OpenMetersView()
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new MetersViewModel());
        }

        public void OpenConsoleView()
        {
            Supervisor.Instance.MainWindow.AddContentToStack(Supervisor.Instance.Console);
        }

        public void OpenHouseView()
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new HouseViewModel());
        }

        public void OpenPeopleView()
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new PeopleViewModel(Supervisor.Instance.LifeManager.GetPersonViewModels()));
        }

        public void OpenSettingsView()
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new SettingsViewModel());
        }
    }
}
