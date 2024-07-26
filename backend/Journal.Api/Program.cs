using FluentValidation;
using FluentValidation.AspNetCore;
using Journal.Api.Consumers;
using Journal.Api.Repositories;
using Journal.Data;
using Journal.MessageBus;


namespace Journal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Data.AppModule.ConfigureDatabase(builder.Configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddFluentValidationAutoValidation()
                            .AddValidatorsFromAssembly(typeof(Program).Assembly);
            
           

            builder.Services.AddJournalContext(builder.Configuration);
            builder.Services.AddMessageBus();
            builder.Services.AddTransient<IJournalRepository, JournalRepository>();
            builder.Services.AddHostedService<JournalConsumer>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
