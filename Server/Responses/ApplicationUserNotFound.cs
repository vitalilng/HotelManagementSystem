namespace HotelManagementSystem.Server.Responses
{
    /// <summary>
    /// The class inherits from the ApiNotFoundResponse abstract class,
    /// which again inherits from the ApiBaseResponse class.
    /// </summary>
    public sealed class ApplicationUserNotFound : ApiNotFoundResponse
    {
        /// <summary>
        /// Constructor that accepts an id parameter and creates
        /// a message that sends to the base class.
        /// </summary>
        /// <param name="id"></param>
        public ApplicationUserNotFound(Guid id)
            : base($"User with id: {id} is not found in the db")
        {
        }
    }
}