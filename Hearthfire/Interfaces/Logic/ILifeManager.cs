using Hearthfire.Enities.Enums;
using Hearthfire.Life.Actions;
using Hearthfire.Models;
using System.Collections.Generic;

namespace Hearthfire.Interfaces
{
    public interface ILifeManager
    {
        delegate AbstractAction NextAction();

        void ChangeSpeed(bool increase);

        void Stop();

        void Finish();

        void SavePeopleInfo();

        void Run();

        Resident GetPerson(int id);

        IEnumerable<PersonModel> GetPersonViewModels();

        bool IsPersonAvailable(int id);

        void UseItemByPerson(Resident person, RoomType roomType, ItemType itemType);
    }
}
