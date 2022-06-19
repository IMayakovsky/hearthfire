using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.ViewModels
{
    class SettingsViewModel : MvxViewModel
    {
        private const string MAIN_PATH = "/Database/Images/SettingsMenu/";
        private string MUSIC_ON_IMAGE => MAIN_PATH + "check.png";
        private string MUSIC_OFF_IMAGE => MAIN_PATH + "cross.png";

        public string _musicStatusImage;

        public string MusicStatusImage
        {
            get => _musicStatusImage;
            set => SetProperty(ref _musicStatusImage, value);
        }

        public IMvxCommand MusicStatusCommand { get; private set; }
        public IMvxCommand FamilyCommand { get; private set; }

        private bool _musicStatus;

        public SettingsViewModel()
        {
            _musicStatus = true;
            MusicStatusImage = MUSIC_ON_IMAGE;

            MusicStatusCommand = new MvxCommand(SwitchMusicStatus);
            FamilyCommand = new MvxCommand(SwitchFamily);
        }

        public void SwitchMusicStatus()
        {
            if (_musicStatus)
                MusicStatusImage = MUSIC_OFF_IMAGE;
            else
                MusicStatusImage = MUSIC_ON_IMAGE;

            _musicStatus = !_musicStatus;
        }

        public void SwitchFamily()
        {

        }
    }
}
