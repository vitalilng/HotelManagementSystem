namespace HotelManagementSystem.Shared.Exceptions
{
    public sealed class ApplicationUserNotFoundException : NotFoundException
    {
        /// <summary>
        /// this constructor will call NotFoundException.NotFoundException(message)
        /// </summary>
        /// <param name="userId"></param>
        public ApplicationUserNotFoundException(string userId) 
            : base($"The user with Id: {userId} doesn't exist in the database!")
        {
        }
    }
}
