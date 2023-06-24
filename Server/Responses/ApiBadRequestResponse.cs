namespace HotelManagementSystem.Server.Responses
{
    /// <summary>
    /// Inherits from <see cref="ApiBaseResponse"/>
    /// </summary>
    public abstract class ApiBadRequestResponse : ApiBaseResponse
    {
        /// <summary>
        /// Message property for the error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        protected ApiBadRequestResponse(string message) : base(true) => Message = message;
    }
}