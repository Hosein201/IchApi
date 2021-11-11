using NLog;
using System;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogDebug(Exception exception, string message)
        {
            logger.Debug(exception, message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogError(Exception exception, string message)
        {
            logger.Error(exception, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogInfo(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        public void LogWarn(Exception exception, string message)
        {
            logger.Warn(exception, message);
        }
    }
}