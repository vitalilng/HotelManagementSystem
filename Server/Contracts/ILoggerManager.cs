namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Logging manager
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// info messages
        /// </summary>
        /// <param name="message"></param>
        void LogInfo(string message);
        
        /// <summary>
        /// warning messages
        /// </summary>
        /// <param name="message"></param>
        void LogWarning(string message);
        
        /// <summary>
        /// debug messages
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);
        
        /// <summary>
        /// error messages
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
    }
}
