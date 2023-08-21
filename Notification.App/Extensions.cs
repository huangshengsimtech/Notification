using Convey.MessageBrokers.RabbitMQ;
using Notification.Application;
using Notification.Application.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.UseCases.Dto;

namespace Notification.API
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services)
        {
            services.AddApplication();

            return services;
        }

        public static IApplicationBuilder UseNotificationModule(this IApplicationBuilder app)
        {
            app.UseRabbitMq().Subscribe<SchedulingAnAppointmentEventDto>(async (serviceProvider, message, context) =>
            {
                await serviceProvider.GetRequiredService<CreateAppointmentConfirmationEventHandler>().Handle(message);
            });

            return app;
        }
    }
}