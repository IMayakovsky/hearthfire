using Hearthfire.Enities;
using Hearthfire.Enities.JsonEnities;
using Hearthfire.Enities.Enums;
using Hearthfire.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hearthfire.Logic
{
    public class Database
    {
        private readonly Dictionary<int, Section> _sections = new Dictionary<int, Section>();
        private readonly Dictionary<int, ItemData> _itemsData = new Dictionary<int, ItemData>();

        private readonly ResPath _path;

        public Database(string familyName)
        {
            _path = new ResPath(familyName);
        }

        public Dictionary<int, ItemData> GetRoomItems(List<Item> itemsPos)
        {
            Dictionary<int, ItemData> items = new Dictionary<int, ItemData>();

            foreach (Item item in itemsPos)
            {
                items[item.Pos] = _itemsData[item.DataId];
            }

            return items;
        }


        public bool DoesRoomExist(RoomType type)
        {
            int sectionId = (int)type / 100;

            return _sections.ContainsKey(sectionId) && _sections[sectionId].Content.ContainsKey((int)type);
        }

        public bool DoesItemDataExist(ItemType type)
        {
            return _itemsData.ContainsKey((int)type);
        }

        public Room GetRoomByType(RoomType type)
        {
            int sectionId = (int)type / 100;

            try { return _sections[sectionId].Content[(int)type]; }
            catch (KeyNotFoundException) { return null; }
        }

        public ItemData GetItemDataByType(ItemType type)
        {
            try { return _itemsData[(int)type]; }
            catch (KeyNotFoundException) { return null; }
        }

        public ItemData GetItemDataById(int id)
        {
            try { return _itemsData[id]; }
            catch (KeyNotFoundException) { return null; }
        }

        public string GetItemLocationByRoomId(int id)
        {
            int sectionId = id / 100;

            if (!_sections.ContainsKey(sectionId) || !_sections[sectionId].Content.ContainsKey(id))
                return "Is not known";

            string location = _sections[sectionId].Name + ", " + _sections[sectionId].Content[id].Name;

            return location;
        }

        public IEnumerable<Section> GetAllSections()
        {
            return _sections.Values;
        }

        public void LoadData()
        {
            try
            {
                List<ItemData> items = LoadJsonArray<List<ItemData>>(_path.ItemsPath);
                if (items != null)
                    SetItems(items);

                List<SectionJson> sections = LoadJsonArray<List<SectionJson>>(_path.HousePath);
                if (sections != null)
                    SetSections(sections);

            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private void SetItems(List<ItemData> array)
        {
            foreach (ItemData item in array)
            {
                item.Image = ResPath.Rooms + item.Image;
                _itemsData[item.Id] = item;
            }
        }

        private void SetSections(List<SectionJson> array)
        {
            foreach (SectionJson sectionJson in array)
            {
                if (_sections.ContainsKey(sectionJson.Id))
                    continue;

                if (sectionJson.Image == null)
                    sectionJson.Image = ResPath.Section;
                _sections[sectionJson.Id] = new Section(sectionJson);
            }
        }


        private T LoadJsonArray<T>(string path)
        {
            string json = GetFileString(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void SaveSections()
        {
            string json = GetFileString(_path.HousePath);

            List<SectionJson> jsonArray = JsonConvert.DeserializeObject<List<SectionJson>>(json);

            foreach (SectionJson sectionJson in jsonArray)
            {
                foreach (RoomJson roomJson in sectionJson?.Rooms)
                {
                    Dictionary<ItemType, Item> items = _sections[sectionJson.Id].Content[roomJson.Id].Content;
                    foreach (ItemJson item in roomJson.Items)
                        item.Pos = items[(ItemType)item.DataId].Pos;
                }
            }

            json = JsonConvert.SerializeObject(jsonArray);
            File.WriteAllText(_path.HousePath, json);
        }

        private string GetFileString(string path)
        {
            StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();

            r.Close();
            return json;
        }
    }
}
