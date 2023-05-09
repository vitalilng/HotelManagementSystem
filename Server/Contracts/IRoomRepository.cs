using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Room repository
    /// </summary>
    public interface IRoomRepository
    {
        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        IEnumerable<Room> GetRooms();

        /// <summary>
        /// GetRoomsQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<Room> GetRoomsQueryable();
        
        /// <summary>
        /// Get room
        /// </summary>
        /// <returns></returns>
        Room GetRoom(Guid roomId);

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="room"></param>
        void CreateRoom(Room room);

        /// <summary>
        /// Update room details
        /// </summary>
        /// <param name="room"></param>
        void UpdateRoom(Room room);

        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="room"></param>
        void DeleteRoom(Room room);
    }
}
