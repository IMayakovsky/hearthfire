using Hearthfire.Enities.Enums;
using Hearthfire.Interfaces;
using System;
using System.Collections.Generic;

namespace Hearthfire.Life.Zavrel
{
    public class ZavrelFactory : IFamilyFactory
    {
        public Dictionary<int, Resident> GenerateFamily()
        {
            Dictionary<int, Resident> family = new Dictionary<int, Resident>();

            family.Add((int)ZavrelNames.Milan, new Milan());
            family.Add((int)ZavrelNames.Ivana, new Ivana());
            family.Add((int)ZavrelNames.Michaela, new Michaela());
            family.Add((int)ZavrelNames.Patrik, new Patrik());
            family.Add((int)ZavrelNames.Dominik, new Dominik());
            family.Add((int)ZavrelNames.Ivan, new Ivan());

            family.Add((int)ZavrelNames.Bara, new Bara());
            family.Add((int)ZavrelNames.Bruno, new Bruno());
            family.Add((int)ZavrelNames.Manny, new Manny());
            family.Add((int)ZavrelNames.Dar, new Dar());
            family.Add((int)ZavrelNames.Keisy, new Keisy());

            return family;
        }

        public void GenerateRandomEvent(Dictionary<int, Resident> people, int hour)
        {
            int chance = new Random().Next(1, 100);
            DayOfWeek dayOfWeek = Supervisor.Instance.Time.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Saturday)
            {

            }
            else if (dayOfWeek == DayOfWeek.Sunday)
            {

            }
            else
            {
                if (chance < 35 && 20 <= hour && hour <= 21)
                {
                    Supervisor.Instance.Console.Log("Someone knocked on the door");
                    people[(int)ZavrelNames.Manny].AddDuty(new LivingRoom_030.MannyFearAction(people[(int)ZavrelNames.Manny], 0));
                    people[(int)ZavrelNames.Ivana].AddDuty(new Kitchen_010.LookThroughWindowAction(people[(int)ZavrelNames.Ivana], 0));
                    people[(int)ZavrelNames.Milan].AddDuty(new Collactions.OpenDoorAction(people[(int)ZavrelNames.Milan], 0));
                }
                else
                    return;
            }
        }
    }
}
