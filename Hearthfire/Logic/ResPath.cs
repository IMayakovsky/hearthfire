
namespace Hearthfire.Logic
{
    public class ResPath
    {
        public static string FamilyImages { get; private set; }
        public static string FamilyHouse { get; private set; }
        public static string Rooms { get; private set; }

        public static string Images => "/Database/Images/";
        public static string Section => Images + "section_default.png";
        public string ItemsPath => FamilyHouse + "/items.json";
        public string HousePath => FamilyHouse + "/house.json";

        private string _familyName;

        public ResPath(string familyName)
        {
            _familyName = familyName;
            FamilyHouse = "./Database/House/" + _familyName;
            FamilyImages = Images + familyName;
            Rooms = Images + _familyName + "/Rooms";
        }
    }
}
