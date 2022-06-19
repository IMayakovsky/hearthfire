using MvvmCross.ViewModels;
using System.Windows.Data;
using System.Collections.ObjectModel;
using MvvmCross.Commands;
using Hearthfire.Models;
using Hearthfire.Logic;

namespace Hearthfire.ViewModels
{
    public class ConsoleViewModel : MvxViewModel
    {
        private readonly object _textBoxesLock = new object();
        private ObservableCollection<ConsoleMessage> _messages = new ObservableCollection<ConsoleMessage>();

        public IMvxCommand WriteCommand { get; set; }
        public IMvxCommand OpenFolderCommand { get; set; }

        public ObservableCollection<ConsoleMessage> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public ConsoleViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(_messages, _textBoxesLock);
            WriteCommand = new MvxCommand(() => FileData.SaveMainLogs(Messages, Supervisor.Instance.Time.DateToString, true));
            OpenFolderCommand = new MvxCommand(FileData.OpenLogFolder);
        }

        public void Log(string text)
        {
            ConsoleMessage mes = new ConsoleMessage
            {
                Date = Supervisor.Instance.Time.HoursToString,
                Text = text
            };
             _messages.Add(mes);
        }

        public void SaveLogs(string day)
        {
            FileData.SaveMainLogs(Messages, day);
            Messages.Clear();
        }
    }

}
