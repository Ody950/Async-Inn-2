# Async-Inn

# Description

This ERD will be used during Async Inn project. The Hotel table allows us to create a properties for the hotel branch. The Hotel id is passed to the Rooms table , where the Rooms  get another id from room and used to create a unique room. The unique room is have amenities like air conditioning”, “coffee maker”, “ocean view”, “mini bar”.

# ERD:

<img src="./Async-Inn-2/Data/1.jpg" style="width: 1000px;">

# Explanation :
Table 1:

Hotel Table : have primary key (hotel ID), and the name, city, state, address, and phone number as attributes . Relationship is (one-to-many) with the join table HotleRoom because every hotel have many room but the room have one hotel.

<img src="./Async-Inn-2/Data/2.jpg" style="width: 400px;">

Table 2:

HotelRoom Table : have primary key (HotelRoomID) , room number, location,  pet friendly, price, as attributes , HotleID , RoomID as foreign keys, where any room can prat of hotel, relationship is (many to one) with hotelbID table  and (many to one) with RoomID table.

<img src="./Async-Inn-2/Data/3.jpg" style="width: 400px;">

Table 3:

Room Table  : have primary key (Room ID) , nickname, layout, Room Amenities, as attributes, have relationship is (one to many) with HotelRoom table and (one to many) with Room Amenities table. 

<img src="./Async-Inn-2/Data/4.jpg" style="width: 400px;">

Table 4:

Room AmenitiesTable:  have primary key (RoomAmenitiesID), and RoomID , AmenitiesID as foreign keys. and have relationship is (many to one) with Room table and (one to many) with  Amenities table, where every room have many Amenities by room Amenities use .

<img src="./Async-Inn-2/Data/5.jpg" style="width: 400px;">

Table 5:

AmenitiesTable:  have primary key (AmenitiesID) ,air conditioning, coffee maker, ocean view, mini bar, RoomID, and have relationship is (one to many) with Room Amenities table. where every room have many Amenities by room Amenities use .

<img src="./Async-Inn-2/Data/6.jpg" style="width: 400px;">
