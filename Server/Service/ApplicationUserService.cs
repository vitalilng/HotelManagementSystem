using AutoMapper;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.Exceptions;

namespace HotelManagementSystem.Server.Service
{
    /// <summary>
    /// Service Get data from Repository, and returned to Controller
    /// </summary>
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;

        /// <summary>
        /// Injecting Irepository manager
        /// </summary>
        /// <param name="repositoryManager"></param>
        /// <param name="mapper"></param>
        /// <param name="loggerManager"></param>
        public ApplicationUserService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        /// <summary>
        /// We are using our repository manager to call the GetAllGuestUsers
        /// method from the ApplicationUserRepository class and return all the guest users
        /// from the database.
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<UserDetailsDto> GetAllGuestUsers(bool trackChanges)
        {
            IEnumerable<ApplicationUser> guests = _repositoryManager.ApplicationUser.GetAllGuestUsers(trackChanges)
                                                           .Where(u => u.UserName != "admin"); // get all guest users
            // Execute a mapping from the source object to a new destination object.
            // The source type is inferred from the source object.
            // Map<TDestination>(object source);
            var guestsDto = _mapper.Map<IEnumerable<UserDetailsDto>>(guests);
            return guestsDto;
        }

        /// <summary>
        /// Get user by id from the Repository
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationUserNotFoundException"></exception>
        public UserDetailsDto GetApplicationUser(string userId, bool trackChanges)
        {
            ApplicationUser? applicationUser = _repositoryManager.ApplicationUser.GetApplicationUser(userId, trackChanges);
            if (applicationUser is null)
            {
                throw new ApplicationUserNotFoundException(userId);
            }
            var applicationUserDto = _mapper.Map<UserDetailsDto>(applicationUser);
            return applicationUserDto;
        }

        /// <summary>
        /// Create application guest user
        /// </summary>
        /// <param name="userDataForCreation"></param>
        /// <returns></returns>
        public UserDetailsDto CreateGuestUser(UserDataForCreationDto userDataForCreation)
        {
            ApplicationUser guestUserEntity = _mapper.Map<ApplicationUser>(userDataForCreation);
            _repositoryManager.ApplicationUser.CreateGuestUser(guestUserEntity);
            _repositoryManager.Save();
            UserDetailsDto guestUserToReturn = _mapper.Map<UserDetailsDto>(guestUserEntity);
            return guestUserToReturn;
        }

        /// <summary>
        /// Delete guest user from db
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <exception cref="ApplicationUserNotFoundException"></exception>
        public void DeleteGuestUser(string userId, bool trackChanges)
        {
            var guestUser = _repositoryManager.ApplicationUser.GetApplicationUser(userId, trackChanges);
            if (guestUser is null)
            {
                throw new ApplicationUserNotFoundException(userId);
            }
            _repositoryManager.ApplicationUser.DeleteGuestUser(guestUser);
            _repositoryManager.Save();
        }
    }
}