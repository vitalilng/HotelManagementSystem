namespace HotelManagementSystem.Server.Responses
{
    /// <summary>
    /// This class will be used as a return type for a successful result.
    /// It inherits from the ApiBaseResponse and populates the Success property
    /// to true, through the constructor
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public sealed class ApiOkResponse<TResult> : ApiBaseResponse
    {
        /// <summary>
        /// Generic property, to store our concrete result in it
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// The constructor sets the Result property to the value passed as an argument and calls the base
        /// class constructor (base(true)) with the argument true.
        /// </summary>
        /// <param name="result"></param>
        public ApiOkResponse(TResult result) : base(true) => Result = result;
    }
}