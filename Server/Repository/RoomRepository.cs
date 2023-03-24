using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;
using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Repository
{
    /// <summary>
    /// Room repository implementation
    /// </summary>
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        /// <summary>
        /// Room repository Constructor implementation
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public RoomRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        /// <summary>
        /// Return room by id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public Room GetRoom(Guid roomId)
        {
            return FindByCondition(c => c.Id.Equals(roomId)).SingleOrDefault();
        }

        /// <summary>
        /// Return all rooms sorted by price
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Room> GetRooms() => FindAll().OrderBy(c => c.Price).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Room> GetRoomsQueryable() => FindAll();
        
        
        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="room"></param>
        public void CreateRoom(Room room) => Create(room);

        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="room"></param>
        public void DeleteRoom(Room room) => Delete(room);

        /// <summary>
        /// Update room details
        /// </summary>
        /// <param name="room"></param>
        public void UpdateRoom(Room room) => Update(room);
        
    }
}
