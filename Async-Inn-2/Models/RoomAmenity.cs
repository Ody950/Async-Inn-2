namespace Async_Inn_2.Models
{
    public class RoomAmenity
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        // Navigation Properties
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
