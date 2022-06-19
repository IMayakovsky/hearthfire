using Hearthfire.Models;
using System;
using System.Collections.Generic;

namespace Hearthfire.Enities.JsonEnities
{
    [Serializable]
    public class SectionJson
    {
        public int Id;
        public string Name;
        public string Image;
        public List<RoomJson> Rooms;

        public SectionJson() { }

        public SectionJson(Section section)
        {
            Id = section.Id;
            Name = section.Name;
            Image = section.Image;
            Id = section.Id;
        }
    }
}
