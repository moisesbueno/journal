using DbUp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Journal.Data
{
    public static class AppModule
    {
        public static IServiceCollection AddJournalContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MySqlData>();
            services.AddDbContext<JournalContext>(options =>
            {
                var connectionString = configuration.GetSection("ConnectionString").Value;
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
            return services;
        }

        public static void ConfigureDatabase(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;

            var upgrader = DeployChanges.To
                                        .MySqlDatabase(connectionString)
                                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                        .LogToConsole()
                                        .Build();

            var result = upgrader.PerformUpgrade();

        }
    }
}
