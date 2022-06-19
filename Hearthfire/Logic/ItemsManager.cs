using Hearthfire.Enities;
using Hearthfire.Interfaces;
using Hearthfire.Models;
using Hearthfire.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hearthfire.Logic
{
    public class ItemsManager : IItemsManager
    {
        private ItemViewModel _activeItemViewModel;
        private Dictionary<string, Dictionary<string, byte>> _content = new Dictionary<string, Dictionary<string, byte>>();
        private Dictionary<Item, long> _brokenItems = new Dictionary<Item, long>();

        private void GenerateLog(string id, string log)
        {
            Supervisor.Instance.Console.Log(log);
            log = FileData.CreateItemLog(id, log);

            if (_activeItemViewModel != null && _activeItemViewModel.Id == id)
                _activeItemViewModel?.Interactions.Add(log);
        }


        public void TryToUseItem(Item item, ItemData data, Resident person, Room room)
        {
            Supervisor.Instance.Meters.Increase(data.MeterType, data.Consumption);

            string log = person.Name + " used " + data.Name + " in the " + room.Name;
            string itemId = room.Id.ToString() + item.DataId.ToString();

            GenerateLog(itemId, log);

            if (item.IsBroken || item.Use())
                return;

            log = data.Name + " has been broken";

            GenerateLog(itemId, log);

            person.OnItemWasBroken(new FullItem(item, data, room.Id));
        }


        public void AddContent(string itemId, string name, byte amount = 1)
        {
            if (_content.ContainsKey(itemId))
            {
                if (_content[itemId].ContainsKey(name))
                    _content[itemId][name] += amount;
                else
                    _content[itemId][name] = amount;
            }
            else
            {
                _content[itemId] = new Dictionary<string, byte>();
                _content[itemId][name] = amount;
            }

            if (_activeItemViewModel != null && _activeItemViewModel.Id == itemId)
            {
                _activeItemViewModel?.SetContent(new ObservableCollection<ItemContent>(
                    _content[itemId].Select(e => new ItemContent(e.Key, e.Value))
                ));
            }
                
        }


        public bool TakeContent(string itemId, string name)
        {
            if (!_content.ContainsKey(itemId) || !_content[itemId].ContainsKey(name))
                return false;

            _content[itemId][name]--;

            if (_content[itemId][name] <= 0)
                _content[itemId].Remove(name);

            if (_activeItemViewModel != null && _activeItemViewModel.Id == itemId)
            {
                _activeItemViewModel?.SetContent(new ObservableCollection<ItemContent>(
                    _content[itemId].Select(e => new ItemContent(e.Key, e.Value))
                ));
            }

            return true;
        }

        public void AddBrokenItem(Item item)
        {
            _brokenItems[item] = new DateTime(Supervisor.Instance.Time.Ticks).AddHours(5).Ticks;
        }

        public void CheckBrokenItems()
        {
            foreach (Item item in _brokenItems.Keys)
            {
                if (_brokenItems[item] <= Supervisor.Instance.Time.Ticks)
                {
                    item.Repair();
                    _brokenItems.Remove(item);
                }
            }
        }

        public void Subscribe(ItemViewModel viewModel)
        {
            _activeItemViewModel = viewModel;

            IEnumerable<ItemContent> content = _content.ContainsKey(viewModel.Id) ?
                _content[viewModel.Id].Select(e => new ItemContent(e.Key, e.Value)) : new List<ItemContent>();

            _activeItemViewModel.SetContent(content);
        }


        public void Unsubscribe()
        {
            _activeItemViewModel = null;
        }
    }
}
