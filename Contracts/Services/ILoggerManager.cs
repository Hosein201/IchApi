using System;

namespace Contracts.Services
{
    public interface ILoggerManager
    {
        void LogInfo(Exception exception, string message);
        void LogInfo(string message);

        void LogWarn(Exception exception, string message);
        void LogWarn(string message);

        void LogDebug(string message);
        void LogDebug(Exception exception, string message);

        void LogError(string message);
        void LogError(Exception exception, string message);
    }
}
