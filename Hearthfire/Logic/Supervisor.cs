using Hearthfire.Logic;
using Hearthfire.Enities;
using Hearthfire.Interfaces;
using Hearthfire.ViewModels;

namespace Hearthfire
{
    public class Supervisor
    {
        public static Supervisor Instance { get; } = new Supervisor();

        public MainWindow MainWindow { get; private set; }
        public Database Database { get; private set; }
        public ConsoleViewModel Console { get; private set; }
        public LifeTime Time { get; private set; }

        public IMetersManager Meters { get; private set; }
        public ILifeManager LifeManager { get; set; }
        public IItemsManager ItemsManager { get; private set; }


        private Supervisor() { }

        public void Start(string family)
        {
            FileData.ClearLogs();
            MainSavesData savesData = FileData.LoadMainSaves();
            savesData.Family = family;

            Init(savesData);
        }

        private void Init(MainSavesData savesData)
        {
            Database = new Database(savesData.Family);
            Time = new LifeTime(savesData.Time);
            MainWindow = new MainWindow(savesData.Family);
            Meters = new MetersManager();

            Database.LoadData();

            Console = new ConsoleViewModel();
            ItemsManager = new ItemsManager();
            LifeManager = new LifeManager(savesData);
        }

        public void Exit()
        {
            Database.SaveSections();
            Console.SaveLogs(Time.DateToString);
            //Life.Finish();
        }
       
    }
}
