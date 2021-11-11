using System;

namespace Utility
{
    public static class EnvironmentExtensions
    {
        public static bool IsDevelopment()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return string.IsNullOrEmpty(environment) && environment.Contains("Development") ? true : false;
        }

        public static string IsEnvironment()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return string.IsNullOrEmpty(environment) ? environment : string.Empty;
        }

        public static bool IsProduction()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return string.IsNullOrEmpty(environment) && environment.Contains("Production") ? true : false;
        }
    }
}
