using Hearthfire.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Models
{
    public class PersonModel
    {
        private Resident _person;

        public string Name
        {
            get => _person.Name;
        }

        public string Image { get => _person.Image; }

        public PersonModel(Resident person)
        {
            _person = person;
        }

        public void ToPersonViewModel()
        {
            Supervisor.Instance.MainWindow.AddContentToStack(new PersonViewModel(_person));
        }
    }
}
