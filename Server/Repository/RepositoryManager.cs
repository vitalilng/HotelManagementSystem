using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;

namespace HotelManagementSystem.Server.Repository
{
    /// <summary>
    /// Using Lazy class to ensure lazy initialization for our repositories. 
    /// Meaning that repository instances will be created only we access them 
    /// for the first time And not before that
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Lazy<IApplicationUserRepository> _applicationUserRepository;
        private readonly Lazy<IRoomRepository> _roomRepository;
        private readonly Lazy<ITransactionRepository> _transactionRepository;

        /// <summary>
        /// Constructor implementation
        /// </summary>
        /// <param name="applicationDbContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RepositoryManager(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext
                                    ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _applicationUserRepository = new Lazy<IApplicationUserRepository>(() => new ApplicationUserRepository(applicationDbContext));
            _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(applicationDbContext));
            _transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(applicationDbContext));
        }

        /// <summary>
        /// Implement the interface
        /// </summary>
        public IApplicationUserRepository ApplicationUserRepository => _applicationUserRepository.Value;

        /// <summary>
        /// implement room repository
        /// </summary>
        public IRoomRepository RoomRepository => _roomRepository.Value;

        /// <summary>
        /// implement transaction repository
        /// </summary>
        public ITransactionRepository TransactionRepository => _transactionRepository.Value;

        /// <summary>
        /// Save the changes to database
        /// </summary>
        public void Save() => _applicationDbContext.SaveChanges();
    }
}
