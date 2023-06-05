using AutoMapper;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.Exceptions;
using HotelManagementSystem.Shared.RequestFeatures;

namespace HotelManagementSystem.Server.Service
{
    /// <summary>
    /// Room Service
    /// </summary>
    public class RoomService : IRoomService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;

        /// <summary>
        /// Room service constructor with dependecy injection for mapper, repositoryManager and loggerManager
        /// </summary>
        /// <param name="repositoryManager"></param>
        /// <param name="mapper"></param>
        /// <param name="loggerManager"></param>
        public RoomService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        /// <summary>
        /// Return all rooms
        /// </summary>
        public IEnumerable<RoomDto> GetRooms()
        {
            var rooms = _repositoryManager.RoomRepository.GetRooms();

            //map rooms to RoomDto using automapper
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        /// <summary>
        /// Get all available rooms
        /// </summary>
        /// <exception cref="InValidDateRangeBadRequestException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<RoomDto> GetAvailableRooms(TransactionParameters transactionParameters)
        {
            try
            {
                if (!transactionParameters.DateOfArrival.HasValue || !transactionParameters.DateOfDeparture.HasValue)
                    throw new InValidDateRangeBadRequestException("Both dates are required!");

                if (!transactionParameters.ValidDateRange)
                    throw new InValidDateRangeBadRequestException("Date of Departure should be higher than Date of Arrival!");

                if (transactionParameters.DateOfArrival < DateTime.Today && transactionParameters.DateOfDeparture < DateTime.Today)
                    throw new InValidDateRangeBadRequestException("Please, choose the date starting from today!");

                var rooms = _repositoryManager.RoomRepository.GetRoomsQueryable()
                    .Where(r => r.Transactions != null && r.Transactions.Any(t =>
                            t.DepartureDate < transactionParameters.DateOfArrival ||
                            t.ArrivalDate > transactionParameters.DateOfDeparture));

                if (rooms?.Any() != true)
                {
                    return new List<RoomDto>();
                }

                return _mapper.Map<IEnumerable<RoomDto>>(rooms);
            }
            catch (InValidDateRangeBadRequestException ex)
            {
                _loggerManager.LogError($"{ex}");
                throw;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException($"Message: {ex}");
            }
        }

        /// <summary>
        /// Return current room
        /// </summary>
        /// <param name="roomId"></param>
        /// <exception cref="RoomNotFoundException"></exception>
        public RoomDto GetRoom(Guid roomId)
        {
            var room = _repositoryManager.RoomRepository.GetRoom(roomId) ?? throw new RoomNotFoundException(roomId);
            return _mapper.Map<RoomDto>(room);
        }

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="roomDataForCreation"></param>
        public RoomDto CreateRoom(RoomDataForCreationDto roomDataForCreation)
        {
            var newRoom = _mapper.Map<Room>(roomDataForCreation); //Map<Tdestination>(Tsource) - map roomDataForCreation to Room model
            _repositoryManager.RoomRepository.CreateRoom(newRoom);
            _repositoryManager.Save();
            return _mapper.Map<RoomDto>(newRoom);            
        }

        /// <summary>
        /// Update room details
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomDataForUpdate"></param>
        /// <exception cref="RoomNotFoundException"></exception>
        public void UpdateRoom(Guid roomId, RoomDataForUpdateDto roomDataForUpdate)
        {
            var roomToBeUpdated = _repositoryManager.RoomRepository.GetRoom(roomId)
                                  ?? throw new RoomNotFoundException(roomId);
            _mapper.Map(roomDataForUpdate, roomToBeUpdated); //(source, destination)
            _repositoryManager.RoomRepository.UpdateRoom(roomToBeUpdated);
            _repositoryManager.Save();
        }

        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="roomId"></param>
        /// <exception cref="RoomNotFoundException"></exception>
        public void DeleteRoom(Guid roomId)
        {
            var roomToBeDeleted = _repositoryManager.RoomRepository.GetRoom(roomId)
                                  ?? throw new RoomNotFoundException(roomId);
            _repositoryManager.RoomRepository.DeleteRoom(roomToBeDeleted);
        }

        /// <summary>
        /// Update only one value from room
        /// </summary>
        /// <param name="roomId"></param>
        /// <exception cref="RoomNotFoundException"></exception>
        public (RoomDataForUpdateDto roomDataForUpdate, Room sourceRoom) GetRoomForPatch(Guid roomId)
        {
            var roomToBePatched = _repositoryManager.RoomRepository.GetRoom(roomId)
                                  ?? throw new RoomNotFoundException(roomId);
            var roomDataForPatch = _mapper.Map<RoomDataForUpdateDto>(roomToBePatched);
            return (roomDataForPatch, roomToBePatched);
        }

        /// <summary>
        /// Save patch changes to database
        /// </summary>
        /// <param name="roomDataForPatch"></param>
        /// <param name="roomToBePatched"></param>
        public void SaveChangesForPatch(RoomDataForUpdateDto roomDataForPatch, Room roomToBePatched)
        {
            _mapper.Map(roomDataForPatch, roomToBePatched);
            _repositoryManager.Save();
        }
    }
}