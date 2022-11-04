using HotelManagementSystem.Server.Contracts;
using NLog;
using ILogger = NLog.ILogger;

namespace HotelManagementSystem.Server.LoggerService
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        /// <summary>
        /// LogManager Creates and manages instances of NLog.Logger objects.
        /// </summary>
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// 
        /// </summary>
        public LoggerManager()
        {
        }

        /// <summary>
        /// write debug messages
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message) => logger.Debug(message);

        /// <summary>
        /// write error messages
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message) => logger.Error(message);

        /// <summary>
        /// write info messages
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message) => logger.Info(message);
        
        /// <summary>
        /// write warning messages
        /// </summary>
        /// <param name="message"></param>
        public void LogWarning(string message) => logger.Warn(message);
        
    }
}
