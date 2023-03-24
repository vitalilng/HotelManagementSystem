namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Repository manager, which will create instances of repository user classes and
    /// register them inside the dependency injection container
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// 
        /// </summary>
        IApplicationUserRepository ApplicationUserRepository { get; }
        
        /// <summary>
        /// Room repository
        /// </summary>
        IRoomRepository RoomRepository { get; }

        /// <summary>
        /// Transaction Repository
        /// </summary>
        ITransactionRepository TransactionRepository { get; }

        /// <summary>
        /// save to database
        /// </summary>
        void Save();
    }
}
