namespace Async_Inn_2.Models
{
    public class HotelRoom
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int HotelID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        // Navigation Proparites

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}
