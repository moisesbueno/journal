using DbUp;
using Journal.Domain.Abstractions;
using Journal.Infrastructure.MessageBus;
using Journal.Infrastructure.Persistence;
using Journal.Infrastructure.Persistence.Context;
using Journal.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Journal.CrossCuting.AppDependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DbServerData>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddDbContext<JournalContext>(options =>
            {
                var connectionString = configuration.GetSection("ConnectionString").Value;
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            services.AddSingleton(typeof(IPublisher<>), typeof(Publisher<>));
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

            upgrader.PerformUpgrade();
        }
    }
}