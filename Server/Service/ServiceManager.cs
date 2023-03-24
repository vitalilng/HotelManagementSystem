using AutoMapper;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Service.Contracts;

namespace HotelManagementSystem.Server.Service
{
    /// <summary>
    /// Service manager class implementation
    /// We are utilizing the Lazy class to ensure the 
    /// lazy initialization of our services.
    /// </summary>
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IApplicationUserService> _applicationUserService;
        private readonly Lazy<IRoomService> _roomService;
        private readonly Lazy<ITransactionService> _transactionService;

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

            _roomService = new Lazy<IRoomService>(() =>
                new RoomService(repositoryManager, mapper, loggerManager));

            _transactionService = new Lazy<ITransactionService>(() =>
                new TransactionService(repositoryManager, mapper, loggerManager));

        }

        /// <summary>
        /// 
        /// </summary>
        public IApplicationUserService ApplicationUserService => _applicationUserService.Value;

        /// <summary>
        /// 
        /// </summary>
        public IRoomService RoomService => _roomService.Value;

        /// <summary>
        /// 
        /// </summary>
        public ITransactionService TransactionService => _transactionService.Value;
    }
}
