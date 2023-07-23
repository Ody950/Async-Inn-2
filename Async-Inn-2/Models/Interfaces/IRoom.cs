﻿namespace Async_Inn_2.Models.Interfaces
{
    public interface IRoom
    {
        // CREATE
        Task<Room> CreateRoom(Room room);

        // GET ALL
        Task<List<Room>> GetRooms();

        // GET ONE BY ID
        Task<Room> GetRoom(int id);
        // UPDATE
        Task<Room> UpdateRoom(int id, Room room);

        // DELETE
        Task DeleteRoom(int id);
    }
}