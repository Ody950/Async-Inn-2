namespace Async_Inn_2.Models
{
    public class Room
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Layout { get; set; }

        // Navigation Proparites

        public List<RoomAmenity> RoomAmenity { get; set; }
        public List<HotelRoom> HotelRoom { get; set; }
    }
}
