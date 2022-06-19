using System;
using System.Windows;

namespace Hearthfire
{
    public class App : Application
    {
        private Window _initWindow;

        public void Init()
        {
            _initWindow = new InitWindow(this);
            _initWindow.Show();
        }

        public void ToMainWindow(string family)
        {
            Supervisor.Instance.Start(family);
            MainWindow = Supervisor.Instance.MainWindow;
            MainWindow.Show();
            _initWindow.Close();
        }

        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.Init();
            app.Run();
        }
    }
}
