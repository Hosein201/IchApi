using Data;
using Data.InterFace;
using Data.NoSqlRepository.MongoDb;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service.Dto;
using Utility;

namespace IchApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configure Cors
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                {
                    ///<summary>
                    ///  Production
                    /// </summary>
                    // builder.WithOrigins("https://example.com").
                    //.WithMethods("POST", "GET")
                    //.WithHeaders("accept", "contenttype");

                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        /// <summary>
        /// IIS Configure
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(option =>
            {
            });
        }

        /// <summary>
        /// Configure Log
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLog(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configure Sql Context
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void ConfigureSqlContext(this IServiceCollection services, SqlDbSetting connectionString)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(connectionString.ConnectionSting);
            });
        }

        /// <summary>
        /// Configure Unit Of Work
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// Configure Mongo db
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMongodb(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto>), typeof(MongoRepository<CommonEvent<EmployeeDto>, EmployeeDto>));
            services.AddSingleton(typeof(IMongoRepository<CommonEvent<CompanyDto>, CompanyDto>), typeof(MongoRepository<CommonEvent<CompanyDto>, CompanyDto>));
        }
    }
}
