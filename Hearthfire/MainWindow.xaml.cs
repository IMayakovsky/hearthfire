using System;
using System.Collections.Generic;
using System.Windows;
using Hearthfire.ViewModels;
using MvvmCross.ViewModels;

namespace Hearthfire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<object> _contentHistory = new Stack<object>();
        private MvxViewModel _homeView;
        public OptionsViewModel OptionView { get; private set; }

        public MainWindow(string family)
        {
            InitializeComponent();
            _homeView = new MenuViewModel();
            OptionView = new OptionsViewModel(family);
            ContentT1.DataContext = _homeView;
            ContentT2.DataContext = OptionView;
        }

        public void AddContentToStack(MvxViewModel view)
        {
            _contentHistory.Push(ContentT1.DataContext);
            ContentT1.DataContext = view;
            view.ViewAppeared();
        }

        public void Back()
        {
            if (_contentHistory.Count > 0)
            {
                MvxViewModel view = (MvxViewModel)ContentT1.DataContext;
                view.ViewDisappearing();
                ContentT1.DataContext = _contentHistory.Pop();
            }
        }

        public void Home()
        {
            MvxViewModel view = (MvxViewModel)ContentT1.DataContext;
            view.ViewDisappearing();
            ContentT1.DataContext = _homeView;
            _contentHistory.Clear();
        }

        public void MainWindow_Closed(object sender, EventArgs e)
        {
            Supervisor.Instance.Exit();
        }
    }
}
