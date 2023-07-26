namespace Async_Inn_2.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation Proparites

        public List<RoomAmenity> RoomAmenity { get; set; }
    }
}
