using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.ViewModels
{
    class MetersViewModel : MvxViewModel
    {
        private int _water;

        public int Water
        {
            get => _water;
            set => SetProperty(ref _water, value);
        }

        private int _electricity;

        public int Electricity
        {
            get => _electricity;
            set => SetProperty(ref _electricity, value);
        }

        private int _gas;

        public int Gas
        {
            get => _gas;
            set => SetProperty(ref _gas, value);
        }

        public MetersViewModel()
        {
            IMetersManager manager = Supervisor.Instance.Meters;

            Water = manager.GetMeterValueByType(MeterType.Water);
            Electricity = manager.GetMeterValueByType(MeterType.Electricity);
            Gas = manager.GetMeterValueByType(MeterType.Gas);

            manager.MetersDataWasChanged += OnMetersDataWasChanged;
        }

        private void OnMetersDataWasChanged(object sender, MetersData data)
        {
            switch(data.Type)
            {
                case MeterType.Water:
                    Water = data.Value;
                    break;
                case MeterType.Electricity:
                    Electricity = data.Value;
                    break;
                case MeterType.Gas:
                    Gas = data.Value;
                    break;
            }
        }
    }
}
