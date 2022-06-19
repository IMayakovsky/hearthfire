using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hearthfire.ViewModels
{
    public class RoomViewModel : MvxViewModel
    {
        public IMvxCommand GridClickCommand { get; private set; }
        public IMvxCommand SwitchActiveFuncCommand { get; private set; }
        
        private const short GRID_SIZE = 5;

        private RoomFunction _activeFunc = RoomFunction.Viewing;

        private int _id;

        private ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();

        public ObservableCollection<ItemViewModel> Items 
        { 
            get => _items; 
            set
            {
                SetProperty(ref _items, value);
            } 
        }

        private bool _isSwapActivate = false;

        public bool IsSwapActivate
        {
            get => _isSwapActivate;
            set => SetProperty(ref _isSwapActivate, value);
        }


        private int _activePoint;

        public RoomViewModel(IEnumerable<Item> items, int id)
        {
            _id = id;
            Dictionary<int, ItemViewModel> views = new Dictionary<int, ItemViewModel>();

            foreach (Item item in items)
            {
                ItemData data = Supervisor.Instance.Database.GetItemDataById(item.DataId);
                if (data != null)
                    views[item.Pos] = new ItemViewModel(new FullItem(item, data, _id));
            }

            for (byte i = 0; i < GRID_SIZE * GRID_SIZE; i++)
            {
                byte p = i;
                _items.Add(views.ContainsKey(p) ? views[p] : new ItemViewModel(p));
            }

            SetCommands();
        }

        private void GridOnClick(int p)
        {
            switch (_activeFunc)
            {
                case RoomFunction.Choosing:
                    _activeFunc = RoomFunction.Swap;
                    _activePoint = p;
                    break;
                case RoomFunction.Swap:
                    SwapItems(p, _activePoint);
                    _activeFunc = RoomFunction.Choosing;
                    break;
                default:
                    if (_items[p].Item != null)
                        Supervisor.Instance.MainWindow.AddContentToStack(_items[p]);
                    break;
            }
        }

        private void SwapItems(int a, int b)
        {
            ItemViewModel model = new ItemViewModel(_items[a]);
            _items[a].Change(_items[b]);
            _items[b].Change(model);
        }

        private void ActivateFunction(RoomFunction func)
        {
            if (func == RoomFunction.Viewing || func == _activeFunc)
            {
                _activeFunc = RoomFunction.Viewing;
                IsSwapActivate = false;
                return;
            }
            else if (func == RoomFunction.Choosing)
            {
                IsSwapActivate = true;
            }

            _activeFunc = func;
        }

        private void SetCommands()
        {
            GridClickCommand = new MvxCommand<int>(param => GridOnClick(param));
            SwitchActiveFuncCommand = new MvxCommand<RoomFunction>(param => ActivateFunction(param));
        }
    }
}
