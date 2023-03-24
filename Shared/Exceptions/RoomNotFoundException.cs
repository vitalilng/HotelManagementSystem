namespace HotelManagementSystem.Shared.Exceptions
{
    public sealed class RoomNotFoundException : NotFoundException
    {
        /// <summary>
        /// this constructor will call NotFoundException.NotFoundException(message)
        /// </summary>
        /// <param name="userId"></param>
        public RoomNotFoundException(Guid roomId) 
            : base($"The room with Id: {roomId} doesn't exist in the database!")
        {
        }
    }
}
