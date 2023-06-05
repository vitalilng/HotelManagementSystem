using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.RequestFeatures;

namespace HotelManagementSystem.Server.Service.Contracts
{
    /// <summary>
    /// Room service interface
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoomDto> GetRooms();

        /// <summary>
        /// Get all available rooms from db
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoomDto> GetAvailableRooms(TransactionParameters transactionParameters);

        /// <summary>
        /// Get room by id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns> room ID</returns>
        RoomDto GetRoom(Guid roomId);

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="roomDataForCreate"></param>
        /// <returns></returns>
        RoomDto CreateRoom(RoomDataForCreationDto roomDataForCreate);

        /// <summary>
        /// Update all room details
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomDatForUpdate"></param>
        void UpdateRoom(Guid roomId, RoomDataForUpdateDto roomDatForUpdate);

        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="roomId"></param>
        void DeleteRoom(Guid roomId);

        /// <summary>
        /// Patch some of the room data
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        (RoomDataForUpdateDto roomDataForUpdate, Room sourceRoom) GetRoomForPatch(Guid roomId);

        /// <summary>
        /// Save changes for modified room data
        /// </summary>
        /// <param name="roomDataForUpdate"></param>
        /// <param name="room"></param>
        void SaveChangesForPatch(RoomDataForUpdateDto roomDataForUpdate, Room room);
    }
}
