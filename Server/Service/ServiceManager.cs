using AutoMapper;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Service.Contracts;

namespace HotelManagementSystem.Server.Service
{
    /// <summary>
    /// Service manager class implementation
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IApplicationUserService> _applicationUserService;

        /// <summary>
        /// repository manager interface injection
        /// </summary>
        /// <param name="repositoryManager"></param>
        /// <param name="mapper"></param>
        /// <param name="loggerManager"></param>
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager loggerManager)
        {
            _applicationUserService = new Lazy<IApplicationUserService>(() =>
                new ApplicationUserService(repositoryManager, mapper, loggerManager));
        }

        /// <summary>
        /// implementing IApplicationUserService interface
        /// </summary>
        public IApplicationUserService ApplicationUserService => _applicationUserService.Value;
    }
}
