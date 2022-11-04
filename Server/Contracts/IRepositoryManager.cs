namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Repository manager, which will create instances of repository user classes for us and then
    /// register them inside the dependency injection container
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// 
        /// </summary>
        IApplicationUserRepository ApplicationUser { get; }
        
        /// <summary>
        /// save to database
        /// </summary>
        void Save();
    }
}
