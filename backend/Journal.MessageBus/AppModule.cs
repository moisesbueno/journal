using Microsoft.Extensions.DependencyInjection;

namespace Journal.MessageBus
{
    public static class AppModule
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IPublisher<>), typeof(Publisher<>));
            return services;
        }
    }
}
