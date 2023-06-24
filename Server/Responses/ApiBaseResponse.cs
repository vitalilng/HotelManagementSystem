namespace HotelManagementSystem.Server.Responses
{
    /// <summary>
    /// This is an abstract class,which will be the main return type for all of our
    /// methods where we have to return a successful result or an error result
    /// </summary>
    public abstract class ApiBaseResponse
    {
        /// <summary>
        /// Success property stating whether the action was successful or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Constructor to return success or an error result
        /// </summary>
        /// <param name="success"></param>
        protected ApiBaseResponse(bool success) => Success = success;
    }
}