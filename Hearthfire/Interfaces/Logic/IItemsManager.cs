using Hearthfire.Enities;
using Hearthfire.Enities.Enums;
using Hearthfire.Models;
using Hearthfire.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthfire.Interfaces
{
    public interface IItemsManager
    {
        void TryToUseItem(Item item, ItemData data, Resident person, Room room);

        void AddContent(string itemId, string name, byte amount = 1);

        bool TakeContent(string id, string name);

        void AddBrokenItem(Item item);

        void CheckBrokenItems();

        void Subscribe(ItemViewModel viewModel);

        void Unsubscribe();
    }
}
