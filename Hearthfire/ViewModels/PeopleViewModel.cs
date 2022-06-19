using Hearthfire.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hearthfire.ViewModels
{
    public class PeopleViewModel : MvxViewModel
    {
        public IMvxCommand ContentItemClickCommand { get; private set; }

        private ObservableCollection<PersonModel> _people;

        public ObservableCollection<PersonModel> Content
        {
            get => _people;
            set
            {
                SetProperty(ref _people, value);
            }
        }

        public PeopleViewModel(IEnumerable<PersonModel> people)
        {
            _people = new ObservableCollection<PersonModel>(people);
            ContentItemClickCommand = new MvxCommand<PersonModel>(person => person.ToPersonViewModel());
        }

        private void ContentItemOnClick(PersonModel person)
        {
            person.ToPersonViewModel();
        }
    }
}
