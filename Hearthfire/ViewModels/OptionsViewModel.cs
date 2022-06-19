using Hearthfire.Logic;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.ViewModels
{
    public class OptionsViewModel : MvxViewModel
    {
        private bool _isStop = true;
        private bool _isWaiting = false;

        private readonly string PAUSE_MODE = "menu/pause.png";
        private readonly string PLAY_MODE = "menu/play.png";
        private readonly string CHANGE_SPEED_IMAGE = "menu/up.png";

        public IMvxCommand BackCommand { get; private set; }
        public IMvxCommand HomeCommand { get; private set; }
        public IMvxCommand SwitchLifeTimeCommand { get; private set; }
        public IMvxCommand IncreaseSpeedCommand { get; private set; }
        public IMvxCommand DecreaseSpeedCommand { get; private set; }

        private string _modeImagePath;

        public string ModeImagePath
        {
            get => _modeImagePath;
            set
            {
                SetProperty(ref _modeImagePath, value);
            }
        }

        public string ChangeSpeedImage => ResPath.Images + CHANGE_SPEED_IMAGE;

        private string _modeComment;

        public string FamilyName
        {
            get => _modeComment;
            set
            {
                SetProperty(ref _modeComment, value);
            }
        }

        private string _dateText;

        public string DateText
        {
            get => _dateText;
            set
            {
                SetProperty(ref _dateText, value);
            }
        }

        public OptionsViewModel(string family)
        {
            ModeImagePath = ResPath.Images + PLAY_MODE;
            FamilyName = family;
            DateText = Supervisor.Instance.Time.DateAndTimeToString;

            Supervisor.Instance.Time.TimeWasChanged += OnTimeWasChanged;

            BackCommand = new MvxCommand(BackOnClick);
            HomeCommand = new MvxCommand(HomeOnClick);
            SwitchLifeTimeCommand = new MvxCommand(SwitchLifeTime);
            IncreaseSpeedCommand = new MvxCommand(IncreaseSpeed);
            DecreaseSpeedCommand = new MvxCommand(DecreaseSpeed);
        }

        private void BackOnClick()
        {
            Supervisor.Instance.MainWindow.Back();
        }

        private void HomeOnClick()
        {
            Supervisor.Instance.MainWindow.Home();
        }

        private void SwitchLifeTime()
        {
            if (_isWaiting) return;

            _isStop = !_isStop;

            if (_isStop)
            {
                _isWaiting = true;
                Supervisor.Instance.LifeManager.Stop();
                DateText = "Waiting until the day ends";
            }
            else
            {
                Supervisor.Instance.LifeManager.Run();
                ModeImagePath = ResPath.Images + PAUSE_MODE;
            }
        }

        private void IncreaseSpeed()
        {
            Supervisor.Instance.LifeManager.ChangeSpeed(true);
        }

        private void DecreaseSpeed()
        {
            Supervisor.Instance.LifeManager.ChangeSpeed(false);
        }

        public void StopModeWasActivated()
        {
            _isWaiting = false;
            DateText = Supervisor.Instance.Time.DateAndTimeToString;
            ModeImagePath = ResPath.Images + PLAY_MODE;
        }

        private void OnTimeWasChanged(string date)
        {
            DateText = date;
        }
    }
}
