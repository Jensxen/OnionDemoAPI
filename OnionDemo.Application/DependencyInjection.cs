using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Command;
using OnionDemo.Application.IRepository;


namespace OnionDemo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookingCommand, BookingCommand>();
        services.AddScoped<IAccommodationCommand, AccommodationCommand>();
        
        return services;
    }
}