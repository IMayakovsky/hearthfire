using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using Hearthfire.Life.Hvorostovsky;
using System;
using System.Collections.Generic;

namespace Hearthfire.Life.Hvorostovsky
{
    class HvorostovkyFactory : IFamilyFactory
    {
        public Dictionary<int, Resident> GenerateFamily()
        {
            Dictionary<int, Resident> family = new Dictionary<int, Resident>();

            family.Add((int)HvorostovskyNames.Dmitri, new Dmitri());
            family.Add((int)HvorostovskyNames.Florence, new Florence());
            family.Add((int)HvorostovskyNames.Alexandra, new Alexandra());
            family.Add((int)HvorostovskyNames.Daniel, new Daniel());

            return family;
        }

        public void GenerateRandomEvent(Dictionary<int, Resident> people, int hour)
        {
            int chance = new Random().Next(1, 100);

            if (chance < 17 && 0 <= hour && hour <= 5)
            {
                people[(int)HvorostovskyNames.Daniel].AddDuty(new Bedroom_121.ScreamAction(people[(int)HvorostovskyNames.Daniel], 0));
                people[(int)HvorostovskyNames.Florence].AddDuty(new Bedroom_120.SuddenlyWakeUpAction(people[(int)HvorostovskyNames.Florence], 0));
                people[(int)HvorostovskyNames.Dmitri].AddDuty(new Bedroom_020.SuddenlyWakeUpAction(people[(int)HvorostovskyNames.Dmitri], 0));
                people[(int)HvorostovskyNames.Alexandra].AddDuty(new Bedroom_120.SuddenlyWakeUpAction(people[(int)HvorostovskyNames.Alexandra], 0));
                people[(int)HvorostovskyNames.Florence].AddDuty(new Bedroom_121.TakeCareAboutBabyAction(people[(int)HvorostovskyNames.Florence], 0));
            }
            else
                return;

            foreach (Resident person in people.Values)
                Supervisor.Instance.Console.Log(person.Name + " continues " + person.ActiveAction.Description);
        }

    }
}
