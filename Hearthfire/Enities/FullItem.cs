
namespace Hearthfire.Enities
{
    public class FullItem
    {
        public Item Main { get; set; }
        public ItemData Data { get; set; }

        public int RoomId { get; private set; }

        public FullItem(Item item, ItemData data, int roomId)
        {
            Main = item;
            Data = data;
            RoomId = roomId;
        }
    }
}
