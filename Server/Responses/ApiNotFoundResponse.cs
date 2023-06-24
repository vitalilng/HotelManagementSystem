namespace HotelManagementSystem.Server.Responses
{
    /// <summary>
    /// Inherits from <see cref="ApiBaseResponse"/>
    /// and populates the Success property to false
    /// </summary>
    public abstract class ApiNotFoundResponse : ApiBaseResponse
    {
        /// <summary>
        /// Message property for the error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        protected ApiNotFoundResponse(string message) : base(true) => Message = message;
    }
}