namespace HotelManagementSystem.Server.Service.Contracts
{
    /// <summary>
    /// Service Manager
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// ApplicationUserService interface
        /// </summary>
        IApplicationUserService ApplicationUserService { get; } 

        /// <summary>
        /// Room Service interface
        /// </summary>
        IRoomService RoomService { get; }

        /// <summary>
        /// Transaction service interface
        /// </summary>
        ITransactionService TransactionService { get; }
    }
}
