namespace Journal.Api;

using Journal.Api.Repositories;
using Journal.Data;
using Journal.Repositories;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AppModule.ConfigureDatabase(builder.Configuration);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddJournalContext(builder.Configuration);
        builder.Services.AddTransient<IJournalRepository, JournalRepository>();

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