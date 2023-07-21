using HotelManagementSystem.Server.Responses;
using HotelManagementSystem.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// This class inherits from the ControllerBase class and implements a
    /// single ProcessError action accepting an ApiBaseResponse parameter
    /// </summary>
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// Inside the action, we are inspecting the type of the sent parameter,
        /// and based on that type we return an appropriate message to the client
        /// </summary>
        /// <param name="apiBaseResponse"></param>
        /// <returns>A task that represents the asynchronous execute operation.</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ProcessError(ApiBaseResponse apiBaseResponse)
        {
            return apiBaseResponse switch
            {
                ApiNotFoundResponse => NotFound(new ErrorDetails
                {
                    Message = ((ApiNotFoundResponse)apiBaseResponse).Message,
                    StatusCode = StatusCodes.Status404NotFound
                }),
                ApiBadRequestResponse => BadRequest(new ErrorDetails()
                {
                    Message = ((ApiBadRequestResponse)apiBaseResponse).Message,
                    StatusCode = StatusCodes.Status400BadRequest
                }),
                _ => throw new NotImplementedException()
            };
        }
    }
}