
# Routes 

## Hotel Routes:
- GET: api/Hotels 
- GET: api/Hotels/{hotelId} 
- PUT: api/Hotels/{hotelId}
POST: api/Hotels 
- DELETE: api/Hotels/{hotelId} 


## Rooms Routes
- GET: api/Rooms
- GET: api/Rooms/{id} 
- PUT: api/Rooms/{id} 
- POST: api/Rooms 
- DELETE: {roomId} - *Delete a room
- POST: {roomId}/Amenity/{amenityId} 
- DELETE: {roomId}/{amenityId} - *Delete an amenity from a room



## HotelRoom Routes:
- GET: api/HotelRooms
- GET: api/HotelRooms/{hotelId}/Rooms/{roomNumber} 
- PUT: api/HotelRooms/{hotelId}/Rooms/{roomNumber} 
- POST: api/HotelRooms/"{hotelId}/Rooms 
- DELETE: api/HotelRooms/{hotelId}/Rooms/{roomNumber} 

## Amenities Routes
- GET: api/Amenities 
- GET: api/Amenities/{id} 
- PUT: api/Amenities/{id} 
- POST: api/Amenities 
- DELETE: api/Amenities/{id} 
