using Convey;
using Notification.API;
using Convey.MessageBrokers.RabbitMQ;
using Serilog;

namespace Notification
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services);
            });


            builder.Services.AddNotificationModule();

            builder.Services.AddConvey().AddRabbitMq();

            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseNotificationModule();

            Log.Information("Notification App started (from Serilog)!");

            app.MapGet("/", () => "Notification App!");

            app.MapControllers();

            app.Run();
        }
    }
}