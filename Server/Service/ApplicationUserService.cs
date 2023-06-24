using AutoMapper;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Responses;
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
        /// <returns>An instance of <see cref="ApiBaseResponse"/> containing the guest users.</returns>
        /// <exception cref="Exception"></exception>
        //public IEnumerable<UserDetailsDto> GetApplicationUsers()
        public ApiBaseResponse GetApplicationUsers()
        {
            IEnumerable<ApplicationUser> guests = _repositoryManager.ApplicationUserRepository.GetApplicationUsers()
                                                           .Where(u => u.UserName != "admin"); // get all guest users
            // Execute a mapping from the source object to a new destination object.
            // The source type is inferred from the source object.
            // Map<TDestination>(object source);
            var guestsDto = _mapper.Map<IEnumerable<UserDetailsDto>>(guests);
            //return guestsDto;
            return new ApiOkResponse<IEnumerable<UserDetailsDto>>(guestsDto);
        }

        /// <summary>
        /// Get user by id from the Repository
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>An instance of <see cref="ApiBaseResponse"/> containing the guest user by id.</returns>
        /// <exception cref="ApplicationUserNotFoundException"></exception>
        /// public UserDetailsDto GetApplicationUser(string userId)
        public ApiBaseResponse GetApplicationUser(string userId)
        {
            ApplicationUser? applicationUser = _repositoryManager.ApplicationUserRepository.GetApplicationUser(userId);

            if (applicationUser is null)
            {
                _loggerManager.LogError("User not found.");
                throw new ApplicationUserNotFoundException(userId);
            }
            var applicationUserDto = _mapper.Map<UserDetailsDto>(applicationUser);
            //return applicationUserDto;
            return new ApiOkResponse<UserDetailsDto>(applicationUserDto);
        }

        /// <summary>
        /// Create application guest user
        /// </summary>
        /// <param name="userCreationDataToBeDisplayed"></param>
        /// <returns>The created guest user as a <see cref="UserDetailsDto"/>.</returns>
        public UserDetailsDto CreateApplicationUser(UserDataForCreationDto userCreationDataToBeDisplayed)
        {
            var guestUser = _mapper.Map<ApplicationUser>(userCreationDataToBeDisplayed); //Map<Tdestination>(Tsource)

            _repositoryManager.ApplicationUserRepository.CreateApplicationUser(guestUser);
            _repositoryManager.Save();

            var guestUserToReturn = _mapper.Map<UserDetailsDto>(guestUser);
            return guestUserToReturn;
        }

        /// <summary>
        /// Delete guest user from db
        /// </summary>
        /// <param name="userId"></param>
        /// <exception cref="RoomNotFoundException"></exception>
        public void DeleteApplicationUser(string userId)
        {
            var guestUser = _repositoryManager
                .ApplicationUserRepository
                .GetApplicationUser(userId);
            if (guestUser is null)
            {
                _loggerManager.LogError("User not founf");
                throw new ApplicationUserNotFoundException(userId);
            }
            _repositoryManager.ApplicationUserRepository.DeleteApplicationUser(guestUser);
            _repositoryManager.Save();
        }

        /// <summary>
        /// Update guest user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userUpdateDataToBeDisplayed"></param>
        /// <exception cref="ApplicationUserNotFoundException"></exception>
        public void UpdateApplicationUser(string userId, UserDataForUpdateDto userUpdateDataToBeDisplayed)
        {
            //get the user we want to update
            var userToBeUpdated = _repositoryManager.ApplicationUserRepository.GetApplicationUser(userId);
            if (userToBeUpdated is null)
            {
                _loggerManager.LogError("User to be updated not found");
                throw new ApplicationUserNotFoundException(userId);
            }

            //map user we want to update to user data to be updated
            _mapper.Map(userUpdateDataToBeDisplayed, userToBeUpdated); //(source, destination)            
            _repositoryManager.ApplicationUserRepository.UpdateApplicationUser(userToBeUpdated);
            _repositoryManager.Save();
        }

        /// <summary>
        /// Get the user data for patching
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The actual user to be modified, and the modifications to be applied</returns>
        public (UserDataForUpdateDto userDataForUpdate, ApplicationUser applicationUser) GetApplicationUserForPatch(string userId)
        {
            //get the user we want to patch update any details
            var applicationUser = _repositoryManager.ApplicationUserRepository.GetApplicationUser(userId);
            if (applicationUser is null)
            {
                _loggerManager.LogError("User to be updated not found.");
                 throw new ApplicationUserNotFoundException(userId);
            }
            var userDataForPatch = _mapper.Map<UserDataForUpdateDto>(applicationUser);
            return (userDataForPatch, applicationUser);
        }

        /// <summary>
        /// Get user to be patched, and the modified data to be applied
        /// </summary>
        /// <param name="userDataForUpdate"></param>
        /// <param name="applicationUser"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveChangesForPatch(UserDataForUpdateDto userDataForUpdate, ApplicationUser applicationUser)
        {
            _mapper.Map(userDataForUpdate, applicationUser);
            _repositoryManager.Save();
        }
    }
}