using Hearthfire.Enities.JsonEnities;
using Hearthfire.Logic;
using System.Collections.Generic;

namespace Hearthfire.Models
{
    public class Section
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Image { get; private set; }

        public Dictionary<int, Room> Content { get; private set; } = new Dictionary<int, Room>();

        public Section(SectionJson json)
        {
            Id = json.Id;
            Name = json.Name;
            Image = json.Image;

            foreach(RoomJson room in json.Rooms)
            {
                room.Image = room.Image == null ? ResPath.Section : ResPath.Rooms + room.Image;

                Content[room.Id] = new Room(room);
            }
        }
    }
}
