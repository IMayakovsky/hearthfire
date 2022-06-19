using Hearthfire.Logic;
using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Models;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Hearthfire.ViewModels
{
    public class ItemViewModel : MvxViewModel
    {
        public FullItem _item;

        public FullItem Item 
        {
            get => _item;
            private set
            {
                if (_item != null)
                    _item.Main.StatusWasChanged -= OnStatusWasChanged;
                _item = value;
                if (_item != null)
                {
                    _item.Main.StatusWasChanged += OnStatusWasChanged;
                    OnStatusWasChanged(_item.Main.IsBroken);
                }
                else
                    StatusColor = ItemStatusColor.Transporent.ToString();
            }
        }

        public byte Position { get; private set; }

        private string _image;

        public string Image 
        { 
            get => Item?.Data.Image ?? "";
            set => SetProperty(ref _image, value);
        }

        public string Consumption => Item.Data.Consumption + ", " + Item.Data.MeterType;

        private string _status;
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public string Name { get => Item?.Data.Name; }
        
        public string Location 
        {
            get
            {
                return Item == null ? "-" 
                    : Supervisor.Instance.Database.GetItemLocationByRoomId(Item.RoomId);
            }
        }

        private ObservableCollection<string> _interactions;

        public ObservableCollection<string> Interactions
        {
            get
            {
                if (_interactions == null)
                    LoadInteractions();

                return _interactions;
            }
            set => SetProperty(ref _interactions, value);
        }

        private ObservableCollection<ItemContent> _content;

        public ObservableCollection<ItemContent> Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private string _statusColor;

        public string StatusColor 
        {
            get => _statusColor ;
            set => SetProperty(ref _statusColor, value);
        }

        private readonly object _interactionsLock = new object();
        private readonly object _contentLock = new object();

        public string Id => Item.RoomId.ToString() + Item.Main.DataId.ToString();


        public ItemViewModel(FullItem fullItem)
        {
            Item = fullItem;
            Position = fullItem.Main.Pos;
        }

        public ItemViewModel(ItemViewModel model)
        {
            Item = model.Item;
            Position = model.Position;
        }

        public ItemViewModel(byte pos)
        {
            Item = null;
            Position = pos;
        }

        public void Change(ItemViewModel model)
        {
            Item = model.Item;
            if (Item != null) Item.Main.Pos = Position;
            Image = model.Image;
        }

        public void Remove()
        {
            Item = null;
        }

        public void OnStatusWasChanged(bool isBroken)
        {
            StatusColor = isBroken ? ItemStatusColor.Red.ToString() : ItemStatusColor.Green.ToString();
            Status = isBroken ? "Broken" : "OK";
        }


        private async void LoadInteractions()
        {
            IEnumerable<string> logs = await FileData.LoadItemLog(Id);
            Interactions = logs != null ? new ObservableCollection<string>(logs) : new ObservableCollection<string>();
            BindingOperations.EnableCollectionSynchronization(Interactions, _interactionsLock);
            
            Supervisor.Instance.ItemsManager.Subscribe(this);

            BindingOperations.EnableCollectionSynchronization(Content, _contentLock);
        }

        public void SetContent(IEnumerable<ItemContent> content)
        {
            Content = new ObservableCollection<ItemContent>(content);
        }

        public override void ViewDisappearing()
        {
            base.ViewDisappearing();
            Supervisor.Instance.ItemsManager.Unsubscribe();
        }
    }
}
