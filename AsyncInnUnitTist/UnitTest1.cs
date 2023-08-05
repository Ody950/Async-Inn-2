using Async_Inn_2.Models;
using Async_Inn_2.Models.DTOs;
using Async_Inn_2.Models.Interfaces;
using Async_Inn_2.Models.Services;



namespace AsyncInnUnitTist
{
    public class UnitTest1 : Mock
    {

        //  ---------------------       Room and Aminity Test         --------------------------------


        [Fact]
        public async Task testCreateAndSaveAmenityAndRoom()
        {

            // Arrange

            var amenity = await CreateAndSaveAmenity();         
            var room = await CreateAndSaveTestRoom();
           

            var Service = new RoomServices(_db);

            // Act

            await Service.AddAmenityToRoom(room.ID, amenity.ID);       

            // Assert
            var actualRoom = await Service.GetRoom(room.ID);

            Assert.Contains(actualRoom.Amenities, a => a.ID == amenity.ID);

            
        }

        [Fact]
        public async Task testDeleteAmenityAndRoom()
        {

            // Arrange

            var amenity = await CreateAndSaveAmenity();
            var room = await CreateAndSaveTestRoom();


            var Service = new RoomServices(_db);

            // Act

            await Service.AddAmenityToRoom(room.ID, amenity.ID);

            await Service.RemoveAmentityFromRoom(room.ID, amenity.ID);

            // Assert
            var actualRoom = await Service.GetRoom(room.ID);

            Assert.DoesNotContain(actualRoom.Amenities, a => a.ID == amenity.ID);
        }


        [Fact]
        public async Task testCreateRoom()  //Add Room Test
        {

            // Arrange

            var theRoom = await TestRoom();  

            var Service = new RoomServices(_db);
            // Act

            var room = new RoomDTO
            { Name = theRoom.Name, Layout = theRoom.Layout };

            var addRoom = await Service.CreateRoom(room);

            // Assert
            var actualRoom = await Service.GetRoom(4);   //Get Hotel by ID Test

            Assert.Equal("studio", actualRoom.Name);
            Assert.Equal("studio", addRoom.Name);


        }

        [Fact]
        public async Task getTestRoomsTest() //Get Rooms Test
        {

            // Arrange

            var theRoom = await TestRoom();   //Add Room Test

            var Service = new RoomServices(_db);
            // Act

            var Room1 = new RoomDTO
            { Name = theRoom.Name, Layout = theRoom.Layout };

            var Room2 = new RoomDTO
            { Name = theRoom.Name, Layout = theRoom.Layout };


            var addRoom1 = await Service.CreateRoom(Room1);
            var addRoom2 = await Service.CreateRoom(Room2);
            // Assert


            List<RoomDTO> GetRoomList = await Service.GetRooms();    //Get Hotels Test
            Assert.Equal(6, GetRoomList.Count);
        }




        [Fact]
        public async Task RemoveRoomTest() //Get Rooms Test
        {

            // Arrange

            var theRoom = await TestRoom();   //Add Room Test

            var Service = new RoomServices(_db);
            // Act

            var Room1 = new RoomDTO
            { Name = theRoom.Name, Layout = theRoom.Layout };

            var Room2 = new RoomDTO
            { Name = theRoom.Name, Layout = theRoom.Layout };


            var addRoom1 = await Service.CreateRoom(Room1);
            var addRoom2 = await Service.CreateRoom(Room2);
            // Assert
            await Service.DeleteRoom(4);    //Delete Room Test
            List<RoomDTO> GetRoomList = await Service.GetRooms();
            Assert.Equal(5, GetRoomList.Count);
        }




        [Fact]
        public async Task UpdateRoom()
        {
            var RoomUpdate = new RoomDTO
            {
                ID = 1,
                Name = "RoomUpdate",
            };

            var repository = new RoomServices(_db);
            await repository.UpdateRoom(RoomUpdate.ID, RoomUpdate);

            var result = await repository.GetRoom(1);
            Assert.Equal(RoomUpdate.Name, result.Name);
        }


        [Fact]
        public async Task UpdateAmenity()
        {
            var amenityUpdate = new AmenityDTO
            {
                ID = 1,
                Name = "AmenityUpdate",
            };

            var repository = new AmenityServices(_db);
            await repository.UpdateAmenity(amenityUpdate.ID, amenityUpdate);

            var result = await repository.GetAmenity(1);
            Assert.Equal(amenityUpdate.Name, result.Name);
        }


        //  ---------------------       Hotel Test         --------------------------------




        [Fact]
        public async Task CreateAndSaveTestHotelTest()  //Add Hotel Test
        {

            // Arrange

            var theHotel = await CreateAndSaveTestHotel();     //Add Hotel Test

            var Service = new HotelServices(_db);
            // Act

            var hotel = new HotelDTO
            {Name = theHotel.Name, StreetAddress = theHotel.StreetAddress, City = theHotel.City, State = theHotel.State, Country = theHotel.Country, Phone = theHotel.Phone };

            var addHotel = await Service.CreateHotel(hotel);
          
            // Assert
            var actualHotel = await Service.GetHotel(4);   //Get Hotel by ID Test

            Assert.Equal("Amman Hotel", actualHotel.Name);
            Assert.Equal("Amman Hotel", addHotel.Name);
           
              
        }

        
       [Fact]
       public async Task getTestHotelsTest() //Get Hotels Test
       {

           // Arrange

           var theHotel = await CreateAndSaveTestHotel();     //Add Hotel Test

           var Service = new HotelServices(_db);
           // Act

           var hotel1 = new HotelDTO
           { Name = theHotel.Name, StreetAddress = theHotel.StreetAddress, City = theHotel.City, State = theHotel.State, Country = theHotel.Country, Phone = theHotel.Phone };

           var hotel2 = new HotelDTO
           { Name = "UpdateHotel", StreetAddress = theHotel.StreetAddress, City = theHotel.City, State = theHotel.State, Country = theHotel.Country, Phone = theHotel.Phone };

           var addHotel1 = await Service.CreateHotel(hotel1);  
           var addHotel2 = await Service.CreateHotel(hotel2);
           // Assert


           List<HotelDTO> GetHotelList = await Service.GetHotels();    //Get Hotels Test
           Assert.Equal(6, GetHotelList.Count);
       }




           [Fact]
       public async Task RemoveHotelTest() // Remove Hotel Test
       {

           // Arrange

           var theHotel = await CreateAndSaveTestHotel();     //Add Hotel Test

           var Service = new HotelServices(_db);
           // Act

           var hotel1 = new HotelDTO
           { Name = theHotel.Name, StreetAddress = theHotel.StreetAddress, City = theHotel.City, State = theHotel.State, Country = theHotel.Country, Phone = theHotel.Phone };

           var hotel2 = new HotelDTO
           { Name = "UpdateHotel", StreetAddress = theHotel.StreetAddress, City = theHotel.City, State = theHotel.State, Country = theHotel.Country, Phone = theHotel.Phone };

           var addHotel1 = await Service.CreateHotel(hotel1);
           var addHotel2 = await Service.CreateHotel(hotel2);

            // Assert
             await Service.DeleteHotel(4);    //Delete Hotel Test
            List<HotelDTO> GetHotelList = await Service.GetHotels();
            Assert.Equal(5, GetHotelList.Count);

        }

        [Fact]
        public async Task UpdateHotel()
        {
            var HotelUpdate = new HotelDTO
            {
                ID = 2,
                Name = "HotelUpdate",
                StreetAddress = "test",
                City = "test",
                State = "test",
                Country = "test",
                Phone = "test",
            };

            var repository = new HotelServices(_db);
            await repository.UpdateHotel(HotelUpdate.ID, HotelUpdate);

            var result = await repository.GetHotel(2);
            Assert.Equal(HotelUpdate.Name, result.Name);
        }

    }
}