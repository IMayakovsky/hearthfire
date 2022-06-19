using System.Collections.Generic;

namespace Hearthfire.Interfaces
{
    interface IFamilyFactory
    {
        Dictionary<int, Resident> GenerateFamily();

        void GenerateRandomEvent(Dictionary<int, Resident> people, int hour);
    }
}
