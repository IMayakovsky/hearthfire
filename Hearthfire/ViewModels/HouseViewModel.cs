using Hearthfire.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hearthfire.ViewModels
{
    class HouseViewModel : MvxViewModel
    {
        public IMvxCommand ContentItemClickCommand { get; private set; }

        private ObservableCollection<Section> _sections;

        public ObservableCollection<Section> Content
        {
            get => _sections;
            set
            {
                SetProperty(ref _sections, value);
            }
        }

        public HouseViewModel()
        {
            _sections = new ObservableCollection<Section>(Supervisor.Instance.Database.GetAllSections());
            ContentItemClickCommand = new MvxCommand<Section>(section => ContentItemOnClick(section));
        }

        private void ContentItemOnClick(Section section)
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new SectionViewModel(section));
        }
    }
}
