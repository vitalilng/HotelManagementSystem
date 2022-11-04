using AutoMapper;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.Exceptions;

namespace HotelManagementSystem.Server.Service
{
    /// <summary>
    /// Inheritance from IApplicationUserService
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
        public IEnumerable<RegistrationDto> GetAllGuestUsers(bool trackChanges)
        {
            var guests = _repositoryManager.ApplicationUser.GetAllGuestUsers(trackChanges)
                                                           .Where(u => u.UserName != "admin"); // get all guest users
            var guestsDto = _mapper.Map<IEnumerable<RegistrationDto>>(guests);
            return guestsDto;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationUserNotFoundException"></exception>
        public RegistrationDto GetApplicationUser(string userId, bool trackChanges)
        {
            var applicationUser = _repositoryManager.ApplicationUser.GetApplicationUser(userId, trackChanges);
            if (applicationUser is null)
            {
                throw new ApplicationUserNotFoundException(userId);
            }
            var applicationUserDto = _mapper.Map<RegistrationDto>(applicationUser);
            return applicationUserDto;
        }
    }
}