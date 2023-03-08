using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace PurchasePointCalcAPI.Extensions
{
    public static class ServiceExtensions
    {        
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config) 
        {
            var connectionString = config["mysqlconnection:connectionString"];

            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString,
                MySqlServerVersion.LatestSupportedServerVersion));
        }
    }
}
