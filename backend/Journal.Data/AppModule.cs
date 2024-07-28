using DbUp;
using Journal.Data.Interfaces;
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
            services.AddSingleton<IDataSource, MySqlDataSource>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
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

            EnsureDatabase.For.MySqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                                        .MySqlDatabase(connectionString)
                                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                        .LogToAutodetectedLog()
                                        .Build();

            var result = upgrader.PerformUpgrade();

        }

    }
}
