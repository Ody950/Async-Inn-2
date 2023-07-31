namespace Async_Inn_2.Models.DTOs
{
    public class HotelRoomDTO
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int HotelID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public RoomDTO? Room { get; set; }
       
    }
}
