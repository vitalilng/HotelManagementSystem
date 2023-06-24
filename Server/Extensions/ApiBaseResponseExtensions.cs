using HotelManagementSystem.Server.Responses;

namespace HotelManagementSystem.Server.Extensions
{
    /// <summary>
    /// Extension method for ApiBaseResponse
    /// </summary>
    public static class ApiBaseResponseExtensions
    {
        /// <summary>
        /// The GetResult method will extend the ApiBaseResponse type
        /// <typeparam name="TResultType"></typeparam>
        /// <param name="apiBaseResponse"></param>
        /// </summary>
        /// <returns>The result of the required type</returns>
        public static TResultType GetResult<TResultType>(this ApiBaseResponse
            apiBaseResponse) => ((ApiOkResponse<TResultType>) apiBaseResponse).Result;
    }
}