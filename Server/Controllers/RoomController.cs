using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// Room controller
    /// </summary>
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        /// <summary>
        /// Room constructor with service manager di
        /// </summary>
        /// <param name="serviceManger"></param>
        public RoomController(IServiceManager serviceManger) => _serviceManager = serviceManger;

        /// <summary>
        /// Get all rooms
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRooms()
        {
            var rooms = _serviceManager.RoomService.GetRooms();
            return Ok(rooms);
        }

        /// <summary>
        /// Get all current available rooms
        /// </summary>
        [HttpGet("GetAvailableRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAvailableRooms([FromQuery] TransactionParameters transactionParameters)
        {
            var availableRooms = _serviceManager.RoomService.GetAvailableRooms(transactionParameters);
            return Ok(availableRooms);
        }

        /// <summary>
        /// Return room by id
        /// </summary>
        /// <param name="roomId"></param>
        [HttpGet("{roomId}", Name = "RoomById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                return NotFound($"{roomId} was not found");
            }
            var room = _serviceManager.RoomService.GetRoom(roomId);
            return Ok(room);
        }

        /// <summary>
        /// CreateRoom
        /// </summary>
        /// <param name="roomDataForCreation"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateRoom([FromBody] RoomDataForCreationDto roomDataForCreation)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            if (roomDataForCreation is null)
            {
                return BadRequest("roomDataForCreation object is null");
            }
            var createdRoom = _serviceManager.RoomService.CreateRoom(roomDataForCreation);
            return CreatedAtRoute("RoomById", new { roomId = createdRoom.Id }, createdRoom);
        }

        /// <summary>
        /// Update room details
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomDataForUpdate"></param>
        [HttpPut("{roomId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRoom(Guid roomId, [FromBody] RoomDataForUpdateDto roomDataForUpdate)
        {
            if (roomDataForUpdate is null)
            {
                return BadRequest("roomDataForUpdate object is null");
            }
            _serviceManager.RoomService.UpdateRoom(roomId, roomDataForUpdate);
            return NoContent();
        }

        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="roomId"></param>
        [HttpDelete("{roomId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                return NotFound($"{roomId} was not found");
            }
            _serviceManager.RoomService.DeleteRoom(roomId);
            return NoContent();
        }

        /// <summary>
        /// Patch room details
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="returnedRoomDataForPatch"></param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{roomId}")]
        public IActionResult PatchRoom(Guid roomId, [FromBody] JsonPatchDocument<RoomDataForUpdateDto> returnedRoomDataForPatch)
        {
            if (returnedRoomDataForPatch is null)
            {
                return BadRequest("roomDataForPatch object sent from client is null");
            }
            var (roomDataForUpdate, sourceRoom) = _serviceManager.RoomService.GetRoomForPatch(roomId);
            returnedRoomDataForPatch.ApplyTo(roomDataForUpdate);
            _serviceManager.RoomService.SaveChangesForPatch(roomDataForUpdate, sourceRoom);
            return NoContent();
        }
    }
}