namespace Async_Inn_2.Models.DTOs
{
    public class HotelDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public List<HotelRoomDTO>? HotelRoom { get; set; }

    }
}
