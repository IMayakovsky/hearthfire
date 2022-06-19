using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using System;

namespace Hearthfire.Interfaces
{
    public interface IActionsContext
    {
        Action<string> StatusWasChanged { get; set; }

        void NextAction();

        void UseItem(RoomType room, ItemType item);

        void AddDuty(AbstractAction duty);
    }
}
